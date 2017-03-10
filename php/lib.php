<?php

require_once"conn.php";

function readParameter($reqType,$parameterName){//restituisce il parametro $_GET[$parameterName] se $reqType=1 / $_POST[$parameterName] se $reqType=0
	if($reqType){
		if(isset($_GET[$parameterName])){//controlla che il valore sia settato
			if(!(empty($_GET[$parameterName])))//controlla che il valore non sia vuoto
				return $_GET[$parameterName];//ritorna il valore
		}
	}else{
		if(isset($_POST[$parameterName])){
			if(!(empty($_POST[$parameterName])))
				return $_POST[$parameterName];
		}
	}
	return false;//se i parametri non sono rispettati ritorna falso
}

function response($text){//stampa a video la stringa $text e termina il codice
	echo $text;
	exit;
}

function validateMail($mail){//ritorna vero se $mail è una mail valida
	/*
    $accessKeyMailValidator = "7b74a3e75988d9a09bac975799e4faea";
	$data=curlRequest("http://check.block-disposable-email.com/easyapi/json/".urlencode($accessKeyMailValidator)."/".urlencode($mail));//fa una richiesta al validatore e inserisce la risposta json in $data
	if($data["request_status"]=="success" && $data["domain_status"]=="ok")// se la risposta è corretta ritorna vero se no falso
		return true;
	else
		return false;
    */
    return true;
}

function curlRequest($url){ //fa una richiesta http a $url e ritorna il valore risposto dal server
	$ch = curl_init();
	curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);//toglie stampa a video automatica
	curl_setopt($ch, CURLOPT_URL, $url);
	curl_setopt($ch, CURLOPT_HEADER, 0);
	$data = json_decode(curl_exec($ch),true);
	curl_close($ch);
	return $data;
}
	
function statusMailValidator(){//fa una richiesta al validatore e ritorna una tabella html con i dati dell'amministratore dell'account per la validazione 
	$accessKeyMailValidator = "7b74a3e75988d9a09bac975799e4faea";
	$data=curlRequest("http://status.block-disposable-email.com/status/?apikey=".urlencode($accessKeyMailValidator));
	return"<table border=1>"
		."<tr><td>request_status</td><td>".$data["request_status"]."</td></tr>"
		."<tr><td>apikeystatus</td><td>".$data["apikeystatus"]."</td></tr>"
		."<tr><td>servertime</td><td>".$data["servertime"]."</td></tr>"
		."<tr><td>version</td><td>".$data["version"]."</td></tr>"
		."<tr><td>credits</td><td>".$data["credits"]."</td></tr>"
		."<tr><td>credits_time</td><td>".$data["credits_time"]."</td></tr>"
		."<tr><td>commercial_credit_status</td><td>".$data["commercial_credit_status"]."</td></tr>"
		."<tr><td>commercial_credit_status_percent</td><td>".$data["commercial_credit_status_percent"]."</td></tr>"
		."</table>";
}

?>