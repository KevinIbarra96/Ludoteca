-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.0.29 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.5.0.6677
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para ludotecadb
CREATE DATABASE IF NOT EXISTS `ludotecadb` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `ludotecadb`;

-- Volcando estructura para tabla ludotecadb.configuracion
CREATE TABLE IF NOT EXISTS `configuracion` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ConfigName` varchar(45) DEFAULT NULL,
  `ConfigDescripcion` varchar(100) DEFAULT NULL,
  `ConfigStringValue` varchar(300) DEFAULT NULL,
  `ConfigBoolValue` tinyint(4) DEFAULT NULL,
  `ConfigIntValue` int(11) DEFAULT NULL,
  `ConfigDecimalValue` decimal(5,2) DEFAULT NULL,
  `status` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- Volcando datos para la tabla ludotecadb.configuracion: ~4 rows (aproximadamente)
INSERT IGNORE INTO `configuracion` (`id`, `ConfigName`, `ConfigDescripcion`, `ConfigStringValue`, `ConfigBoolValue`, `ConfigIntValue`, `ConfigDecimalValue`, `status`) VALUES
	(1, 'PrecioMinuto', 'Precio de cada minuto', NULL, NULL, NULL, 1.30, 1),
	(2, 'EdadMinima', 'Edad minima del niño(a)', NULL, NULL, 5, NULL, 1),
	(3, 'EdadMaxima', 'Edad maxima del niño(a)', NULL, NULL, 15, NULL, 1),
	(4, 'RutaTicket', 'Ruta del ticket', 'C:\\Casita de Molly', NULL, NULL, NULL, 1);

-- Volcando estructura para tabla ludotecadb.fiestas
CREATE TABLE IF NOT EXISTS `fiestas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `idHijo` int DEFAULT NULL,
  `idServicio` int DEFAULT NULL,
  `Fecha` date DEFAULT NULL,
  `Anticipo` decimal(8,0) DEFAULT '0',
  `Total` decimal(8,0) DEFAULT '0',
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_Fiesta_Hijos_idx` (`idHijo`),
  KEY `fk_Fiesta_Servicio_idx` (`idServicio`),
  CONSTRAINT `fk_Fiesta_Hijos` FOREIGN KEY (`idHijo`) REFERENCES `hijos` (`id`),
  CONSTRAINT `fk_Fiesta_Servicio` FOREIGN KEY (`idServicio`) REFERENCES `servicios` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla ludotecadb.fiestas: ~6 rows (aproximadamente)
INSERT INTO `fiestas` (`id`, `idHijo`, `idServicio`, `Fecha`, `Anticipo`, `Total`, `status`) VALUES
	(2, 1, 8, '2024-09-24', 0, 0, 1),
	(3, NULL, NULL, '2024-10-24', 100, 10, NULL),
	(4, NULL, NULL, '2024-10-01', 80, 10, 1),
	(5, 3, 10, '2024-10-01', 122, 10, 1),
	(6, 3, 9, '2024-10-17', 80, 10, 1),
	(7, 1, 9, '2024-10-17', 20, 10, 1);

-- Volcando estructura para tabla ludotecadb.gafetes
CREATE TABLE IF NOT EXISTS `gafetes` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Numero` int NOT NULL,
  `Asignado` smallint NOT NULL DEFAULT '0',
  `status` smallint NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla ludotecadb.gafetes: ~21 rows (aproximadamente)
INSERT INTO `gafetes` (`id`, `Numero`, `Asignado`, `status`) VALUES
	(1, 10, 1, 1),
	(2, 11, 0, 1),
	(3, 12, 0, 1),
	(4, 13, 0, 1),
	(5, 14, 0, 1),
	(6, 15, 0, 1),
	(7, 16, 0, 1),
	(8, 17, 0, 1),
	(9, 18, 0, 1),
	(10, 19, 0, 1),
	(11, 20, 0, 1),
	(12, 21, 1, 1),
	(13, 22, 1, 1),
	(14, 23, 0, 1),
	(15, 24, 0, 1),
	(16, 25, 0, 1),
	(17, 26, 0, 1),
	(18, 27, 0, 1),
	(19, 28, 0, 1),
	(20, 29, 0, 1),
	(21, 30, 0, 1);

-- Volcando estructura para tabla ludotecadb.hijos
CREATE TABLE IF NOT EXISTS `hijos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `NombreHijo` varchar(45) DEFAULT NULL,
  `Papa` int DEFAULT NULL,
  `Mama` int DEFAULT NULL,
  `fechaNac` varchar(45) DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_Hijo_Papa_idx` (`Papa`),
  KEY `fk_Hijo_Mama_idx` (`Mama`),
  CONSTRAINT `fk_Hijo_Mama` FOREIGN KEY (`Mama`) REFERENCES `padres` (`id`),
  CONSTRAINT `fk_Hijo_Papa` FOREIGN KEY (`Papa`) REFERENCES `padres` (`id`) ON UPDATE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- Volcando datos para la tabla ludotecadb.hijos: ~8 rows (aproximadamente)
