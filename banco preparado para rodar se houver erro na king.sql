-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           5.0.45-community-nt - MySQL Community Edition (GPL)
-- OS do Servidor:               Win32
-- HeidiSQL Versão:              9.1.0.4867
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Copiando estrutura do banco de dados para lojacarros
CREATE DATABASE IF NOT EXISTS `enriqueautomov01` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `enriqueautomov01`;

-- Copiando estrutura para tabela lojacarros.Tipo
CREATE TABLE IF NOT EXISTS `Tipo` (
  `IdTipo` int(11) NOT NULL auto_increment,
  `Nome` varchar(50) NOT NULL,
  PRIMARY KEY  (`IdTipo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela lojacarros.Tipo: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `Tipo` DISABLE KEYS */;
INSERT INTO `Tipo` (`IdTipo`, `Nome`) VALUES
	(1, 'Carro'),
	(2, 'Moto');
/*!40000 ALTER TABLE `Tipo` ENABLE KEYS */;


-- Copiando estrutura para tabela lojacarros.Usuario
CREATE TABLE IF NOT EXISTS `Usuario` (
  `IdUsuario` int(11) NOT NULL auto_increment,
  `Email` varchar(50) NOT NULL,
  `Senha` varchar(100) NOT NULL,
  PRIMARY KEY  (`IdUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela lojacarros.Usuario: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `Usuario` DISABLE KEYS */;
INSERT INTO `Usuario` (`IdUsuario`, `Email`, `Senha`) VALUES
	(8, 'davifrancamaciel@hotmail.com', 'c2ad4d76fe97759aa27a0c99bff6710'),
	(13, 'davi', '86a08a8cd53357d3fb437a6810af55cc');
/*!40000 ALTER TABLE `Usuario` ENABLE KEYS */;


CREATE TABLE IF NOT EXISTS `Combustivel` (
  `IdCombustivel` int(11) NOT NULL auto_increment,
  `Nome` varchar(50) NOT NULL,
  PRIMARY KEY  (`IdCombustivel`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela lojacarros.Combustivel: ~10 rows (aproximadamente)
/*!40000 ALTER TABLE `Combustivel` DISABLE KEYS */;
INSERT INTO `Combustivel` (`IdCombustivel`, `Nome`) VALUES
	(1, 'GASOLINA'),
	(2, 'ALCOOL'),
	(3, 'FLEX'),
	(4, 'DIESEL'),
	(5, 'ETANOL'),
	(6, 'GASOLINA + GNV'),
	(7, 'ALCOOL + GNV'),
	(8, 'DIESEL + GNV'),
	(9, 'ETANOL + GNV'),
	(10, 'FLEX + GNV');
/*!40000 ALTER TABLE `Combustivel` ENABLE KEYS */;


-- Copiando estrutura para tabela lojacarros.Estado
CREATE TABLE IF NOT EXISTS `Estado` (
  `Sigla` varchar(2) NOT NULL,
  PRIMARY KEY  (`Sigla`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela lojacarros.Estado: ~27 rows (aproximadamente)
/*!40000 ALTER TABLE `Estado` DISABLE KEYS */;
INSERT INTO `Estado` (`Sigla`) VALUES
	('AC'),
	('AL'),
	('AM'),
	('AP'),
	('BA'),
	('CE'),
	('DF'),
	('ES'),
	('GO'),
	('MA'),
	('MG'),
	('MS'),
	('MT'),
	('PA'),
	('PB'),
	('PE'),
	('PI'),
	('PR'),
	('RJ'),
	('RN'),
	('RO'),
	('RR'),
	('RS'),
	('SC'),
	('SE'),
	('SP'),
	('TO');
/*!40000 ALTER TABLE `Estado` ENABLE KEYS */;




-- Copiando estrutura para tabela lojacarros.Cliente
CREATE TABLE IF NOT EXISTS `Cliente` (
  `IdCliente` int(11) NOT NULL auto_increment,
  `Estado` varchar(2) default '0',
  `Nome` varchar(50) NOT NULL,
  `Email` varchar(50) default NULL,
  `Telefone1` varchar(50) NOT NULL,
  `Telefone2` varchar(50) default NULL,
  `CEP` varchar(10) default NULL,
  `Logradouro` varchar(200) default NULL,
  `Bairro` varchar(50) default NULL,
  `Cidade` varchar(50) default NULL,
  `DataCadastro` datetime NOT NULL,
  PRIMARY KEY  (`IdCliente`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;




-- Copiando dados para a tabela lojacarros.Cliente: ~8 rows (aproximadamente)
/*!40000 ALTER TABLE `Cliente` DISABLE KEYS */;
INSERT INTO `Cliente` (`IdCliente`, `Estado`, `Nome`, `Email`, `Telefone1`, `Telefone2`, `CEP`, `Logradouro`, `Bairro`, `Cidade`, `DataCadastro`) VALUES
	(1, 'RJ', 'Pedro fagundes', 'davifrancamaciel@hotmail.com', '(24) 99395-4479', '(24) 9939-5447', '25615-071', 'Rua Elyzio Alves', 'Caxambu', 'Rua Elyzio Alves', '2015-09-23 17:54:15'),
	(2, 'RJ', 'DIARIO DE PETROPOLIS ', 'diario@gmail.com', '(24) 99395-4479', '(24) 9939-5447', '25685-330', 'Rua Irmãos D\'Ângelo', 'Centro', 'Petrópolis', '2015-12-11 12:10:07'),
	(3, 'PA', 'junior', 'junior@samclear.com.br', '(91) 32017-2664', '(22) 2222-2222', '66075-110', 'Rua Augusto Corrêa', 'Guamá', 'Belém', '2015-12-11 12:15:30'),
	(4, 'RJ', 'Davi França Maciel', 'davifrancamaciel@hotmail.com', '(24) 99395-4479', '(24) 9939-5447', '25615071', 'Rua Elyzio Alves', 'Caxambu', 'Petrópolis', '2015-12-23 09:14:09'),
	(5, 'RJ', 'Otavio Augusto', 'davifrancamaciel@hotmail.com', '(24) 99395-4479', '(24) 9939-5447', '25615-071', 'Rua Elyzio Alves', 'Caxambu', 'Petrópolis', '2015-12-28 20:21:01'),
	(7, 'PR', 'ze', 'ze@gmail.com', '(24) 99395-4479', '(24) 2245-2315', '80010-100', 'Avenida Visconde de Guarapuava', 'Centro', 'Curitiba', '2015-12-30 13:13:52'),
	(9, 'RJ', 'Raquel Alves Trannin Moreira', 'ze@gmail.com', '(24) 99395-4479', '(24) 9939-5447', '25615-071', 'Rua Elyzio Alves', 'Caxambu', 'Petrópolis', '2015-12-30 14:04:46'),
	(10, 'RJ', 'Maria da silva sauro', 'davifrancamaciel@hotmail.com', '(24) 99395-4479', '(24) 9939-5447', '25615-071', 'Rua Elyzio Alves', 'Caxambu', 'Petrópolis', '2016-01-20 23:08:56');
/*!40000 ALTER TABLE `Cliente` ENABLE KEYS */;


-- Copiando estrutura para tabela lojacarros.Combustivel


-- Copiando estrutura para tabela lojacarros.Foto
CREATE TABLE IF NOT EXISTS `Foto` (
  `IdFoto` int(11) NOT NULL auto_increment,
  `NomeAnterior` varchar(150) NOT NULL,
  `ExtensaoArquivo` varchar(50) NOT NULL,
  `TipoArquivo` varchar(50) NOT NULL,
  `Nome` varchar(150) NOT NULL,
  `IdVeiculo` int(11) NOT NULL,
  PRIMARY KEY  (`IdFoto`),
  KEY `IdVeiculo` (`IdVeiculo`),
  CONSTRAINT `IdVeiculos` FOREIGN KEY (`IdVeiculo`) REFERENCES `Veiculo` (`IdVeiculo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela lojacarros.Foto: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `Foto` DISABLE KEYS */;
/*!40000 ALTER TABLE `Foto` ENABLE KEYS */;


-- Copiando estrutura para tabela lojacarros.Marca
CREATE TABLE IF NOT EXISTS `Marca` (
  `IdMarca` int(11) NOT NULL auto_increment,
  `Nome` varchar(50) NOT NULL,
  `IdTipo` int(11) NOT NULL,
  `DataCadastro` datetime default NULL,
  PRIMARY KEY  (`IdMarca`),
  KEY `IdTipo` (`IdTipo`),
  CONSTRAINT `IdTipo` FOREIGN KEY (`IdTipo`) REFERENCES `Tipo` (`IdTipo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela lojacarros.Marca: ~14 rows (aproximadamente)
/*!40000 ALTER TABLE `Marca` DISABLE KEYS */;
INSERT INTO `Marca` (`IdMarca`, `Nome`, `IdTipo`, `DataCadastro`) VALUES
	(1, 'GM-CHEVROLET', 1, '2015-10-22 12:18:45'),
	(2, 'FIAT', 1, '2015-09-22 11:13:50'),
	(4, 'VOLKSWAGEN', 1, '2015-09-22 11:13:50'),
	(6, 'YAMAHA', 2, '2015-09-22 11:13:50'),
	(7, 'HONDA', 2, '2015-09-22 11:13:50'),
	(8, 'PEUGEOT', 1, '2015-09-22 11:13:50'),
	(10, 'HONDA', 1, '2015-09-22 11:13:50'),
	(15, 'trax', 2, '2015-09-22 11:13:50'),
	(17, 'KAVASAKI', 2, '2015-09-22 11:13:50'),
	(22, 'sundown', 2, '2015-09-22 11:13:50'),
	(24, 'FORD', 1, '2015-11-14 11:13:34'),
	(25, 'kia', 1, '2015-11-14 11:28:12'),
	(26, 'renaut', 1, '2015-11-18 15:07:16'),
	(27, 'citroën', 1, '2016-01-15 09:13:39');
/*!40000 ALTER TABLE `Marca` ENABLE KEYS */;

















-- Copiando estrutura para tabela lojacarros.Veiculo
CREATE TABLE IF NOT EXISTS `Veiculo` (
  `IdVeiculo` int(11) NOT NULL auto_increment,
  `AnoFabricacao` int(4) NOT NULL,
  `AnoModelo` int(4) NOT NULL,
  `Ativo` int(1) NOT NULL,
  `Destaque` int(1) NOT NULL,
  `Descricao` varchar(4000) NOT NULL,
  `Modelo` varchar(50) NOT NULL,
  `DataCadastro` datetime NOT NULL,
  `Valor` decimal(10,0) default NULL,
  `IdMarca` int(11) NOT NULL,
  `QtdAcesso` int(11) default NULL,
  `IdCombustivel` int(11) NOT NULL,
  PRIMARY KEY  (`IdVeiculo`),
  KEY `IdMarca` (`IdMarca`),
  KEY `IdCombustivel` (`IdCombustivel`),
  CONSTRAINT `IdCombustivel` FOREIGN KEY (`IdCombustivel`) REFERENCES `Combustivel` (`IdCombustivel`),
  CONSTRAINT `IdMarca` FOREIGN KEY (`IdMarca`) REFERENCES `Marca` (`IdMarca`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=132 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela lojacarros.Veiculo: ~33 rows (aproximadamente)
/*!40000 ALTER TABLE `Veiculo` DISABLE KEYS */;
INSERT INTO `Veiculo` (`IdVeiculo`, `AnoFabricacao`, `AnoModelo`, `Ativo`, `Destaque`, `Descricao`, `Modelo`, `DataCadastro`, `Valor`, `IdMarca`, `QtdAcesso`, `IdCombustivel`) VALUES
	(90, 1995, 1995, 1, 0, 'Branca Bom Estado de conservação poco rodada. Documentos ok.', 'kombi', '2015-11-14 11:10:19', 9500, 4, NULL, 1),
	(91, 2003, 2003, 1, 0, 'Preto completo com rodas de liga leve e  para-choques na cor do carro.', 'Ka', '2015-11-14 11:14:56', 7500, 24, NULL, 1),
	(92, 1999, 1999, 1, 0, 'Vidros elétricos pneus novos', 'ka', '2015-11-14 11:17:24', 8000, 24, NULL, 1),
	(93, 1989, 1989, 1, 0, 'Grafite, rodas de liga leve, vidros elétricos.', 'kadet', '2015-11-14 11:19:14', 0, 1, NULL, 1),
	(94, 1995, 1995, 1, 0, 'GTI completo + teto solar preto e rodas de liga leve aro 15. ', 'Golf', '2015-11-14 11:20:48', 5000, 4, NULL, 6),
	(95, 2002, 2002, 1, 0, 'Branco completo rodas de liga leve.', 'astra-sedan', '2015-11-14 11:24:36', 12000, 1, NULL, 6),
	(96, 2002, 2002, 1, 0, 'Grafite, 4 portas + vidros elétricos, ar condicionado e alarme.', 'fiesta', '2015-11-14 11:26:04', 6500, 24, NULL, 6),
	(97, 1997, 1997, 1, 0, 'Cinza chumbo, 4 portas, pneus novos e vidros elétricos.', 'uno', '2015-11-14 11:27:56', 7000, 2, NULL, 1),
	(98, 1995, 1995, 1, 0, 'Prata, Pneus novos, estepe 0 Km, completa.', 'sportage', '2015-11-14 11:29:42', 11100, 25, NULL, 1),
	(101, 1996, 1996, 1, 0, 'Verde com ar condicionado.', 'blazer', '2015-11-14 11:34:58', 15700, 1, NULL, 6),
	(102, 1998, 1998, 1, 0, 'Azul, 4.3, V6, completa de tudo e cambio automático ', 'blazer', '2015-11-14 11:36:21', 14000, 1, NULL, 4),
	(103, 1999, 1999, 1, 0, 'Azul completo + Airbag', '406', '2015-11-14 11:38:00', 4000, 8, NULL, 6),
	(104, 2006, 2006, 1, 1, 'Branco 1.4 pneus novos rodas de liga leve completo', 'palio-weekend', '2015-11-14 11:39:37', 12000, 2, NULL, 6),
	(105, 2007, 2007, 1, 1, 'Prata, Pneus novos, 2 portas, vidros elétricos VHC 1.0, ar condicionado, Trava e alarme.', 'celta', '2015-11-14 11:41:38', 16000, 1, NULL, 1),
	(106, 2008, 2008, 1, 1, 'Prata, 4 Portas, pneus novos, completo 1.6', 'fox', '2015-11-14 11:42:43', 21000, 4, NULL, 1),
	(107, 2001, 2001, 1, 0, 'Prata completo 2.2 motor MPFI ', 'vectra-milenium', '2015-11-14 11:44:31', 12200, 1, NULL, 1),
	(109, 2008, 2008, 1, 1, 'completo 2 portas pneus novos 1.0 fire', 'palio-azul', '2015-11-16 09:01:15', 19500, 2, NULL, 3),
	(110, 2001, 2001, 1, 1, 'cinza chumbo LX completo cambio automático.', 'civic', '2015-11-16 09:02:35', 11600, 10, NULL, 1),
	(111, 2005, 2005, 1, 0, 'spirit com ar e trava. 1.0', 'celta-prata-2p', '2015-11-16 09:03:37', 10000, 1, NULL, 1),
	(112, 2004, 2004, 1, 1, 'preto completo sensor de ré rodas de liga leve estofado em couro  cambio manual.', '307-SW', '2015-11-16 09:05:26', 18000, 8, NULL, 1),
	(113, 2001, 2001, 1, 0, 'verde completo rodas de liga leve pneus novos.', 'palio-weekend', '2015-11-16 09:06:50', 14000, 2, NULL, 1),
	(114, 2011, 2011, 1, 1, 'Prata spirit 4 portas rodas de liga leve aro 15 de astra motor VHCE  completo com apenas 45.000 KMs e pneus novos.', 'celta-prata-4p', '2015-11-16 09:09:02', 15000, 1, NULL, 3),
	(115, 2002, 2002, 1, 0, 'Com baú e pouco rodada.', 'XT-600', '2015-11-13 18:33:39', 4500, 6, NULL, 1),
	(116, 2006, 2006, 1, 0, 'Com baixa KM e com cano coyote esportivo.', 'TWISTER', '2015-11-13 18:35:17', 3000, 7, NULL, 1),
	(117, 2001, 2001, 1, 0, 'Verde, Completa muito nova.', 'blazer', '2015-11-16 18:38:48', 17400, 1, NULL, 8),
	(118, 2005, 2005, 1, 1, 'Preto, Elite, 4 Portas, rodas de liga leve aro 17, pneus novos, estofado em couro, cambio automático, completo de tudo 2.0', 'astra-preto', '2015-11-16 18:47:48', 20000, 1, NULL, 3),
	(119, 2008, 2008, 1, 1, 'Top de linha, couro, automático, excelente Estado!', 'c4-pallas', '2016-01-15 09:15:56', 29500, 27, NULL, 1),
	(120, 2011, 2011, 1, 1, 'Teto panorâmico, Top de linha', '3008-GRIFFE', '2016-01-15 09:17:35', 55000, 8, NULL, 1),
	(121, 2008, 2008, 1, 1, 'CLASS Completo', 'FIESTA', '2016-01-15 09:18:47', 18900, 24, NULL, 3),
	(122, 2010, 2010, 1, 1, 'LTZ 1.4, completo, rodas de liga, pneus novos, único dono', 'AGILE', '2016-01-15 09:20:32', 25500, 1, NULL, 3),
	(123, 2005, 2005, 1, 0, 'Completo 1.6L', 'ECOSPORT-XLT', '2016-01-15 09:21:48', 14000, 24, NULL, 1),
	(124, 2007, 2007, 1, 1, 'Completo preto 1.6', 'ECOSPORT-XLS', '2016-01-15 09:23:22', 19000, 24, NULL, 3),
	(125, 2008, 2008, 1, 0, 'completa 1.6 ', 'parati-G-IV', '2016-01-15 09:26:02', 18000, 4, NULL, 10);
/*!40000 ALTER TABLE `Veiculo` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;











-- Copiando estrutura para tabela lojacarros.Arquivo
CREATE TABLE IF NOT EXISTS `Arquivo` (
  `IdArquivo` int(11) NOT NULL auto_increment,
  `Nome` varchar(100) NOT NULL,
  `NomeAnterior` varchar(100) NOT NULL,
  `Tamanho` varchar(10) NOT NULL,
  `DataCadastro` datetime NOT NULL,
  `IdVeiculo` int(11) default NULL,
  PRIMARY KEY  (`IdArquivo`),
  KEY `IdVeiculo` (`IdVeiculo`),
  CONSTRAINT `IdVeiculo` FOREIGN KEY (`IdVeiculo`) REFERENCES `Veiculo` (`IdVeiculo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=356 DEFAULT CHARSET=latin1;



-- Copiando dados para a tabela lojacarros.Arquivo: ~133 rows (aproximadamente)
/*!40000 ALTER TABLE `Arquivo` DISABLE KEYS */;
INSERT INTO `Arquivo` (`IdArquivo`, `Nome`, `NomeAnterior`, `Tamanho`, `DataCadastro`, `IdVeiculo`) VALUES
	(192, 'a9cfea03-7bf1-4539-aab5-7722d601a5c8.jpg', 'IMG_20151114_124600775.jpg', '1368543', '2015-11-16 12:15:22', 90),
	(193, 'bfb0fc10-93b8-4850-9e0e-1eeb52e83005.jpg', 'IMG_20151114_124612153.jpg', '1162980', '2015-11-16 12:15:30', 90),
	(194, '14a4a49c-2a31-4660-809a-4a9bb6df7145.jpg', 'IMG_20151114_124622778.jpg', '1260561', '2015-11-16 12:15:38', 90),
	(195, 'a220539f-0852-4fbc-8a9c-c4587ceaa35a.jpg', 'IMG_20151114_124716762.jpg', '1271585', '2015-11-16 12:17:43', 91),
	(196, '475eebba-9043-4b9f-80b3-a3e977114924.jpg', 'IMG_20151114_124637320.jpg', '1389256', '2015-11-16 12:18:20', 91),
	(197, '0f2bcbae-619f-4668-a211-b62da6506ac8.jpg', 'IMG_20151114_124657927.jpg', '1281769', '2015-11-16 12:18:27', 91),
	(198, 'ffd915de-0e69-4996-a982-5f18a4c91655.jpg', 'IMG_20151114_124734182.jpg', '1040516', '2015-11-16 12:18:34', 91),
	(199, '33818952-d665-46bc-a025-66f02808711f.jpg', 'IMG_20151114_124443335.jpg', '1412285', '2015-11-16 13:23:10', 92),
	(200, 'a3b7cd8e-c8e9-41fb-90b6-8a2613a1aa9c.jpg', 'IMG_20151114_124506167.jpg', '1184590', '2015-11-16 13:23:44', 92),
	(201, 'f961e218-3cf7-4f8b-9e00-d4dd475ab0b2.jpg', 'IMG_20151114_124516239.jpg', '1131497', '2015-11-16 13:23:51', 92),
	(202, '969a3d43-0c35-495c-85d3-f5451a017931.jpg', 'IMG_20151114_124527881.jpg', '1330005', '2015-11-16 13:23:59', 92),
	(203, 'a872fc8f-cc29-4fd6-a62a-9f65a3fff0f8.jpg', 'IMG_20151114_124802222.jpg', '1266082', '2015-11-16 13:24:42', 93),
	(204, 'b2aeaaf8-bcd9-4c27-8018-21d1c9526d15.jpg', 'IMG_20151114_124816207.jpg', '1337152', '2015-11-16 13:24:50', 93),
	(205, 'e696bf6e-4e72-4c8e-b132-ae234db658f0.jpg', 'IMG_20151114_124857378.jpg', '1257837', '2015-11-16 13:24:57', 93),
	(206, '8ff707e8-d6c7-4b68-a1ce-7f75300dab2c.jpg', 'IMG_20151114_124911458.jpg', '1149449', '2015-11-16 13:28:25', 94),
	(207, '08c64d9e-9937-4c50-95e1-e73785a5a35e.jpg', 'IMG_20151114_124941098.jpg', '1375379', '2015-11-16 13:28:33', 94),
	(208, '4ece3964-6640-424b-a3d3-b861cb683065.jpg', 'IMG_20151114_124953395.jpg', '1279498', '2015-11-16 13:28:40', 94),
	(209, 'ac75b5f9-0a1b-4a69-9736-be701a954dd4.jpg', 'IMG_20151114_125008220.jpg', '1239057', '2015-11-16 13:28:48', 94),
	(210, '33358765-483f-4a1b-a75c-334b7969f7ac.jpg', 'IMG_20151114_125826074.jpg', '1382966', '2015-11-16 14:02:24', 95),
	(211, '4a76f970-5af2-42f6-b9b8-1fd2f62c8fca.jpg', 'IMG_20151114_125837671.jpg', '1294166', '2015-11-16 14:02:52', 95),
	(212, '27380483-e702-4ae3-88af-e173deeb1ee2.jpg', 'IMG_20151114_125903485.jpg', '1099547', '2015-11-16 14:02:59', 95),
	(213, 'ad19a2c7-f772-46e4-bf5d-046e906bb03d.jpg', 'IMG_20151114_130029677.jpg', '1187318', '2015-11-16 14:03:06', 95),
	(214, '37e932d5-3b9a-4166-b218-adab98fcc2a9.jpg', 'IMG_20151114_130040487.jpg', '1114909', '2015-11-16 14:03:14', 95),
	(215, '582bd9d1-79d4-427a-b6e5-af19318b5c88.jpg', 'IMG_20151114_130319509.jpg', '1170191', '2015-11-16 14:03:58', 96),
	(216, '0f1ea03f-0292-4ea7-b643-f210b0239c1c.jpg', 'IMG_20151114_130329427.jpg', '1197528', '2015-11-16 14:04:55', 96),
	(217, 'a4485bff-0a33-44c2-b955-8310a60f7aa8.jpg', 'IMG_20151114_130422181.jpg', '1227823', '2015-11-16 14:05:02', 96),
	(218, '428e7066-c6d8-40f0-b1f3-52774f7b8f0b.jpg', 'IMG_20151114_131004639.jpg', '1317326', '2015-11-16 14:05:46', 97),
	(219, 'eb7dcde5-387d-4425-bcea-a60c5e991e47.jpg', 'IMG_20151114_131015459.jpg', '1281183', '2015-11-16 14:05:53', 97),
	(220, 'cd3ffd92-3561-40d5-9d86-67fe26b7387c.jpg', 'IMG_20151114_131026683.jpg', '1312867', '2015-11-16 14:06:01', 97),
	(221, '84bfa1ba-78a7-4c61-9a85-0c3c7e78099c.jpg', 'IMG_20151114_131040419.jpg', '1099195', '2015-11-16 14:06:08', 97),
	(224, '3464d67d-87ac-469e-a0c2-5289c87f1436.jpg', 'IMG_20151114_131647633.jpg', '1281607', '2015-11-16 14:07:17', 98),
	(225, '3d0f77bf-e29c-4d6f-95db-f9eacf020b94.jpg', 'IMG_20151114_131658480.jpg', '1130057', '2015-11-16 14:07:24', 98),
	(226, '030c6ca3-70f3-4074-9828-fde83f64bf4b.jpg', 'IMG_20151114_131851085.jpg', '1143526', '2015-11-16 14:07:31', 98),
	(227, '748421df-f50c-48c6-875f-5d2a4c707892.jpg', 'IMG_20151114_131856404.jpg', '1057190', '2015-11-16 14:07:39', 98),
	(228, '75db0423-25da-4c56-a0c6-d830c1ed7884.jpg', 'IMG_20151114_131631059.jpg', '1303344', '2015-11-16 14:08:31', 98),
	(229, 'ba0fb209-6630-43eb-aa9e-db52dd3320f6.jpg', 'IMG_20151114_132036497.jpg', '1339603', '2015-11-16 14:10:27', 102),
	(230, '90477773-496a-4db8-bc1f-2050fc42070f.jpg', 'IMG_20151114_131959687.jpg', '1338938', '2015-11-16 14:11:13', 102),
	(231, '39051dd7-b6d3-4751-a246-b5a316a0a72a.jpg', 'IMG_20151114_132011079.jpg', '1477288', '2015-11-16 14:11:21', 102),
	(233, 'f4b02e84-f38f-4005-8b18-d7f67cd1fbb0.jpg', 'IMG_20151114_131909704.jpg', '1277032', '2015-11-16 14:12:31', 103),
	(234, '87daac4e-4556-443d-9e29-96fd63fa15ea.jpg', 'IMG_20151114_131924961.jpg', '1226658', '2015-11-16 14:12:38', 103),
	(235, '9d279db6-c5d5-4a82-87e3-e4cabdbf6b86.jpg', 'IMG_20151114_132024447.jpg', '1181878', '2015-11-16 14:13:03', 102),
	(236, '019ff2e0-2f12-4772-8bbb-4f62c0f6c069.jpg', 'IMG_20151114_132108320.jpg', '1163014', '2015-11-16 14:14:37', 104),
	(237, 'f2c01b6c-32da-43a0-9233-23cb679cee5f.jpg', 'IMG_20151114_132138950.jpg', '1137713', '2015-11-16 14:14:44', 104),
	(238, 'c8bb0b0e-8de5-4cdd-a169-b7b775106d4f.jpg', 'IMG_20151114_132258156.jpg', '1179542', '2015-11-16 14:14:51', 104),
	(239, 'd79971f8-5169-4f45-b4ed-e5e5bf6045d0.jpg', 'IMG_20151114_132313061.jpg', '1226429', '2015-11-16 14:14:59', 104),
	(240, '131cda64-fbea-43b3-9daf-9ed77ff74c59.jpg', 'IMG_20151114_132405247.jpg', '1273700', '2015-11-16 14:15:06', 104),
	(242, 'fe64eb2f-c2bf-45e8-a317-81cb2ab3b735.jpg', 'IMG_20151114_123153089.jpg', '1165459', '2015-11-16 14:42:52', 111),
	(243, '484c3ef2-c758-4093-93b5-40bcf16773d3.jpg', 'IMG_20151114_123057027.jpg', '1069253', '2015-11-16 14:43:25', 111),
	(244, 'd917d39f-bcc7-4837-873b-a884b5ccc97f.jpg', 'IMG_20151114_123129118.jpg', '1137503', '2015-11-16 14:43:32', 111),
	(245, 'e212c31c-f82d-4f3b-aaa7-dbed676609f2.jpg', 'IMG_20151114_123257268.jpg', '1328608', '2015-11-16 14:43:40', 111),
	(246, '495951dc-6e72-40a5-910d-e1474bfe4c61.jpg', 'IMG_20151114_124040377.jpg', '1312197', '2015-11-16 14:44:19', 112),
	(247, '327f7ee4-cc7a-4efe-8090-185d8eaf0f64.jpg', 'IMG_20151114_124022803.jpg', '1324285', '2015-11-16 14:44:48', 112),
	(248, '0c7d7f38-14f5-48c3-845a-521703e6f610.jpg', 'IMG_20151114_124056567.jpg', '1297408', '2015-11-16 14:44:55', 112),
	(249, '803cc956-1320-4308-98d2-d0b4ed4c7b05.jpg', 'IMG_20151114_124107387.jpg', '1268467', '2015-11-16 14:45:02', 112),
	(250, '03f67df2-f59a-40b4-b40b-34de746664aa.jpg', 'IMG_20151114_124006998.jpg', '1271799', '2015-11-16 14:45:26', 112),
	(251, '23dadb28-067f-446e-a91d-b4dbf9a45716.jpg', 'IMG_20151114_124149686.jpg', '1465912', '2015-11-16 14:46:13', 113),
	(252, '507d8369-9979-4371-a5c4-21dd7967e923.jpg', 'IMG_20151114_124201185.jpg', '1454578', '2015-11-16 14:46:20', 113),
	(253, '57528f10-6a5e-4223-a76a-ede7337f44c2.jpg', 'IMG_20151114_124214759.jpg', '1267475', '2015-11-16 14:52:45', 113),
	(254, '21675256-4965-4a3e-b420-36b7a8f80aea.jpg', 'IMG_20151114_124230980.jpg', '1391739', '2015-11-16 14:52:52', 113),
	(255, '82c7021d-22c9-4e16-a165-e87e5453081a.jpg', 'IMG_20151114_120920816.jpg', '1358741', '2015-11-16 14:54:04', 114),
	(256, '6c10659d-f68b-4e34-95ec-be8713937305.jpg', 'IMG_20151114_120909205.jpg', '1327090', '2015-11-16 14:54:56', 114),
	(257, '6868b23e-47a2-4b96-a019-cb3512d0775c.jpg', 'IMG_20151114_120951658.jpg', '1118671', '2015-11-16 14:55:03', 114),
	(258, '4faa3035-fe6a-4b0e-abaa-dbd1747da03f.jpg', 'IMG_20151114_121005203.jpg', '1014501', '2015-11-16 14:55:11', 114),
	(259, '8a706354-f1cc-42bd-81b7-e6ee8787be88.jpg', 'IMG_20151114_121212402.jpg', '1341191', '2015-11-16 14:55:18', 114),
	(260, 'f97e10df-a8ab-4eeb-b0f9-b7a2ce9f1743.jpg', 'IMG_20151114_124306842.jpg', '1334445', '2015-11-16 14:56:24', 110),
	(261, '4ffb82c6-4765-4748-a220-c7486fef60bd.jpg', 'IMG_20151114_124352568.jpg', '1266912', '2015-11-16 14:56:32', 110),
	(262, '4e3f2df2-650b-46ac-9994-85ae4d2a47ba.jpg', 'IMG_20151114_124404301.jpg', '1248046', '2015-11-16 14:56:39', 110),
	(263, 'e756ef40-0576-42f0-b694-02fa5e8e19f2.jpg', 'IMG_20151114_124417233.jpg', '1213590', '2015-11-16 14:56:46', 110),
	(264, '444f2c42-4e5f-4f1e-8587-56d4afa8c9df.jpg', 'IMG_20151114_122605022.jpg', '1365877', '2015-11-16 14:57:49', 109),
	(265, '3da17b82-9644-4864-9e8f-276034a77217.jpg', 'IMG_20151114_122618893.jpg', '1205270', '2015-11-16 14:57:57', 109),
	(266, 'b91929da-31fd-4191-b9a2-d0bd9d4b6dad.jpg', 'IMG_20151114_122750669.jpg', '1442552', '2015-11-16 14:58:04', 109),
	(267, '7c051028-f703-4840-9674-bef7b70f672f.jpg', 'IMG_20151114_122815523.jpg', '1219005', '2015-11-16 14:58:11', 109),
	(268, '7ab89b40-2053-4f49-a3f4-875e31792323.jpg', 'IMG_20151114_122545766.jpg', '1220782', '2015-11-16 14:59:24', 109),
	(269, '58fe490e-5ebb-47fe-855b-a0f85399ac44.jpg', 'IMG_20151114_130906292.jpg', '1202726', '2015-11-16 18:18:53', 107),
	(270, '5fdd82e4-1c21-4404-a09f-8b3aa0c1c0a8.jpg', 'IMG_20151114_130914764.jpg', '1216710', '2015-11-16 18:19:01', 107),
	(271, '51f7813e-b282-498e-86a7-8ce101b95791.jpg', 'IMG_20151114_130620415.jpg', '1160445', '2015-11-16 18:19:32', 107),
	(272, 'd069f52e-1674-465a-a6b9-323695bd7b4b.jpg', 'IMG_20151114_130655833.jpg', '1142366', '2015-11-16 18:19:39', 107),
	(273, '1c91508b-647f-4d4d-ad14-4095a92cf33f.jpg', 'IMG_20151114_121254315.jpg', '1220260', '2015-11-16 18:20:23', 106),
	(274, '321b639a-a434-4994-8260-14cb98c99eea.jpg', 'IMG_20151114_121524642.jpg', '1079769', '2015-11-16 18:20:30', 106),
	(275, '34930a00-3304-434e-849a-1ec9651901ad.jpg', 'IMG_20151114_121426773.jpg', '1277133', '2015-11-16 18:21:07', 106),
	(276, '23265762-4392-4c77-bdc3-c5f695d9f1c8.jpg', 'IMG_20151114_122234289.jpg', '1049605', '2015-11-16 18:21:14', 106),
	(277, 'b5c72784-b1e1-4569-817c-48ac72542e59.jpg', 'IMG_20151114_132208762.jpg', '1324215', '2015-11-16 18:31:00', 105),
	(278, 'e487329f-38fa-435e-b3da-5959f85a393e.jpg', 'IMG_20151114_132156861.jpg', '1314293', '2015-11-16 18:31:54', 105),
	(279, 'b3a4c275-dd15-45c8-a0e6-650d16550f40.jpg', 'IMG_20151114_132222094.jpg', '1206900', '2015-11-16 18:32:01', 105),
	(280, '5f6b4e0e-c963-4fd6-b930-b00f196c69d4.jpg', 'IMG_20151114_132237045.jpg', '1395909', '2015-11-16 18:32:08', 105),
	(281, '852ef05c-1327-443c-aa46-77f9d1ed7742.jpg', 'IMG_20151114_132435313.jpg', '1129425', '2015-11-16 18:32:16', 105),
	(282, '067627d5-5055-4823-8560-beaf9ff1f19c.jpg', 'IMG_20151114_125512332.jpg', '1470696', '2015-11-16 18:34:05', 115),
	(283, 'c6956085-7a66-4858-848c-898204447e5b.jpg', 'IMG_20151114_125522525.jpg', '1270920', '2015-11-16 18:34:12', 115),
	(284, '42e7a5fe-4125-4def-b92d-c95230ffdd9c.jpg', 'IMG_20151114_125800706.jpg', '1374099', '2015-11-16 18:35:36', 116),
	(285, 'de4c9871-2c8f-4b17-8429-3e7323e9910b.jpg', 'IMG_20151114_125814923.jpg', '1465466', '2015-11-16 18:35:43', 116),
	(286, 'c7ec7a1f-558c-4911-8dbb-5ad54f32ca32.jpg', 'IMG_20151114_133122473.jpg', '1298297', '2015-11-16 18:39:08', 117),
	(287, 'fbd673df-c64f-44e6-b831-6d60f2694ede.jpg', 'IMG_20151114_132843039.jpg', '1079353', '2015-11-16 18:39:43', 117),
	(288, '016987d3-e9e6-4745-8c53-d5e1fbe7c721.jpg', 'IMG_20151114_132902775.jpg', '1465474', '2015-11-16 18:39:51', 117),
	(289, 'b81678d8-61ac-4a56-88d6-17dce943ddf5.jpg', 'IMG_20151114_132916027.jpg', '1246905', '2015-11-16 18:39:58', 117),
	(290, 'a6c2effc-8cbf-419a-bc8c-e325b165172c.jpg', 'IMG_20151114_120649743.jpg', '1458758', '2015-11-16 18:48:17', 118),
	(291, 'f51f4fc2-49a8-4ccf-9ccd-5062460f064a.jpg', 'IMG_20151114_120705232.jpg', '1177955', '2015-11-16 18:49:07', 118),
	(292, '2772275e-8944-4db2-b61d-3b8324ce3114.jpg', 'IMG_20151114_120800861.jpg', '1390864', '2015-11-16 18:49:14', 118),
	(293, '1cad284c-189f-4309-97c0-ce6668ef2ef7.jpg', 'IMG_20151114_120811830.jpg', '1262112', '2015-11-16 18:49:22', 118),
	(294, 'bd73a161-b8f4-43c0-85e0-e72b4a9d9aca.jpg', 'IMG_20151114_120830783.jpg', '1057213', '2015-11-16 18:49:29', 118),
	(295, 'ad2591b1-3937-4c35-83f4-18357457fbfd.jpg', 'IMG_20160107_094831418.jpg', '1374180', '2016-01-15 09:16:35', 119),
	(296, 'c662d074-d440-47dc-8297-9a5be7e68492.jpg', 'IMG_20160107_094841766.jpg', '1344836', '2016-01-15 09:16:37', 119),
	(297, '7c808be2-945b-408d-b2c9-990a8731e90b.jpg', 'IMG_20160107_094854387_HDR.jpg', '1234703', '2016-01-15 09:16:37', 119),
	(298, 'baf8226b-d26e-4e25-b0ee-b17cb84d71ad.jpg', 'IMG_20160107_094858994.jpg', '1198032', '2016-01-15 09:16:38', 119),
	(299, '22e21f08-42a4-44e8-b0f9-88729c476655.jpg', 'IMG_20160107_094912784.jpg', '1346916', '2016-01-15 09:16:38', 119),
	(300, 'cda4817b-7fd1-4ca9-9ece-9967dc031885.jpg', 'IMG_20160107_094920886.jpg', '1251963', '2016-01-15 09:16:38', 119),
	(301, '1e6e6343-6c76-418f-a2f9-f3abc4221e73.jpg', 'IMG_20160107_093401289.jpg', '1183375', '2016-01-15 09:17:51', 120),
	(302, '2f7979c4-6521-460f-ae0d-a67d522badca.jpg', 'IMG_20160107_093417996.jpg', '1284553', '2016-01-15 09:17:52', 120),
	(303, 'e8f31947-1262-4214-9ded-8c7e075c77a0.jpg', 'IMG_20160107_093433609.jpg', '1031589', '2016-01-15 09:17:53', 120),
	(304, '0410e95d-b971-41d5-9fca-0003708be9f2.jpg', 'IMG_20160107_093439267.jpg', '1093119', '2016-01-15 09:17:53', 120),
	(305, '282a03c6-ad57-4cfb-995c-0aa6d4130ec8.jpg', 'IMG_20160107_093539403.jpg', '1300381', '2016-01-15 09:17:53', 120),
	(306, 'e1b43bd7-7d1e-47d5-bf65-e92d3ae66139.jpg', 'IMG_20160107_093600517.jpg', '1237805', '2016-01-15 09:17:54', 120),
	(307, '9ed65db3-ef29-4e3d-96f8-b1ffb5861c53.jpg', 'IMG_20160107_093852497_HDR.jpg', '1221048', '2016-01-15 09:19:04', 121),
	(308, 'c5558fd1-d96a-46e2-89e3-233fc08e2203.jpg', 'IMG_20160107_093908256_HDR.jpg', '1295876', '2016-01-15 09:19:05', 121),
	(309, 'aff8434e-9fbe-41ef-b1b3-5786d1088fa7.jpg', 'IMG_20160107_093934527.jpg', '1206456', '2016-01-15 09:19:05', 121),
	(310, '8d490bac-b70a-43dd-b9dc-dbe5337f3654.jpg', 'IMG_20160107_094159509_HDR.jpg', '1134334', '2016-01-15 09:19:06', 121),
	(311, '6a6177ed-fac5-475e-9392-b353f698e80a.jpg', 'IMG_20160107_093618414_HDR.jpg', '1339664', '2016-01-15 09:20:46', 122),
	(312, 'c711633f-339d-47e1-98ac-1b33822288d2.jpg', 'IMG_20160107_093633743.jpg', '1399925', '2016-01-15 09:20:47', 122),
	(313, '13a585ab-0607-4518-b101-a8fe508ce076.jpg', 'IMG_20160107_093650572_HDR.jpg', '1175551', '2016-01-15 09:20:47', 122),
	(314, '674134f1-ca81-4383-9b5f-93d0b63038b2.jpg', 'IMG_20160107_093659978.jpg', '1186670', '2016-01-15 09:20:48', 122),
	(315, '7cb6f75a-157a-4a6a-af05-3ecb17db2296.jpg', 'IMG_20160107_093757395_HDR.jpg', '1545052', '2016-01-15 09:20:48', 122),
	(316, 'b0945b31-4b5b-4c97-b0a2-2d0f7be905c1.jpg', 'IMG_20160107_094632268_HDR.jpg', '1143263', '2016-01-15 09:22:03', 123),
	(317, '24658a6c-4e61-49c5-a820-4fe9bf4d1dea.jpg', 'IMG_20160107_094646078.jpg', '1314332', '2016-01-15 09:22:04', 123),
	(318, '82f8e422-31ae-4632-8e75-e8f1c0e19f6c.jpg', 'IMG_20160107_094655821_HDR.jpg', '1252349', '2016-01-15 09:22:05', 123),
	(319, '2acb7bc0-1c4a-473c-9add-0ec8ec700558.jpg', 'IMG_20160107_094713174.jpg', '1255947', '2016-01-15 09:22:05', 123),
	(320, '336bda44-172b-4856-ae08-d9a28376df5d.jpg', 'IMG_20160107_094739902.jpg', '1270040', '2016-01-15 09:22:06', 123),
	(321, 'a060c309-bfc0-43f7-bf9e-fcc1e80bdd11.jpg', 'IMG_20160107_095122323_HDR.jpg', '1244673', '2016-01-15 09:23:40', 124),
	(322, 'e4c312bc-355e-4dc4-9bbb-2fbf78b9d6b6.jpg', 'IMG_20160107_095131754.jpg', '1318551', '2016-01-15 09:23:41', 124),
	(323, '0b80d7e8-e22f-4bf2-b8a3-ad165f2fea4e.jpg', 'IMG_20160107_095142490_HDR.jpg', '1237555', '2016-01-15 09:23:42', 124),
	(324, '05632be7-88ef-4271-a385-4233fe86c601.jpg', 'IMG_20160107_095153539_HDR.jpg', '1378002', '2016-01-15 09:23:42', 124),
	(325, '1544de27-6384-4622-b918-cef39ec8cd86.jpg', 'IMG_20160107_095600366.jpg', '1264828', '2016-01-15 09:26:20', 125),
	(326, 'c2786d40-4a22-41e1-a905-00ef4200bdec.jpg', 'IMG_20160107_095614360_HDR.jpg', '1179453', '2016-01-15 09:26:20', 125),
	(327, '415da249-8111-487a-9d91-68c196f038ae.jpg', 'IMG_20160107_095627492_HDR.jpg', '1219715', '2016-01-15 09:26:21', 125),
	(328, '5687a452-a085-457a-a138-016cdd9ae41d.jpg', 'IMG_20160107_095639809_HDR.jpg', '1382448', '2016-01-15 09:26:21', 125);
/*!40000 ALTER TABLE `Arquivo` ENABLE KEYS */;






-- Copiando estrutura para procedure lojacarros.procMarcaByIdTipoSELECT
DELIMITER //
CREATE PROCEDURE `procMarcaByIdTipoSELECT`(IN `idTipo` INT)
BEGIN



SELECT 

M.IdMarca, M.Nome 

FROM Marca AS M 


INNER JOIN Tipo AS T ON T.IdTipo = M.IdTipo            


WHERE ( T.IdTipo = idTipo OR idTipo IS NULL);


END//
DELIMITER ;


-- Copiando estrutura para procedure lojacarros.procMarcaByTipoSELECT
DELIMITER //
CREATE PROCEDURE `procMarcaByTipoSELECT`(IN `idTipo` VARCHAR(50), IN `ativo` INT)
BEGIN



SELECT DISTINCT 


COUNT(IdVeiculo) AS QtdVeiculo, T.Nome AS TipoNome,

M.IdMarca, M.Nome 

FROM Marca AS M 

LEFT JOIN Veiculo AS V on V.IdMarca = M.IdMarca       
INNER JOIN Tipo AS T ON T.IdTipo = M.IdTipo            


WHERE (V.Ativo = ativo OR ativo IS NULL) AND 
		( T.Nome = idTipo OR idTipo IS NULL) 
		
		GROUP BY M.IdMarca;


END//
DELIMITER ;


-- Copiando estrutura para procedure lojacarros.procMarcaSELECT
DELIMITER //
CREATE PROCEDURE `procMarcaSELECT`(IN `idMarca` INT)
BEGIN



SELECT 

M.IdMarca, M.Nome ,T.Nome AS NomeTipo, M.IdTipo, DataCadastro

FROM Marca AS M 

INNER JOIN Tipo AS T on T.IdTipo = M.IdTipo


WHERE  M.IdMarca = idMarca OR idMarca IS NULL ORDER BY M.Nome;


END//
DELIMITER ;


-- Copiando estrutura para procedure lojacarros.procVeiculoByFiltroSELECT
DELIMITER //
CREATE PROCEDURE `procVeiculoByFiltroSELECT`(IN `TipoV` VARCHAR(50), IN `MarcaV` VARCHAR(50), IN `AnoInicio` VARCHAR(50), IN `AnoFim` VARCHAR(50))
BEGIN


IF (AnoInicio is NULL )THEN
SELECT MIN(AnoFabricacao) into AnoInicio FROM Veiculo; 
END IF;

IF (AnoFim is NULL) THEN
SELECT MAX(AnoFabricacao) into AnoFim FROM Veiculo;
END IF;


SELECT 
C.Nome AS CombustivelNome, 
T.Nome, M.Nome AS MarcaNome, 
V.AnoFabricacao, Modelo, Valor, V.IdVeiculo, AnoModelo, 
MIN(IdArquivo) As MinArquivo, A.Nome AS aNome

FROM Veiculo AS V 
INNER JOIN Marca AS M ON M.IdMarca = V.IdMarca 
INNER JOIN Tipo AS T ON T.IdTipo = M.IdTipo 
INNER JOIN Combustivel AS C ON C.IdCombustivel = V.IdCombustivel 
LEFT JOIN Arquivo AS A ON A.IdVeiculo = V.IdVeiculo 



WHERE (T.Nome = TipoV OR TipoV IS NULL) AND 
		(M.Nome = MarcaV OR MarcaV IS NULL) AND 
		(V.AnoFabricacao BETWEEN AnoInicio AND AnoFim) AND Ativo = 1 GROUP BY V.IdVeiculo ORDER BY V.DataCadastro DESC;

 
 END//
DELIMITER ;


-- Copiando estrutura para procedure lojacarros.procVeiculoSELECT
DELIMITER //
CREATE PROCEDURE `procVeiculoSELECT`(IN `idVeiculo` INT, IN `ativo` INT)
BEGIN


SELECT 

C.Nome AS CombustivelNome, 
T.Nome, M.IdTipo as idTipo, M.Nome AS MarcaNome, M.IdMarca as IdMarca,  
V.AnoFabricacao, Modelo, Valor, Descricao, V.IdVeiculo, AnoModelo, QtdAcesso, Destaque, V.Ativo, V.IdCombustivel as idCombustivel,
V.DataCadastro, 
MIN(IdArquivo) As MinArquivo, A.Nome AS aNome

FROM Veiculo AS V 
INNER JOIN Marca AS M ON M.IdMarca = V.IdMarca 
INNER JOIN Tipo AS T ON T.IdTipo = M.IdTipo 
INNER JOIN Combustivel AS C ON C.IdCombustivel = V.IdCombustivel 
LEFT JOIN Arquivo AS A ON A.IdVeiculo = V.IdVeiculo 



WHERE (V.Ativo = ativo OR ativo IS NULL) AND 
		(V.IdVeiculo = idVeiculo OR idVeiculo IS NULL) GROUP BY V.IdVeiculo ORDER BY V.DataCadastro DESC; 
		

END//
DELIMITER ;



