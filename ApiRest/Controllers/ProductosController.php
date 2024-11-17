<?php
    $pt = explode('\\',__DIR__);
    $ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3].'/'.$pt[4];

    //$ProjectPath = $pt[0].'/'.$pt[1].'/'.$pt[2].'/'.$pt[3];

    require_once($ProjectPath.'/Database/conexion.php');
    require_once($ProjectPath.'/Services/ProductoService.php');
    require_once($ProjectPath.'/Models/ResponseModel.php');

    class ProductosController{

        function home(){
            echo 'Productos Controller Home';
        }

        //Esta funcion esta exclusivamente para modificar el producto cuando no había antes
        function modificarProductoVisita(){            
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'idVisita' =>$BodyRequest['idVisita'],
                    'idProducto'=>$BodyRequest['idProducto'],
                    'cantidadProducto'=>$BodyRequest['cantidadProducto'],
                    'precioProducto'=>$BodyRequest['precioProducto']
                ];

                $database = new Connection();
                $productoSvc = new ProductoService();                
                $productoSvc->modificarProductoVisita( $dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Product Updated";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }

        function increaseCantidadProduct(){
            $Response = new ResponseModel();
            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'id' =>$BodyRequest['id'],
                    'Cantidad' => $BodyRequest['Cantidad']
                ];

                $database = new Connection();
                $productoSvc = new ProductoService();

                $productoSvc->increaseCantidadProduct($dataBody["id"], $dataBody["Cantidad"] );

                $database->closeConection();
                
                $Response->Rcode = 200;
                $Response->Rmessage = "Cantidad incrementada correctamente";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }

        function getAllProductos(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $productoSvc = new ProductoService();
                $Response->Rbody = $productoSvc->getAll();
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "All Productos listed";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
            
        }

        function getAllActiveProductos(){

            $Response = new ResponseModel();

            try{            
                $database = new Connection();
                $productoSvc = new ProductoService();
                $Response->Rbody = $productoSvc->getAllActive();
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "All Productos listed";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
            
        }

        function getProductoById(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $productoSvc = new ProductoService();
                $Response->Rbody = $productoSvc->getById($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Product Founded";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function addNewProducto(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'ProductoName' =>$BodyRequest['ProductoName'],
                    'Precio' =>$BodyRequest['Precio']
                ];

                $database = new Connection();
                $productoSvc = new ProductoService();                
                $Response->Rbody = $productoSvc->new($dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Producto Inserted";

                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function editProducto(){
            $Response = new ResponseModel();

            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);

                $dataBody = [
                    'ProductoName' =>$BodyRequest['ProductoName'],
                    'Cantidad' =>$BodyRequest['Cantidad'],
                    'Precio' =>$BodyRequest['Precio']
                ];

                $database = new Connection();
                $productoSvc = new ProductoService();                
                $productoSvc->update($BodyRequest['id'],$dataBody);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Product Updated";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
        function deleteProducto(){
            $Response = new ResponseModel();
            try{
                $BodyRequest = json_decode(file_get_contents('php://input'),true);
                $database = new Connection();
                $productoSvc = new ProductoService();
                $productoSvc->delete($BodyRequest['id']);
                $database->closeConection();

                $Response->Rcode = 200;
                $Response->Rmessage = "Product Deleted";
                
            }catch(Exception $ex){
                $Response->Rcode = 402;
                $Response->Rmessage = $ex->getMessage();
                $Response->RerrorCode = $ex->getCode();
            }finally{
                echo json_encode($Response);
            }
        }
    }
?>