INSERT IGNORE INTO `hijos` (`id`, `NombreHijo`, `Papa`, `Mama`, `fechaNac`, `status`) VALUES
	(1, 'Lia Alejandra Ibarra Vazquez', 1, 2, '2024-03-08 00:10:10', 1),
	(2, 'Hector Sanchez', 3, 0, '2024-03-08 00:10:10', 1),
	(3, 'Alejandrina Ibarra Vazquez', 1, 2, '2024-03-08 00:10:10', 1),
	(28, 'Minu Federrico', 48, 0, '22/11/2013 12:00:00 a. m.', 1),
	(29, 'Mini Federrica segunda', 0, 49, '22/11/2013 12:00:00 a. m.', 1),
	(30, 'Mini Federrica tercera', 50, 51, '22/11/2013 12:00:00 a. m.', 1),
	(31, 'Andrea', 52, 53, '05/10/2024 12:00:00 a. m.', 1),
	(32, 'Andrea', 54, 55, '10/08/2011 12:00:00 a. m.', 1),
	(33, 'Edilia Abarca Rosas', 56, 57, '21/11/2016 12:00:00 a. m.', 1);

-- Volcando estructura para tabla ludotecadb.menu
CREATE TABLE IF NOT EXISTS `menu` (
  `id` int NOT NULL AUTO_INCREMENT,
  `MenuName` varchar(45) DEFAULT NULL,
  `ClassName` varchar(45) DEFAULT NULL,
  `MenuOrder` smallint DEFAULT NULL,
  `Path` varchar(45) DEFAULT NULL,
  `IconName` varchar(45) DEFAULT NULL,
  `status` int DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla ludotecadb.menu: ~6 rows (aproximadamente)
INSERT INTO `menu` (`id`, `MenuName`, `ClassName`, `MenuOrder`, `Path`, `IconName`, `status`) VALUES
	(1, 'Inventario', 'InventarioView', 3, 'Ludoteca.View.InventarioView', 'inventario_icon.jpg', 1),
	(2, 'Visitas', 'VisitView', 2, 'Ludoteca.View.VisitView', 'visitas_icon.jpg', 1),
	(3, 'Servicios', 'ServiciosView', 4, 'Ludoteca.View.ServiciosView', 'inventario_icon.jpg', 1),
	(4, 'Configuracion', 'ConfiguracionView', 6, 'Ludoteca.View.ConfiguracionView', 'configuracion_icon.jpg', 1),
	(5, 'Ofertas', 'OfertasView', 5, 'Ludoteca.View.OfertasView', 'inventario_icon.jpg', 1),
	(6, 'Fiestas', 'FiestasView', 2, 'Ludoteca.View.FiestasView', 'fiesta_icon.jpg', 1);

-- Volcando estructura para tabla ludotecadb.ofertas
CREATE TABLE IF NOT EXISTS `ofertas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `OfertaName` varchar(45) DEFAULT NULL,
  `Descripcion` varchar(250) DEFAULT NULL,
  `Tiempo` int DEFAULT NULL,
  `totalDescuento` double DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- Volcando datos para la tabla ludotecadb.ofertas: ~4 rows (aproximadamente)
INSERT IGNORE INTO `ofertas` (`id`, `OfertaName`, `Descripcion`, `Tiempo`, `totalDescuento`, `status`) VALUES
	(1, 'Sin Oferta', 'Opcion de oferta desiganada para no tener ofertas', 0, 0, 1),
	(2, 'treinta minutos', 'Oferta para dar 30 minutos de descuento', 30, 0, 1),
	(3, '10 pesos', 'Descuento de diez pesos', 0, 10, 1),
	(4, '2 minutos', 'Descuento para 2 minutos ', 2, 0, 1);

-- Volcando estructura para tabla ludotecadb.padres
CREATE TABLE IF NOT EXISTS `padres` (
  `id` int NOT NULL AUTO_INCREMENT,
  `PadreName` varchar(45) DEFAULT NULL,
  `Address` varchar(105) DEFAULT NULL,
  `Telefono` varchar(45) DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`)

) ENGINE=InnoDB AUTO_INCREMENT=58 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- Volcando datos para la tabla ludotecadb.padres: ~15 rows (aproximadamente)
INSERT IGNORE INTO `padres` (`id`, `PadreName`, `Address`, `Telefono`, `status`) VALUES
	(0, 'No padre asignado', 'NA', '0', 1),
	(1, 'Kevin Daryl Ibarra Sandoval', 'Su casa', '7531420527', 1),
	(2, 'Alejandrina Vazquez', 'Su casa', '7531679414', 1),
	(3, 'Hector Sancez Culebra', 'Su casa ', '7531454598', 1),
	(48, 'Federrico Diaz', 'Su casa no casa que si su casa', '7531420627', 1),
	(49, 'Doña federica', 'Su casa no casa que si su casa', '7531420628', 1),
	(50, 'Lautaro Martinez', 'Su casa no casa que si su casa', '7531420727', 1),
	(51, 'Laura Dominguez', 'Su casa no casa que si su casa', '7531420629', 1),
	(52, 'Alberto', 'Av. altamarino colonia centro', '7536986984', 1),
	(53, 'Karina', 'Av. altamarino colonia centro', '753698458', 1),
	(54, 'Alberto', 'Av. altamarino colonia centro', '7536986984', 1),
	(55, 'Karina', 'Av. altamarino colonia centro', '753698458', 1),
	(56, 'Alberto Abarca', 'LA casa que esta en el centro', '7531389565', 1),
	(57, 'Alejandra Rosas', 'LA casa que esta en el centro', '7531476614', 1);

-- Volcando estructura para tabla ludotecadb.productos
CREATE TABLE IF NOT EXISTS `productos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ProductoName` varchar(45) DEFAULT NULL,
  `Cantidad` int DEFAULT '0',
  `Precio` int DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla ludotecadb.productos: ~9 rows (aproximadamente)

