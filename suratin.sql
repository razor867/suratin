-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Jul 03, 2022 at 04:31 PM
-- Server version: 5.7.31
-- PHP Version: 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `suratin`
--

-- --------------------------------------------------------

--
-- Table structure for table `surat_masuk`
--

DROP TABLE IF EXISTS `surat_masuk`;
CREATE TABLE IF NOT EXISTS `surat_masuk` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(100) NOT NULL,
  `regarding` varchar(100) NOT NULL,
  `to_person` varchar(100) NOT NULL,
  `from_person` varchar(100) NOT NULL,
  `message` varchar(100) NOT NULL,
  `created_at` decimal(11,0) NOT NULL,
  `created_time` decimal(11,0) NOT NULL,
  `updated_at` decimal(11,0) NOT NULL,
  `updated_time` decimal(11,0) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `surat_masuk`
--

INSERT INTO `surat_masuk` (`id`, `title`, `regarding`, `to_person`, `from_person`, `message`, `created_at`, `created_time`, `updated_at`, `updated_time`) VALUES
(2, 'Izin Cuti 10 Hari', 'Refershing', 'Linda', 'Dodi', 'Saya ingin mengajukan cuti selaman 10 hari untuk melakukan refreshing', '20220701', '132101', '20220701', '132101'),
(3, 'Pertemuan Rapat', 'Rapat', 'Anton', 'Yanti Yuliasari', 'Mengundang anda sebagai peserta untuk melakukan rapat mingguan pada tanggal 20 Juni 2022', '20220702', '132101', '20220703', '232945');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
