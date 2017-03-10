<?php
	require_once"lib.php";
	$conn=mysqli_connect("localhost","dbsecret","usatetrello","my_dbsecret");
	
	if(mysqli_connect_errno()){
		response("Connection Failed: ".mysqli_connect_error());
	}
?>