INSERT IGNORE INTO `productos` (`id`, `ProductoName`, `Cantidad`, `Precio`, `status`) VALUES
	(1, 'Calcetas chicas', 42, 10, 1),
	(2, 'Agua 200ml', -2, 20, 1),
	(3, 'Gomita Gusano pz', -1, 1, 1),
	(4, 'Slime', -5, 25, 1),
	(9, 'Spiderman Grandote', 17, 450, 1),
	(10, 'Spiderman Chiquito', -1, 150, 1),
	(15, 'Probando', 20, 23, 1),
	(16, 'Probando2', 17, 48, 1),
	(17, 'PruebaProducto', 12, 23, 1);

-- Volcando estructura para tabla ludotecadb.rol
CREATE TABLE IF NOT EXISTS `rol` (
  `id` int NOT NULL AUTO_INCREMENT,
  `RolName` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3 COMMENT='		';

-- Volcando datos para la tabla ludotecadb.rol: ~2 rows (aproximadamente)
INSERT INTO `rol` (`id`, `RolName`, `status`) VALUES
	(1, 'Administrador', '1'),
	(2, 'Cajera', '1');

-- Volcando estructura para tabla ludotecadb.rol_menu
CREATE TABLE IF NOT EXISTS `rol_menu` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_Rol` int NOT NULL,
  `id_Menu` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_Rol_Menu_Rol_idx` (`id_Rol`),
  KEY `FK_Rol_Menu_Menu_idx` (`id_Menu`),
  CONSTRAINT `FK_Rol_Menu_Menu` FOREIGN KEY (`id_Menu`) REFERENCES `menu` (`id`),
  CONSTRAINT `FK_Rol_Menu_Rol` FOREIGN KEY (`id_Rol`) REFERENCES `rol` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla ludotecadb.rol_menu: ~7 rows (aproximadamente)
INSERT INTO `rol_menu` (`id`, `id_Rol`, `id_Menu`) VALUES
	(13, 1, 1),
	(14, 1, 2),
	(15, 1, 3),
	(16, 1, 4),
	(17, 2, 2),
	(18, 1, 5),
	(19, 1, 6);

-- Volcando estructura para tabla ludotecadb.servicios
CREATE TABLE IF NOT EXISTS `servicios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ServicioName` varchar(400) DEFAULT NULL,
  `Descripcion` text,
  `Precio` int DEFAULT NULL,
  `Tiempo` int DEFAULT NULL,
  `IdTipoServicio` int DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_Servicio_TipoServicio_idx` (`IdTipoServicio`),
  CONSTRAINT `fk_Servicio_TipoServicio` FOREIGN KEY (`IdTipoServicio`) REFERENCES `tiposervicio` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb3;


-- Volcando datos para la tabla ludotecadb.servicios: ~17 rows (aproximadamente)
INSERT IGNORE INTO `servicios` (`id`, `ServicioName`, `Descripcion`, `Precio`, `Tiempo`, `IdTipoServicio`, `status`) VALUES
	(1, 'Media Hora', 'Servicio destinado con precio por minuto especial para 30 minutos', 15, 30, 1, 1),
	(2, 'Una Hora', 'Servicio destinado a una hora con descuento ', 14, 60, 1, 1),
	(3, 'Plan Cine', 'Para que se vallan al cine los jefes', 250, 150, 1, 1),
	(4, 'Servicio de Prueba', 'Estoy probando los cambios que se deben percibir en cuanto se realizan las actualizaciones', 25, 56, 1, 1),
	(5, 'fegw', 'egwweg', 212, 1212, 1, 1),
	(6, 'Prueba pocos minutos', 'Esta solo es una prueba para probar el funcionamiento con pocos minutos.', 50, 2, 1, 1),
	(7, 'Tiempo Libre', 'el hijo puede estar tel tiempo que sea pero se cobra a precio del minuto', 0, 0, 1, 1),
	(8, 'Fiesta 20 Niños', 'Fiesta para 20 niños, esta incluyé muchas cosas', 9000, 0, 2, 1),
	(9, 'Fiesta para 40 niños', 'Este servicio va destinado a una fiesta de 40 niños', 12000, 0, 2, 1),
	(10, 'Fiesta para 15 niños', 'muchas cosas', 5000, 0, 2, 1),
	(11, 'asdgf', 'dasda', 5, 10, 2, 1),
	(12, 'Prueba', 'Veamos que id agrega', 10, 2, 1, 1),
	(13, 'Nombre del servicio', 'Descripción', 100, 30, 2, 1),
	(14, 'Pase de batalla', 'Pase de batalla de genshin impact', 150, 10, 1, 1),
	(15, 'Pase de Hokai', 'PAse de batalla', 150, 10, 2, 1),
	(16, 'aaaaaaaaaaa', 'aaaaa', 10, 15, 2, 1),
	(17, 'Sub ren', 'Sub para el canal de renrice', 150, 10, 2, 1),
	(18, 'error ', 'errro', 153, 10, 1, 1);

-- Volcando estructura para tabla ludotecadb.tickets
CREATE TABLE IF NOT EXISTS `tickets` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  `idvisita` int(11) DEFAULT NULL,
  `fecha_creacion` varchar(50) DEFAULT NULL,
  `ruta` varchar(300) DEFAULT NULL,
  `status` int(11) DEFAULT 1,
  PRIMARY KEY (`id`),
  KEY `FK_tickets_visitas` (`idvisita`),
  CONSTRAINT `FK_tickets_visitas` FOREIGN KEY (`idvisita`) REFERENCES `visitas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- Volcando datos para la tabla ludotecadb.tickets: ~15 rows (aproximadamente)
INSERT IGNORE INTO `tickets` (`id`, `nombre`, `idvisita`, `fecha_creacion`, `ruta`, `status`) VALUES
	(1, 'pdf.pdf', 53, '24/08/2024', 'C:\\casa\\2024\\Septiembre\\24/', 1),
	(2, 'valenciaortiz.pdf', 59, '01/10/24', 'C:/casa/2024/Octubre/1/', 1),
	(3, 'valverderomano.pdf', 51, '01/10/24', 'C:/casa/2024/Octubre/1/', 1),
	(4, 'garciavalencia.pdf', 57, '01/10/2024', 'C:/casa/2024/Octubre/1/', 1),
	(5, 'sosaramirez.pdf', 87, '01/10/24', 'C:/casa/2024/Octubre/1/', 1),
	(10, 'Ticket_100_Edilia Abarca Rosas20241005_183907.pdf', 100, '2024-10-05T18:39:07.3660682-06:00', 'C:\\Casita de Molly\\2024\\octubre\\5\\Ticket_100_Edili', 1),
	(11, 'Ticket_101_Edilia Abarca Rosas20241005_184035.pdf', 101, '2024-10-05T18:40:35.3152201-06:00', 'C:\\Casita de Molly\\2024\\octubre\\5\\Ticket_101_Edilia Abarca Rosas20241005_184035.pdf', 1),
	(12, 'Ticket_102_Edilia Abarca Rosas20241007_202636.pdf', 102, '2024-10-07T20:26:36.6537594-06:00', 'C:\\Casita de Molly\\2024\\octubre\\7\\Ticket_102_Edilia Abarca Rosas20241007_202636.pdf', 1),
	(13, 'Ticket_103_Lia Alejandra Ibarra Vazquez20241007_20', 103, '2024-10-07T20:31:11.764-06:00', 'C:\\Users\\Usuario\\OneDrive\\Documentos\\2024\\octubre\\7\\Ticket_103_Lia Alejandra Ibarra Vazquez20241007_', 1),
	(15, 'Ticket_106_Edilia Abarca Rosas20241007.pdf', 106, '2024-10-07T00:00:00-06:00', 'C:\\Users\\Usuario\\OneDrive\\Documentos\\test\\2024\\octubre\\7\\Ticket_106_Edilia Abarca Rosas20241007.pdf', 1),
	(16, 'Ticket_System.Func`2[System.Int32,System.Threading', 107, '2024-10-08T00:00:00-06:00', 'C:\\Casita de Molly\\2024\\octubre\\8\\Ticket_System.Func`2[System.Int32,System.Threading.Tasks.Task`1[System.Collections.Generic.List`1[Entidad.EN_Tickets]]]_Mini Federrica tercera20241008.pdf', 1),
	(17, 'Ticket_System.Func`1[System.Threading.Tasks.Task`1', 108, '2024-10-08T00:00:00-06:00', 'C:\\Casita de Molly\\2024\\octubre\\8\\Ticket_System.Func`1[System.Threading.Tasks.Task`1[System.Collections.Generic.List`1[Entidad.EN_Tickets]]]_Edilia Abarca Rosas20241008.pdf', 1),
	(18, 'Ticket_System.Func`1[System.Threading.Tasks.Task`1', 111, '2024-10-08T00:00:00-06:00', 'C:\\Casita de Molly\\2024\\octubre\\8\\Ticket_System.Func`1[System.Threading.Tasks.Task`1[Entidad.EN_Response`1[Entidad.EN_Tickets]]]_Hector Sanchez20241008.pdf', 1),
	(19, 'Ticket_19_Andrea20241008.pdf', 109, '2024-10-08T00:00:00-06:00', 'C:\\Casita de Molly\\2024\\octubre\\8\\Ticket_19_Andrea20241008.pdf', 1),
	(20, 'Ticket_20_Andrea20241008.pdf', 114, '2024-10-08T00:00:00-06:00', 'C:\\Casita de Molly\\2024\\octubre\\8\\Ticket_20_Andrea20241008.pdf', 1);

-- Volcando estructura para tabla ludotecadb.tiposervicio
CREATE TABLE IF NOT EXISTS `tiposervicio` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla ludotecadb.tiposervicio: ~2 rows (aproximadamente)
INSERT INTO `tiposervicio` (`id`, `nombre`, `status`) VALUES
	(1, 'Visita', 1),
	(2, 'Fiesta', 1);

-- Volcando estructura para tabla ludotecadb.users
CREATE TABLE IF NOT EXISTS `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `UserName` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `idRol` int DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_User_Rol_idx` (`idRol`),
  CONSTRAINT `fk_User_Rol` FOREIGN KEY (`idRol`) REFERENCES `rol` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla ludotecadb.users: ~4 rows (aproximadamente)
INSERT INTO `users` (`id`, `UserName`, `Password`, `idRol`, `status`) VALUES
	(1, 'Kevin Ibarra', 'Test1', 1, 1),
	(2, 'Gerardo Valente', 'Test', 1, 1),
	(3, 'Perla Anaya', 'Prueba', 1, 1),
	(4, 'Alejandrina Vazquez', 'Prueba', 1, 1);

-- Volcando estructura para tabla ludotecadb.visitas
CREATE TABLE IF NOT EXISTS `visitas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `HoraEntrada` datetime NOT NULL,
  `HoraSalida` datetime DEFAULT NULL,
  `Oferta` int NOT NULL,
  `Total` decimal(8,2) NOT NULL DEFAULT '0.00',
  `GafeteId` int DEFAULT NULL,
  `NumeroGafete` int DEFAULT NULL,
  `TiempoExcedido` int DEFAULT '0',
  `status` smallint NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_Visita_Oferta_idx` (`Oferta`),
  KEY `fk_Gafete_Oferta_idx` (`GafeteId`),
  CONSTRAINT `fk_Visita_Gafete` FOREIGN KEY (`GafeteId`) REFERENCES `gafetes` (`id`),
  CONSTRAINT `fk_Visita_Oferta` FOREIGN KEY (`Oferta`) REFERENCES `ofertas` (`id`)

) ENGINE=InnoDB AUTO_INCREMENT=115 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- Volcando datos para la tabla ludotecadb.visitas: ~56 rows (aproximadamente)
INSERT IGNORE INTO `visitas` (`id`, `HoraEntrada`, `HoraSalida`, `Oferta`, `Total`, `GafeteId`, `NumeroGafete`, `TiempoExcedido`, `status`) VALUES
	(49, '2024-04-09 22:58:19', '2024-04-09 23:45:34', 1, 275.00, 14, 23, 0, 0),
	(50, '2024-04-09 23:03:49', '2024-04-09 23:46:07', 1, 51.00, 4, 13, 0, 0),
	(51, '2024-04-18 01:27:57', NULL, 1, 400.00, 2, 11, 0, 0),
	(52, '2024-04-18 01:28:42', NULL, 1, 29.00, 5, 14, 0, 0),
	(53, '2024-04-18 01:29:22', '2024-04-18 02:01:23', 1, 61.00, 1, 10, 0, 0),
	(54, '2024-04-18 01:32:13', NULL, 1, 175.00, 7, 16, 0, 0),
	(55, '2024-04-18 01:32:37', NULL, 1, 726.00, 6, 15, 0, 0),
	(56, '2024-04-18 01:33:08', NULL, 1, 198.00, 8, 17, 0, 0),
	(57, '2024-04-18 02:21:35', '2024-04-18 02:25:31', 1, 101.00, 4, 13, 0, 0),
	(58, '2024-04-18 02:28:10', NULL, 1, 673.00, 9, 18, 0, 0),
	(59, '2024-04-20 01:50:21', '2024-04-23 22:38:02', 1, 6235.00, 4, 13, 0, 0),
	(60, '2024-04-20 01:59:27', '2024-04-20 02:00:25', 1, 65.00, 3, 12, 0, 0),
	(61, '2024-04-23 22:59:20', '2024-04-24 00:37:41', 1, 135.00, 1, 10, 0, 0),
	(62, '2024-04-23 22:59:47', '2024-04-24 00:42:30', 1, 112.00, 10, 19, 0, 0),
	(63, '2024-04-23 23:00:34', '2024-04-24 00:43:08', 1, 110.00, 11, 20, 0, 0),
	(64, '2024-04-23 23:00:57', '2024-04-24 00:43:31', 1, 114.00, 4, 13, 0, 0),
	(65, '2024-04-23 23:01:04', '2024-04-24 00:43:56', 1, 115.00, 4, 13, 0, 0),
	(66, '2024-04-25 00:26:50', '2024-04-25 02:15:31', 1, 700.00, 3, 12, 0, 0),
	(67, '2024-05-24 13:57:41', NULL, 1, 250.00, 3, 12, 0, 0),
	(68, '2024-05-24 13:57:59', '2024-05-24 14:40:01', 1, 285.00, 3, 12, 0, 0),
	(69, '2024-06-30 16:29:04', '2024-06-30 22:22:57', 1, 657.00, 4, 13, 0, 0),
	(70, '2024-07-01 23:15:39', '2024-07-02 13:17:30', 1, 1365.00, 4, 13, 0, 0),
	(71, '2024-07-09 18:22:14', '2024-07-09 18:29:47', 1, 27.00, 3, 12, 0, 0),
	(72, '2024-07-16 01:14:20', '2024-07-18 00:38:01', 1, 3184.00, 4, 13, 0, 0),
	(73, '2024-07-16 01:18:41', '2024-07-16 01:28:17', 1, 46.00, 4, 13, 0, 0),
	(74, '2024-07-18 00:39:04', '2024-07-18 00:46:31', 1, 7.00, 3, 12, 0, 0),
	(75, '2024-07-18 00:39:34', '2024-07-18 00:46:37', 1, 17.00, 3, 12, 0, 0),
	(76, '2024-07-18 00:47:00', '2024-07-23 01:32:49', 1, 8139.00, 10, 19, 0, 0),
	(77, '2024-07-23 01:42:06', '2024-07-24 01:27:04', 1, 2088.00, 3, 12, 0, 0),
	(78, '2024-07-24 01:41:28', '2024-07-24 01:54:06', 1, 272.00, 3, 12, 0, 0),
	(79, '2024-07-24 01:56:46', '2024-07-24 01:57:21', 1, 168.00, 10, 19, 0, 0),
	(80, '2024-07-24 01:59:58', '2024-07-24 02:00:17', 1, 282.00, 4, 13, 0, 0),
	(81, '2024-07-24 02:05:38', '2024-07-24 02:16:55', 1, 507.00, 10, 19, 11, 0),
	(82, '2024-07-24 02:17:42', '2024-07-24 02:17:54', 1, 63.00, 10, 19, 0, 0),
	(83, '2024-07-24 23:56:21', '2024-07-24 23:59:16', 1, 54.00, 3, 12, 0, 0),
	(84, '2024-07-25 00:02:54', '2024-07-25 00:02:59', 1, 290.00, 1, 10, 0, 0),
	(85, '2024-07-25 00:39:55', NULL, 1, 54.00, 4, 13, 0, 0),
	(86, '2024-07-25 00:40:09', '2024-07-25 01:25:38', 1, 784.00, 4, 13, 0, 0),
	(87, '2024-08-06 01:14:08', '2024-09-12 23:43:52', 1, 71082.00, 3, 12, 54479, 0),
	(88, '2024-08-21 23:13:16', NULL, 1, 37.00, 1, 10, 0, 0),
	(89, '2024-08-21 23:14:26', NULL, 1, 38.00, 1, 10, 0, 0),
	(90, '2024-08-21 23:16:18', NULL, 1, 38.00, 1, 10, 0, 0),
	(91, '2024-08-21 23:21:30', '2024-10-04 22:45:03', 1, 82805.00, 4, 13, 63263, 0),
	(92, '2024-08-21 23:23:06', '2024-10-04 22:42:21', 1, 82819.00, 3, 12, 63169, 0),
	(93, '2024-08-30 17:41:50', '2024-09-10 00:24:22', 1, 16586.00, 12, 21, 14746, 0),
	(96, '2024-08-31 00:33:39', '2024-09-10 00:24:30', 1, 16129.00, 11, 20, 14360, 0),
	(97, '2024-09-10 00:25:03', '2024-10-04 22:59:19', 3, 46700.00, 12, 21, 35884, 0),
	(98, '2024-09-10 02:02:11', '2024-10-04 22:55:26', 2, 46491.00, 9, 18, 35757, 0),
	(99, '2024-09-10 02:26:03', '2024-10-05 17:53:26', 4, 48012.00, 11, 20, 36927, 0),
	(100, '2024-10-05 18:37:21', '2024-10-05 18:39:07', 2, 46.00, 20, 29, 0, 0),
	(101, '2024-10-05 18:37:29', '2024-10-05 18:40:35', 2, 46.00, 2, 11, 0, 0),
	(102, '2024-10-05 18:37:51', '2024-10-07 20:26:36', 4, 3913.00, 19, 28, 2958, 0),
	(103, '2024-10-07 20:25:06', '2024-10-07 20:31:11', 1, 88.00, 17, 26, 0, 0),
	(104, '2024-10-07 21:12:02', '2024-10-07 21:13:17', 1, 481.00, 11, 20, 1, 0),
	(105, '2024-10-07 21:12:57', '2024-10-07 22:03:39', 1, 91.00, 17, 26, 20, 0),
	(106, '2024-10-07 22:06:27', '2024-10-07 22:07:51', 3, 22.00, 12, 21, 1, 0),
	(107, '2024-10-08 11:04:01', '2024-10-08 11:04:26', 1, 375.00, 8, 17, 0, 0),
	(108, '2024-10-08 11:08:13', '2024-10-08 11:16:31', 1, 45.00, 2, 11, 0, 0),
	(109, '2024-10-08 11:08:42', '2024-10-08 11:50:10', 3, 40.00, 3, 12, 11, 0),
	(110, '2024-10-08 11:09:13', '2024-10-08 11:18:48', 1, 11.00, 11, 20, 9, 0),
	(111, '2024-10-08 11:09:19', '2024-10-08 11:19:30', 1, 196.00, 11, 20, 0, 0),
	(112, '2024-10-08 13:04:19', NULL, 1, 65.00, 12, 21, 0, 1),
	(113, '2024-10-08 13:04:47', NULL, 1, 47.00, 13, 22, 0, 1),
	(114, '2024-10-08 13:05:10', '2024-10-08 13:05:18', 3, 346.00, 14, 23, 0, 0);

