<?php
require_once"lib.php";
require_once"conn.php";
	$option=readParameter(1,"option");
	
	echo"<html><head><title>AdminPage</title></head><body>";
	switch($option){
		case "allUser"://se il parametro option == "allUser" la pagina stampa a video la tabella utenti el database secret
			echo"<table border=1><tr><td>ID</td><td>NOME</td><td>COGNOME</td><td>MAIL</td><td>PASSWORD</td><td>NASCITA</td><td>CREAZIONE</td><td>ULTIMO ACCESSO</td><td>IMG</td></tr>";
			$r=mysqli_query($conn,"SELECT * FROM utenti ");
			$val=mysqli_fetch_all($r);	
			foreach($val as $id){
				echo"<tr>";
				foreach($id as $id2)
					echo"<td>".$id2."</td>";
				echo"</tr>";
			}
			echo"</table>";
		break;
		case "mailStatus"://se il parametro option == "mailStatus" la pagina stampa a video la tabella di amministrazione del validatore di mail
			echo statusMailValidator();
		break;
	}
	echo"</body></html>";
?>