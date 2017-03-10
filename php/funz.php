<?php
require_once"lib.php";
require_once"conn.php";
//var_dump($_GET);
$method=1;//  1=GET 0=POST
$f=readParameter($method,"f");
if($f){
	switch($f){
		case 10://mysqli_real_escape_string() evita sql injection
			$nome=mysqli_real_escape_string($conn,readParameter($method,"nome"));
			$cognome=mysqli_real_escape_string($conn,readParameter($method,"cognome"));
			$mail=mysqli_real_escape_string($conn,readParameter($method,"mail"));
			$password=mysqli_real_escape_string($conn,readParameter($method,"pass"));
			$nascita=mysqli_real_escape_string($conn,readParameter($method,"nascita"));
			if($nome&&$cognome&&$mail&&$password&&$nascita){//se uno dei parametri è falso non faccio nulla
				if(!validateMail($mail))
					response("InvalidMail");
				$r=mysqli_query($conn,"SELECT id FROM utenti WHERE mail='$mail'");//controlla che non esista già un utente con la stessa mail 
                if(!mysqli_num_rows($r)){//se il numero di record della risposta è zero vuol dire che non ha trovato nessuna mail uguale e posso inserire l'utente
                    response(mysqli_query($conn,"INSERT INTO utenti(nome,cognome,mail,pass,nascita) VALUES('".$nome."','".$cognome."','".$mail."','".$password."','".$nascita."')"));//inserisce i valori nel database, se tutto va bene mysqli_query restituirà 1 e tramite response verrà stampato a video
                }else
					response("Already Set");
			}else{
					response("Error Parameter");
			}
		break;
		case 11:
			$mail=mysqli_real_escape_string($conn,readParameter($method,"mail"));
			$password=mysqli_real_escape_string($conn,readParameter($method,"pass"));
			if($mail&&$password)
				response(mysqli_num_rows(mysqli_query($conn,"SELECT id FROM utenti WHERE mail='$mail' and pass='$password'")));
		break;
	}
}
mysqli_close($conn);//chiude la connessione col database
?>