-- Volcando estructura para tabla ludotecadb.visita_hijo
CREATE TABLE IF NOT EXISTS `visita_hijo` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_Visita` int NOT NULL,
  `id_Hijo` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_Visita_Hijo_Visita_idx` (`id_Visita`),
  KEY `FK_Visita_Hijo_Hijo_idx` (`id_Hijo`),
  CONSTRAINT `FK_Visita_Hijo_Hijo` FOREIGN KEY (`id_Hijo`) REFERENCES `hijos` (`id`),
  CONSTRAINT `FK_Visita_Hijo_Visita` FOREIGN KEY (`id_Visita`) REFERENCES `visitas` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=109 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- Volcando datos para la tabla ludotecadb.visita_hijo: ~54 rows (aproximadamente)
INSERT IGNORE INTO `visita_hijo` (`id`, `id_Visita`, `id_Hijo`) VALUES
	(41, 49, 3),
	(42, 50, 1),
	(43, 51, 3),
	(44, 51, 1),
	(45, 52, 2),
	(46, 53, 28),
	(47, 54, 29),
	(48, 55, 30),
	(49, 56, 30),
	(50, 57, 30),
	(51, 58, 1),
	(52, 59, 3),
	(53, 60, 29),
	(54, 61, 1),
	(55, 62, 29),
	(56, 63, 2),
	(57, 64, 30),
	(58, 65, 30),
	(59, 66, 1),
	(60, 67, 3),
	(61, 67, 1),
	(62, 68, 3),
	(63, 68, 1),
	(64, 69, 1),
	(65, 70, 3),
	(66, 71, 1),
	(67, 71, 3),
	(68, 72, 1),
	(69, 73, 1),
	(70, 74, 3),
	(71, 75, 3),
	(72, 76, 3),
	(73, 77, 1),
	(74, 78, 1),
	(75, 79, 3),
	(76, 80, 1),
	(77, 81, 3),
	(78, 82, 1),
	(79, 83, 1),
	(80, 84, 3),
	(81, 86, 3),
	(82, 87, 1),
	(83, 88, 30),
	(84, 89, 30),
	(85, 90, 30),
	(86, 91, 30),
	(87, 92, 29),
	(88, 93, 30),
	(89, 96, 1),
	(90, 96, 3),
	(91, 97, 1),
	(92, 98, 1),
	(93, 98, 3),
	(94, 99, 1),
	(95, 100, 33),
	(96, 101, 33),
	(97, 102, 33),
	(98, 103, 1),
	(99, 104, 31),
	(100, 105, 31),
	(101, 106, 33),
	(102, 107, 30),
	(103, 108, 33),
	(104, 109, 31),
	(105, 111, 2),
	(106, 112, 28),
	(107, 113, 33),
	(108, 114, 31);
  
