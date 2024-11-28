-- phpMyAdmin SQL Dump
-- version 4.9.11
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost
-- Tiempo de generación: 25-11-2024 a las 23:50:03
-- Versión del servidor: 5.7.36-log
-- Versión de PHP: 7.4.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `c2032404_jkids`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `configuracion`
--

CREATE TABLE `configuracion` (
  `id` int(11) NOT NULL,
  `ConfigName` varchar(45) DEFAULT NULL,
  `ConfigDescripcion` varchar(100) DEFAULT NULL,
  `ConfigStringValue` varchar(300) DEFAULT NULL,
  `ConfigBoolValue` tinyint(4) DEFAULT NULL,
  `ConfigIntValue` int(11) DEFAULT NULL,
  `ConfigDecimalValue` decimal(5,2) DEFAULT NULL,
  `status` int(11) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `configuracion`
--

INSERT INTO `configuracion` (`id`, `ConfigName`, `ConfigDescripcion`, `ConfigStringValue`, `ConfigBoolValue`, `ConfigIntValue`, `ConfigDecimalValue`, `status`) VALUES
(1, 'PrecioMinutoTreintaMin', 'Precio de minuto de la primera media hora de 0 - 35 mins', NULL, NULL, NULL, '2.60', 1),
(2, 'EdadMinima', 'Edad minima del niño(a)', NULL, NULL, 1, NULL, 1),
(3, 'EdadMaxima', 'Edad maxima del niño(a)', NULL, NULL, 15, NULL, 1),
(4, 'RutaTicket', 'Ruta del ticket', 'C:\\Casita de Molly', NULL, NULL, NULL, 1),
(5, 'PrecioNiñoAdicional', 'Precio para niño adicional para una fiesta', NULL, NULL, NULL, '400.00', 1),
(6, 'PrecioMinutoSesentaMin', 'Precio del minuto despues de 35 minutos', NULL, NULL, NULL, '2.21', 1),
(7, 'PrecioMinutoDespuesServicio', 'Precio del minuto despues de que se usó un servicio', NULL, NULL, NULL, '2.10', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `fiestas`
--

CREATE TABLE `fiestas` (
  `id` int(11) NOT NULL,
  `idServicio` int(11) DEFAULT NULL,
  `idTurno` int(11) DEFAULT NULL,
  `Fecha` date DEFAULT NULL,
  `Tematica` varchar(45) DEFAULT NULL,
  `EdadACumplir` int(11) DEFAULT NULL,
  `TipoComida` varchar(45) DEFAULT NULL,
  `NinosAdicionales` int(11) DEFAULT NULL,
  `Anticipo` decimal(8,0) DEFAULT '0',
  `Total` decimal(8,0) DEFAULT '0',
  `status` smallint(6) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `fiesta_hijo`
--

CREATE TABLE `fiesta_hijo` (
  `id` int(11) NOT NULL,
  `id_Fiesta` int(11) DEFAULT NULL,
  `id_Hijo` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gafetes`
--

CREATE TABLE `gafetes` (
  `id` int(11) NOT NULL,
  `Numero` int(11) NOT NULL,
  `Asignado` smallint(6) NOT NULL DEFAULT '0',
  `status` smallint(6) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `gafetes`
--

INSERT INTO `gafetes` (`id`, `Numero`, `Asignado`, `status`) VALUES
(1, 1, 0, 1),
(2, 2, 0, 1),
(3, 3, 0, 1),
(4, 4, 0, 1),
(5, 5, 0, 1),
(6, 6, 0, 1),
(7, 7, 0, 1),
(8, 8, 0, 1),
(9, 9, 0, 1),
(10, 10, 0, 1),
(11, 11, 0, 1),
(12, 12, 0, 1),
(13, 13, 0, 1),
(14, 14, 0, 1),
(15, 15, 0, 1),
(16, 16, 0, 1),
(17, 17, 0, 1),
(18, 18, 0, 1),
(19, 19, 0, 1),
(20, 20, 0, 1),
(21, 21, 0, 1),
(22, 22, 0, 1),
(23, 23, 0, 1),
(24, 24, 0, 1),
(25, 25, 0, 1),
(26, 26, 0, 1),
(27, 27, 0, 1),
(28, 28, 0, 1),
(29, 29, 0, 1),
(30, 30, 0, 1),
(31, 31, 0, 1),
(32, 32, 0, 1),
(33, 33, 0, 1),
(34, 34, 0, 1),
(35, 35, 0, 1),
(36, 36, 0, 1),
(37, 37, 0, 1),
(38, 38, 0, 1),
(39, 39, 0, 1),
(40, 40, 0, 1),
(41, 41, 0, 1),
(42, 42, 0, 1),
(43, 43, 0, 1),
(44, 44, 0, 1),
(45, 45, 0, 1),
(46, 46, 0, 1),
(47, 47, 0, 1),
(48, 48, 0, 1),
(49, 49, 0, 1),
(50, 50, 0, 1),
(51, 51, 0, 1),
(52, 52, 0, 1),
(53, 53, 0, 1),
(54, 54, 0, 1),
(55, 55, 0, 1),
(56, 56, 0, 1),
(57, 57, 0, 1),
(58, 58, 0, 1),
(59, 59, 0, 1),
(60, 60, 0, 1),
(61, 61, 0, 1),
(62, 62, 0, 1),
(63, 63, 0, 1),
(64, 64, 0, 1),
(65, 65, 0, 1),
(66, 66, 0, 1),
(67, 67, 0, 1),
(68, 68, 0, 1),
(69, 69, 0, 1),
(70, 70, 0, 1),
(71, 71, 0, 1),
(72, 72, 0, 1),
(73, 73, 0, 1),
(74, 74, 0, 1),
(75, 75, 0, 1),
(76, 76, 0, 1),
(77, 77, 0, 1),
(78, 78, 0, 1),
(79, 79, 0, 1),
(80, 80, 0, 1),
(81, 81, 0, 1),
(82, 82, 0, 1),
(83, 83, 0, 1),
(84, 84, 0, 1),
(85, 85, 0, 1),
(86, 86, 0, 1),
(87, 87, 0, 1),
(88, 88, 0, 1),
(89, 89, 0, 1),
(90, 90, 0, 1),
(91, 91, 0, 1),
(92, 92, 0, 1),
(93, 93, 0, 1),
(94, 94, 0, 1),
(95, 95, 0, 1),
(96, 96, 0, 1),
(97, 97, 0, 1),
(98, 98, 0, 1),
(99, 99, 0, 1),
(100, 100, 0, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `hijos`
--

CREATE TABLE `hijos` (
  `id` int(11) NOT NULL,
  `NombreHijo` varchar(45) DEFAULT NULL,
  `Papa` int(11) DEFAULT NULL,
  `Mama` int(11) DEFAULT NULL,
  `fechaNac` varchar(45) DEFAULT NULL,
  `status` smallint(6) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `hijos`
--

INSERT INTO `hijos` (`id`, `NombreHijo`, `Papa`, `Mama`, `fechaNac`, `status`) VALUES
(1, 'Lia Alejandra Ibarra Vazquez', 2, 3, '28/04/2023 12:00:00 a. m.', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `menu`
--

CREATE TABLE `menu` (
  `id` int(11) NOT NULL,
  `MenuName` varchar(45) DEFAULT NULL,
  `ClassName` varchar(45) DEFAULT NULL,
  `MenuOrder` smallint(6) DEFAULT NULL,
  `Path` varchar(45) DEFAULT NULL,
  `IconName` varchar(45) DEFAULT NULL,
  `status` int(11) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `menu`
--

INSERT INTO `menu` (`id`, `MenuName`, `ClassName`, `MenuOrder`, `Path`, `IconName`, `status`) VALUES
(1, 'Inventario', 'InventarioView', 3, 'Ludoteca.View.InventarioView', 'inventario_icon.jpg', 1),
(2, 'Visitas', 'VisitView', 2, 'Ludoteca.View.VisitView', 'visitas_icon.jpg', 1),
(3, 'Servicios', 'ServiciosView', 4, 'Ludoteca.View.ServiciosView', 'inventario_icon.jpg', 1),
(4, 'Configuracion', 'ConfiguracionView', 6, 'Ludoteca.View.ConfiguracionView', 'configuracion_icon.jpg', 1),
(5, 'Ofertas', 'OfertasView', 5, 'Ludoteca.View.OfertasView', 'inventario_icon.jpg', 1),
(6, 'Fiestas', 'FiestasView', 2, 'Ludoteca.View.FiestasView', 'fiesta_icon.jpg', 1),
(7, 'Reporte Visitas', 'ReporteVisitasView', 7, 'Ludoteca.View.ReporteVisitasView', 'inventario_icon.jpg', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ofertas`
--

CREATE TABLE `ofertas` (
  `id` int(11) NOT NULL,
  `OfertaName` varchar(45) DEFAULT NULL,
  `Descripcion` varchar(250) DEFAULT NULL,
  `Tiempo` int(11) DEFAULT NULL,
  `totalDescuento` double DEFAULT NULL,
  `status` smallint(6) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `ofertas`
--

INSERT INTO `ofertas` (`id`, `OfertaName`, `Descripcion`, `Tiempo`, `totalDescuento`, `status`) VALUES
(1, 'Sin Oferta', 'Sin oferta asignada', 0, 0, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `padres`
--

CREATE TABLE `padres` (
  `id` int(11) NOT NULL,
  `PadreName` varchar(45) DEFAULT NULL,
  `Address` varchar(105) DEFAULT NULL,
  `Telefono` varchar(45) DEFAULT NULL,
  `status` smallint(6) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `padres`
--

INSERT INTO `padres` (`id`, `PadreName`, `Address`, `Telefono`, `status`) VALUES
(0, 'Sin padre/Madre Asignado', '', '0', 1),
(2, 'Kevin Daryl Ibarra Sandoval', 'Calle Camelias # 233, flor de abril, Guacamayas, Michoacán', '7531420527', 1),
(3, 'Alejandrina Vazquez Gil', 'Calle Camelias # 233, flor de abril, Guacamayas, Michoacán', '7531679414', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos`
--

CREATE TABLE `productos` (
  `id` int(11) NOT NULL,
  `ProductoName` varchar(45) DEFAULT NULL,
  `Cantidad` int(11) DEFAULT '0',
  `Precio` decimal(8,2) DEFAULT NULL,
  `status` smallint(6) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `productos`
--

INSERT INTO `productos` (`id`, `ProductoName`, `Cantidad`, `Precio`, `status`) VALUES
(1, 'Sin Producto', 99999999, '0.00', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `rol`
--

CREATE TABLE `rol` (
  `id` int(11) NOT NULL,
  `RolName` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='		';

--
-- Volcado de datos para la tabla `rol`
--

INSERT INTO `rol` (`id`, `RolName`, `status`) VALUES
(1, 'Administrador', '1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `rol_menu`
--

CREATE TABLE `rol_menu` (
  `id` int(11) NOT NULL,
  `id_Rol` int(11) NOT NULL,
  `id_Menu` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `rol_menu`
--

INSERT INTO `rol_menu` (`id`, `id_Rol`, `id_Menu`) VALUES
(1, 1, 1),
(2, 1, 2),
(3, 1, 3),
(4, 1, 4),
(5, 1, 5),
(6, 1, 6),
(7, 1, 7);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `servicios`
--

CREATE TABLE `servicios` (
  `id` int(11) NOT NULL,
  `ServicioName` varchar(400) DEFAULT NULL,
  `Descripcion` text,
  `Precio` decimal(8,2) DEFAULT NULL,
  `Tiempo` int(11) DEFAULT NULL,
  `IdTipoServicio` int(11) DEFAULT NULL,
  `status` smallint(6) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `servicios`
--

INSERT INTO `servicios` (`id`, `ServicioName`, `Descripcion`, `Precio`, `Tiempo`, `IdTipoServicio`, `status`) VALUES
(1, 'Tiempo Libre', 'Este servicio esta destinado a cobrar el minuto en base al tiempo dentro', '0.00', 0, 1, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tickets`
--

CREATE TABLE `tickets` (
  `id` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `idvisita` int(11) DEFAULT NULL,
  `fecha_creacion` varchar(50) DEFAULT NULL,
  `ruta` varchar(300) DEFAULT NULL,
  `status` int(11) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tiposervicio`
--

CREATE TABLE `tiposervicio` (
  `id` int(11) NOT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  `status` smallint(6) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tiposervicio`
--

INSERT INTO `tiposervicio` (`id`, `nombre`, `status`) VALUES
(1, 'Visita', 1),
(2, 'Fiesta', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `turnos`
--

CREATE TABLE `turnos` (
  `id` int(11) NOT NULL,
  `NombreTurno` varchar(45) DEFAULT NULL,
  `status` smallint(6) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `turnos`
--

INSERT INTO `turnos` (`id`, `NombreTurno`, `status`) VALUES
(1, 'Matutino', 1),
(2, 'Vespertino', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `UserName` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `idRol` int(11) DEFAULT NULL,
  `status` smallint(6) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `users`
--

INSERT INTO `users` (`id`, `UserName`, `Password`, `idRol`, `status`) VALUES
(1, 'Administrator', 'JustKidAdmin', 1, 1),
(2, 'PerlaAyala', 'Molly_2310', 1, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `visitas`
--

CREATE TABLE `visitas` (
  `id` int(11) NOT NULL,
  `HoraEntrada` datetime NOT NULL,
  `HoraSalida` datetime DEFAULT NULL,
  `Oferta` int(11) NOT NULL,
  `Total` decimal(8,2) NOT NULL DEFAULT '0.00',
  `GafeteId` int(11) DEFAULT NULL,
  `NumeroGafete` int(11) DEFAULT NULL,
  `TiempoExcedido` int(11) DEFAULT '0',
  `TiempoTotal` int(11) DEFAULT '0',
  `status` smallint(6) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `visita_hijo`
--

CREATE TABLE `visita_hijo` (
  `id` int(11) NOT NULL,
  `id_Visita` int(11) NOT NULL,
  `id_Hijo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `visita_producto`
--

CREATE TABLE `visita_producto` (
  `id` int(11) NOT NULL,
  `id_Visita` int(11) NOT NULL,
  `id_Producto` int(11) NOT NULL,
  `precioProductoVisita` int(11) DEFAULT NULL,
  `CantidadProductoVisita` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `visita_servicios`
--

CREATE TABLE `visita_servicios` (
  `id` int(11) NOT NULL,
  `Visita_Id` int(11) DEFAULT NULL,
  `Servicio_Id` int(11) DEFAULT NULL,
  `Servicio_Precio` int(11) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `configuracion`
--
ALTER TABLE `configuracion`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `fiestas`
--
ALTER TABLE `fiestas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_Fiesta_Servicio_idx` (`idServicio`),
  ADD KEY `fk_Fiesta_Turno_idx` (`idTurno`);

--
-- Indices de la tabla `fiesta_hijo`
--
ALTER TABLE `fiesta_hijo`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_Fiesta_Fiesta_idx` (`id_Fiesta`),
  ADD KEY `fk_Fiesta_Hijo_idx` (`id_Hijo`);

--
-- Indices de la tabla `gafetes`
--
ALTER TABLE `gafetes`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `hijos`
--
ALTER TABLE `hijos`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_Hijo_Papa_idx` (`Papa`),
  ADD KEY `fk_Hijo_Mama_idx` (`Mama`);

--
-- Indices de la tabla `menu`
--
ALTER TABLE `menu`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `ofertas`
--
ALTER TABLE `ofertas`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `padres`
--
ALTER TABLE `padres`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `productos`
--
ALTER TABLE `productos`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `rol`
--
ALTER TABLE `rol`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `rol_menu`
--
ALTER TABLE `rol_menu`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_Rol_Menu_Rol_idx` (`id_Rol`),
  ADD KEY `FK_Rol_Menu_Menu_idx` (`id_Menu`);

--
-- Indices de la tabla `servicios`
--
ALTER TABLE `servicios`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_Servicio_TipoServicio_idx` (`IdTipoServicio`);

--
-- Indices de la tabla `tickets`
--
ALTER TABLE `tickets`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_tickets_visitas` (`idvisita`);

--
-- Indices de la tabla `tiposervicio`
--
ALTER TABLE `tiposervicio`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `turnos`
--
ALTER TABLE `turnos`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_User_Rol_idx` (`idRol`);

--
-- Indices de la tabla `visitas`
--
ALTER TABLE `visitas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_Visita_Oferta_idx` (`Oferta`),
  ADD KEY `fk_Gafete_Oferta_idx` (`GafeteId`);

--
-- Indices de la tabla `visita_hijo`
--
ALTER TABLE `visita_hijo`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_Visita_Hijo_Visita_idx` (`id_Visita`),
  ADD KEY `FK_Visita_Hijo_Hijo_idx` (`id_Hijo`);

--
-- Indices de la tabla `visita_producto`
--
ALTER TABLE `visita_producto`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_Visita_Producto_Visita_idx` (`id_Visita`),
  ADD KEY `FK_Visita_Producto_Producto_idx` (`id_Producto`);

--
-- Indices de la tabla `visita_servicios`
--
ALTER TABLE `visita_servicios`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_visita_Servicio_Visita_idx` (`Visita_Id`),
  ADD KEY `fk_visita_Servicio_Servicio_idx` (`Servicio_Id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `configuracion`
--
ALTER TABLE `configuracion`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de la tabla `fiestas`
--
ALTER TABLE `fiestas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `fiesta_hijo`
--
ALTER TABLE `fiesta_hijo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `gafetes`
--
ALTER TABLE `gafetes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=101;

--
-- AUTO_INCREMENT de la tabla `hijos`
--
ALTER TABLE `hijos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `menu`
--
ALTER TABLE `menu`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de la tabla `ofertas`
--
ALTER TABLE `ofertas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `padres`
--
ALTER TABLE `padres`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `productos`
--
ALTER TABLE `productos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `rol`
--
ALTER TABLE `rol`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `rol_menu`
--
ALTER TABLE `rol_menu`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de la tabla `servicios`
--
ALTER TABLE `servicios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `tickets`
--
ALTER TABLE `tickets`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tiposervicio`
--
ALTER TABLE `tiposervicio`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `turnos`
--
ALTER TABLE `turnos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `visitas`
--
ALTER TABLE `visitas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `visita_hijo`
--
ALTER TABLE `visita_hijo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `visita_producto`
--
ALTER TABLE `visita_producto`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `visita_servicios`
--
ALTER TABLE `visita_servicios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `fiestas`
--
ALTER TABLE `fiestas`
  ADD CONSTRAINT `fk_Fiesta_Servicio` FOREIGN KEY (`idServicio`) REFERENCES `servicios` (`id`),
  ADD CONSTRAINT `fk_Fiesta_Turno` FOREIGN KEY (`idTurno`) REFERENCES `turnos` (`id`);

--
-- Filtros para la tabla `fiesta_hijo`
--
ALTER TABLE `fiesta_hijo`
  ADD CONSTRAINT `fk_Fiesta_Fiesta` FOREIGN KEY (`id_Fiesta`) REFERENCES `fiestas` (`id`),
  ADD CONSTRAINT `fk_Fiesta_Hijo` FOREIGN KEY (`id_Hijo`) REFERENCES `hijos` (`id`);

--
-- Filtros para la tabla `hijos`
--
ALTER TABLE `hijos`
  ADD CONSTRAINT `fk_Hijo_Mama` FOREIGN KEY (`Mama`) REFERENCES `padres` (`id`),
  ADD CONSTRAINT `fk_Hijo_Papa` FOREIGN KEY (`Papa`) REFERENCES `padres` (`id`) ON UPDATE SET NULL;

--
-- Filtros para la tabla `rol_menu`
--
ALTER TABLE `rol_menu`
  ADD CONSTRAINT `FK_Rol_Menu_Menu` FOREIGN KEY (`id_Menu`) REFERENCES `menu` (`id`),
  ADD CONSTRAINT `FK_Rol_Menu_Rol` FOREIGN KEY (`id_Rol`) REFERENCES `rol` (`id`);

--
-- Filtros para la tabla `servicios`
--
ALTER TABLE `servicios`
  ADD CONSTRAINT `fk_Servicio_TipoServicio` FOREIGN KEY (`IdTipoServicio`) REFERENCES `tiposervicio` (`id`);

--
-- Filtros para la tabla `tickets`
--
ALTER TABLE `tickets`
  ADD CONSTRAINT `FK_tickets_visitas` FOREIGN KEY (`idvisita`) REFERENCES `visitas` (`id`);

--
-- Filtros para la tabla `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `fk_User_Rol` FOREIGN KEY (`idRol`) REFERENCES `rol` (`id`);

--
-- Filtros para la tabla `visitas`
--
ALTER TABLE `visitas`
  ADD CONSTRAINT `fk_Visita_Gafete` FOREIGN KEY (`GafeteId`) REFERENCES `gafetes` (`id`),
  ADD CONSTRAINT `fk_Visita_Oferta` FOREIGN KEY (`Oferta`) REFERENCES `ofertas` (`id`);

--
-- Filtros para la tabla `visita_hijo`
--
ALTER TABLE `visita_hijo`
  ADD CONSTRAINT `FK_Visita_Hijo_Hijo` FOREIGN KEY (`id_Hijo`) REFERENCES `hijos` (`id`),
  ADD CONSTRAINT `FK_Visita_Hijo_Visita` FOREIGN KEY (`id_Visita`) REFERENCES `visitas` (`id`);

--
-- Filtros para la tabla `visita_producto`
--
ALTER TABLE `visita_producto`
  ADD CONSTRAINT `FK_Visita_Producto_Producto` FOREIGN KEY (`id_Producto`) REFERENCES `productos` (`id`),
  ADD CONSTRAINT `FK_Visita_Producto_Visita` FOREIGN KEY (`id_Visita`) REFERENCES `visitas` (`id`);

--
-- Filtros para la tabla `visita_servicios`
--
ALTER TABLE `visita_servicios`
  ADD CONSTRAINT `fk_visita_Servicio_Servicio` FOREIGN KEY (`Servicio_Id`) REFERENCES `servicios` (`id`),
  ADD CONSTRAINT `fk_visita_Servicio_Visita` FOREIGN KEY (`Visita_Id`) REFERENCES `visitas` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
