$Connection= New-Object System.Data.SqlClient.SqlConnection;
$Connection.ConnectString="";
[System.Reflection.Assembly]::LoadFrom("C:\Users\wangjian\Desktop\carManager\CarManager\CarManager.Web\bin\CarManager.Web.dll");
$Acl =New-Object CarManager.Web,Mvc,Acls
$acls=$Acl.GetPermisson();
foreach($p in $acls){

}