-- Volcando estructura para tabla ludotecadb.visita_producto
CREATE TABLE IF NOT EXISTS `visita_producto` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_Visita` int NOT NULL,
  `id_Producto` int NOT NULL,
  `precioProductoVisita` int DEFAULT NULL,
  `CantidadProductoVisita` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_Visita_Producto_Visita_idx` (`id_Visita`),
  KEY `FK_Visita_Producto_Producto_idx` (`id_Producto`),
  CONSTRAINT `FK_Visita_Producto_Producto` FOREIGN KEY (`id_Producto`) REFERENCES `productos` (`id`),
  CONSTRAINT `FK_Visita_Producto_Visita` FOREIGN KEY (`id_Visita`) REFERENCES `visitas` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=212 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- Volcando datos para la tabla ludotecadb.visita_producto: ~102 rows (aproximadamente)
INSERT IGNORE INTO `visita_producto` (`id`, `id_Visita`, `id_Producto`, `precioProductoVisita`, `CantidadProductoVisita`) VALUES
	(69, 49, 1, 10, 68),
	(70, 49, 2, 15, 25),
	(71, 50, 3, 1, 24),
	(72, 50, 4, 25, 37),
	(73, 51, 10, 150, 6),
	(74, 52, 2, 15, 25),
	(75, 53, 2, 15, 25),
	(76, 53, 1, 10, 68),
	(77, 53, 3, 1, 24),
	(78, 53, 4, 25, 37),
	(79, 54, 10, 150, 6),
	(80, 55, 9, 450, 9),
	(81, 55, 3, 1, 24),
	(82, 55, 2, 15, 25),
	(83, 55, 1, 10, 68),
	(84, 56, 10, 150, 6),
	(85, 56, 15, 23, 9),
	(86, 57, 1, 10, 68),
	(87, 57, 2, 15, 25),
	(88, 57, 3, 1, 24),
	(89, 57, 4, 25, 37),
	(90, 58, 9, 450, 9),
	(91, 58, 10, 150, 6),
	(92, 58, 15, 23, 9),
	(93, 60, 1, 10, 68),
	(94, 60, 2, 15, 25),
	(95, 60, 3, 1, 24),
	(96, 60, 4, 25, 37),
	(97, 61, 1, 10, 68),
	(98, 61, 2, 15, 25),
	(99, 61, 3, 1, 24),
	(100, 62, 4, 25, 37),
	(101, 63, 15, 23, 9),
	(102, 65, 3, 1, 24),
	(103, 66, 9, 450, 9),
	(104, 68, 4, 25, 37),
	(105, 68, 1, 10, 68),
	(106, 69, 2, 20, 40),
	(107, 69, 10, 150, 6),
	(108, 70, 9, 450, 9),
	(109, 71, 2, 20, 40),
	(110, 73, 1, 10, 3),
	(111, 73, 3, 1, 2),
	(112, 75, 1, 10, 1),
	(113, 76, 1, 10, 1),
	(114, 77, 2, 20, 2),
	(115, 77, 1, 10, 3),
	(116, 77, 2, 20, 1),
	(117, 77, 4, 25, 1),
	(118, 77, 10, 150, 3),
	(119, 77, 15, 23, 2),
	(120, 78, 2, 20, 1),
	(121, 78, 3, 1, 2),
	(122, 78, 4, 25, 1),
	(123, 78, 16, 48, 3),
	(124, 78, 17, 23, 2),
	(125, 78, 10, 150, 5),
	(126, 79, 2, 20, 3),
	(127, 79, 3, 1, 2),
	(128, 79, 17, 23, 4),
	(129, 80, 2, 20, 3),
	(130, 80, 4, 25, 4),
	(131, 80, 17, 23, 5),
	(132, 81, 2, 20, 1),
	(133, 81, 4, 25, 1),
	(134, 81, 9, 450, 1),
	(135, 82, 2, 20, 1),
	(136, 82, 3, 1, 3),
	(137, 82, 4, 25, 1),
	(138, 83, 2, 20, 1),
	(139, 84, 2, 20, 1),
	(140, 86, 2, 20, 1),
	(141, 86, 1, 10, 1),
	(142, 86, 2, 20, 1),
	(143, 86, 4, 25, 1),
	(144, 86, 3, 1, 1),
	(145, 86, 9, 450, 1),
	(146, 86, 10, 150, 1),
	(147, 86, 15, 23, 1),
	(148, 86, 16, 48, 1),
	(149, 86, 17, 23, 1),
	(150, 87, 1, 10, 1),
	(151, 88, 2, 20, 1),
	(152, 88, 3, 1, 3),
	(153, 89, 2, 20, 1),
	(154, 89, 3, 1, 3),
	(155, 90, 2, 20, 1),
	(156, 90, 3, 1, 3),
	(157, 91, 4, 25, 22),
	(158, 92, 9, 450, 1),
	(159, 93, 2, 20, 1),
	(160, 93, 4, 25, 1),
	(161, 93, 3, 1, 1),
	(162, 96, 2, 20, 1),
	(163, 96, 1, 10, 1),
	(164, 96, 3, 1, 1),
	(165, 97, 2, 20, 1),
	(166, 97, 4, 25, 1),
	(167, 97, 3, 1, 1),
	(168, 98, 3, 1, 1),
	(169, 98, 2, 20, 1),
	(170, 99, 1, 10, 1),
	(171, 100, 1, 10, 1),
	(172, 100, 2, 20, 1),
	(173, 100, 3, 1, 1),
	(174, 101, 1, 10, 1),
	(175, 101, 2, 20, 1),
	(176, 101, 3, 1, 1),
	(177, 102, 1, 10, 1),
	(178, 102, 2, 20, 1),
	(179, 102, 3, 1, 1),
	(180, 102, 4, 25, 1),
	(181, 103, 1, 10, 2),
	(182, 103, 3, 1, 3),
	(183, 103, 4, 25, 2),
	(184, 104, 2, 20, 1),
	(185, 104, 1, 10, 1),
	(186, 104, 9, 450, 1),
	(187, 105, 1, 10, 1),
	(188, 105, 2, 20, 2),
	(189, 106, 1, 10, 1),
	(190, 106, 2, 20, 1),
	(191, 106, 3, 1, 1),
	(192, 107, 1, 10, 2),
	(193, 107, 2, 20, 2),
	(194, 107, 10, 150, 1),
	(195, 108, 1, 10, 1),
	(196, 108, 2, 20, 1),
	(197, 109, 2, 20, 1),
	(198, 109, 3, 1, 1),
	(199, 111, 3, 1, 1),
	(200, 111, 2, 20, 1),
	(201, 111, 1, 10, 1),
	(202, 111, 10, 150, 1),
	(203, 112, 1, 10, 1),
	(204, 112, 2, 20, 1),
	(205, 113, 1, 10, 1),
	(206, 113, 2, 20, 1),
	(207, 113, 3, 1, 1),
	(208, 114, 1, 10, 1),
	(209, 114, 3, 1, 1),
	(210, 114, 2, 20, 1),
	(211, 114, 10, 150, 1);

