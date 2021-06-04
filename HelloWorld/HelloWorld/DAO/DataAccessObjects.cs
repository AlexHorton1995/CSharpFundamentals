using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using HelloWorld.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.DAO
{

	public interface IDataAccessObjects
	{
		string ConnString { get; set; }
		IEnumerable<QueryModel> GetInvoiceTotalsByPriceRange(decimal lowRange, decimal highRange);
		DataAccessObjects InitializeDAO();
	}

	/// <summary>
	/// This class is specifically for handling interactions with data layer.
	/// </summary>
	/// 
	public class DataAccessObjects : IDataAccessObjects, IDisposable
	{
		private bool disposedValue;
		public string ConnString { get; set; }

		private IConfiguration configuration;

		/// <summary>
		/// GetTracksForArtist - Retrieves all tracks for artist passed.
		/// </summary>
		///
		public IEnumerable<QueryModel> GetInvoiceTotalsByPriceRange(decimal lowRange, decimal highRange)
		{
			try
			{
				using SqlConnection connection = new SqlConnection(ConnString);
				//open the SQL Connection
				connection.Open();

				string sql =
					@"
						SELECT *
						FROM(
							SELECT InvoiceLineID, MediaTrackID, AlbumTitle, ArtistsName, 
								   TrackName, MediaType, UnitPrice, Quantity
							FROM
							(
								SELECT IL.InvoiceLineId AS InvoiceLineID, TrackId as MediaTrackID, 
										UnitPrice, Quantity, Total FROM Invoice I (NOLOCK)
								INNER JOIN InvoiceLine IL WITH (NOLOCK) ON IL.InvoiceId = I.InvoiceId
							)SUBQ
							INNER JOIN(
								SELECT AB.Title as AlbumTitle, TrackList.TrackId AS tracksID, 
									TrackList.Name as TrackName, 
									ART.Name AS ArtistsName, MT.Name as MediaType
								FROM Album (NOLOCK) A
									INNER JOIN Album AB WITH (NOLOCK) ON AB.ArtistId = A.ArtistId AND 
										AB.AlbumId = A.AlbumId
									INNER JOIN Artist ART WITH (NOLOCK) ON ART.ArtistId = AB.ArtistId
									INNER JOIN Track TrackList WITH (NOLOCK) ON TrackList.AlbumId = AB.AlbumId
									INNER JOIN MediaType MT WITH (NOLOCK) ON MT.MediaTypeId = TrackList.MediaTypeId
							) SUBQ2 on SUBQ.MediaTrackID = tracksID
							WHERE Total BETWEEN @LowRange AND @HiRange
						) SUBQ3
						";

				var data = connection.Query<QueryModel>(sql, new { LowRange = lowRange, HiRange = highRange });

				return data;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return null;
			}
		}

		public DataAccessObjects InitializeDAO()
		{
			try
			{
				var builder = new ConfigurationBuilder()
				.AddJsonFile($"appsettings.json", true, true)
				.AddEnvironmentVariables()
				.Build();

				configuration = builder;
				if (SetConnString())
				{
					return this;
				}
				else
				{
					return null;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return null;
			}
 
		}

		private bool SetConnString()
		{
			this.ConnString = string.IsNullOrEmpty(this.ConnString) ? configuration.GetConnectionString("DefaultConnection") : this.ConnString;
			return !string.IsNullOrEmpty(this.ConnString);
		}

		#region Disposable
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects)
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
				disposedValue = true;
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ~DataAccessObjects()
		// {
		//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}
