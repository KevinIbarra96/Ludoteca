<?php
    
    $arrayRutas = explode("/",$_SERVER['REQUES_URI']);

    echo $_SERVER['REQUES_URI'];

    $json=array(
        "detalle" => "no encontrado"
    );

    echo json_encode($json,true);
?>