-- Volcando estructura para tabla ludotecadb.visita_servicios
CREATE TABLE IF NOT EXISTS `visita_servicios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Visita_Id` int DEFAULT NULL,
  `Servicio_Id` int DEFAULT NULL,
  `Servicio_Precio` int DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_visita_Servicio_Visita_idx` (`Visita_Id`),
  KEY `fk_visita_Servicio_Servicio_idx` (`Servicio_Id`),
  CONSTRAINT `fk_visita_Servicio_Servicio` FOREIGN KEY (`Servicio_Id`) REFERENCES `servicios` (`id`),
  CONSTRAINT `fk_visita_Servicio_Visita` FOREIGN KEY (`Visita_Id`) REFERENCES `visitas` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=91 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- Volcando datos para la tabla ludotecadb.visita_servicios: ~48 rows (aproximadamente)
INSERT INTO `visita_servicios` (`id`, `Visita_Id`, `Servicio_Id`, `Servicio_Precio`) VALUES
	(30, 49, 3, 250),
	(31, 50, 4, 25),
	(32, 51, 3, 250),
	(33, 52, 2, 14),
	(34, 53, 1, 7),
	(35, 54, 4, 25),
	(36, 55, 3, 250),
	(37, 56, 4, 25),
	(38, 57, 6, 50),
	(39, 58, 6, 50),
	(40, 60, 2, 14),
	(41, 61, 7, 0),
	(42, 62, 1, 7),
	(43, 63, 1, 7),
	(44, 65, 7, 0),
	(45, 66, 3, 250),
	(46, 68, 3, 250),
	(47, 69, 3, 250),
	(48, 70, 1, 7),
	(49, 71, 1, 7),
	(50, 73, 2, 14),
	(51, 75, 1, 7),
	(52, 76, 2, 14),
	(53, 77, 2, 14),
	(54, NULL, 1, 7),
	(55, 77, 1, 7),
	(56, 77, 4, 25),
	(57, 77, 7, 0),
	(58, 78, 3, 250),
	(59, 79, 2, 14),
	(60, 80, 1, 7),
	(61, 81, 7, 0),
	(62, 82, 1, 15),
	(63, 83, 2, 14),
	(64, 84, 3, 250),
	(65, 86, 2, 14),
	(66, 87, 3, 250),
	(67, 88, 2, 14),
	(68, 89, 1, 15),
	(69, 90, 1, 15),
	(70, 91, 2, 14),
	(71, 92, 3, 250),
	(72, 93, 4, 25),
	(73, 96, 1, 15),
	(74, 97, 1, 15),
	(75, 98, 4, 25),
	(76, 99, 7, 0),
	(77, 100, 1, 15),
	(78, 101, 1, 15),
	(79, 102, 1, 15),
	(80, 103, 1, 15),
	(81, 104, 7, 0),
	(82, 105, 1, 15),
	(83, 106, 7, 0),
	(84, 107, 1, 15),
	(85, 108, 1, 15),
	(86, 109, 1, 15),
	(87, 111, 1, 15),
	(88, 112, 1, 15),
	(89, 113, 1, 15),
	(90, 114, 1, 15);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
