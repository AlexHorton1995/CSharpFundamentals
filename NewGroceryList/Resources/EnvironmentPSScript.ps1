#Run this script in powershell as administrator to create your hidden secure username and password

Write-Host "Running Powershell Script..."
$GROCERY_EMAIL = 'youremailhere@email.com'
$GROCERY_PW = 'yourpasswordhere'

$GROCERY_EMAIL_ENCODED = [Convert]::ToBase64String([Text.Encoding]::Unicode.GetBytes($GROCERY_EMAIL))
$GROCERY_PW_ENCODED = [Convert]::ToBase64String([Text.Encoding]::Unicode.GetBytes($GROCERY_PW))

[Environment]::SetEnvironmentVariable("GroceryApiEmail", $GROCERY_EMAIL_ENCODED, "User")
[Environment]::SetEnvironmentVariable("GroceryEmailPassword", $GROCERY_PW_ENCODED, "User")
Write-Host "Created Environment Variables!"