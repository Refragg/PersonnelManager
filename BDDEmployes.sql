-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : lun. 29 avr. 2024 à 11:28
-- Version du serveur : 11.2.2-MariaDB
-- Version de PHP : 7.4.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `employes`
--
CREATE DATABASE IF NOT EXISTS `employes` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `employes`;

-- --------------------------------------------------------

--
-- Structure de la table `absence`
--

DROP TABLE IF EXISTS `absence`;
CREATE TABLE IF NOT EXISTS `absence` (
  `idpersonnel` int(11) NOT NULL,
  `datedebut` datetime NOT NULL,
  `datefin` datetime DEFAULT NULL,
  `idmotif` int(11) NOT NULL,
  PRIMARY KEY (`idpersonnel`,`datedebut`),
  KEY `idmotif` (`idmotif`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `absence`
--

INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES
(9, '2023-03-23 11:02:23', '2023-10-18 09:14:37', 1),
(8, '2023-01-21 13:23:49', '2023-08-21 05:16:03', 3),
(9, '2023-02-12 08:40:17', '2023-10-02 17:57:27', 3),
(1, '2023-05-05 08:01:49', '2023-11-19 07:07:47', 2),
(3, '2023-01-11 11:38:45', '2023-11-17 04:32:33', 3),
(9, '2023-02-06 17:35:41', '2023-09-07 05:28:16', 3),
(6, '2023-04-28 08:33:12', '2023-09-07 23:10:39', 3),
(5, '2023-03-30 17:40:20', '2023-10-14 11:29:42', 1),
(4, '2023-06-23 14:05:42', '2023-10-05 01:09:01', 1),
(1, '2023-01-11 14:10:11', '2023-07-21 06:02:37', 2),
(4, '2023-04-05 13:12:32', '2023-12-02 19:08:13', 4),
(10, '2023-02-27 05:50:32', '2023-10-16 09:55:46', 1),
(7, '2023-05-03 14:35:32', '2023-12-10 03:50:58', 2),
(9, '2023-05-28 17:27:05', '2023-08-13 09:30:43', 1),
(4, '2023-03-08 03:38:37', '2023-08-13 18:35:57', 2),
(6, '2023-03-03 16:38:22', '2023-10-15 09:10:31', 2),
(7, '2023-04-02 03:55:24', '2023-08-20 21:46:57', 4),
(7, '2023-04-02 22:40:42', '2023-07-21 20:48:33', 3),
(3, '2023-03-16 11:00:54', '2023-10-26 01:30:09', 2),
(8, '2023-06-20 11:02:34', '2023-09-28 14:36:57', 1),
(4, '2023-05-19 21:46:12', '2023-12-20 08:06:41', 1),
(4, '2023-04-26 12:08:13', '2023-08-25 23:07:38', 2),
(6, '2023-04-21 14:22:32', '2023-10-19 05:42:20', 1),
(8, '2023-02-07 20:09:36', '2023-07-18 16:19:49', 2),
(4, '2023-03-05 02:49:31', '2023-11-21 15:50:27', 4),
(2, '2023-03-21 05:08:37', '2023-11-19 05:39:17', 2),
(6, '2023-03-17 20:08:40', '2023-07-03 11:21:15', 4),
(9, '2023-03-12 08:45:19', '2023-08-21 09:06:23', 4),
(5, '2023-04-03 23:21:28', '2023-12-29 15:24:59', 4),
(2, '2023-04-30 00:21:00', '2023-07-10 19:43:24', 4),
(10, '2023-02-08 19:32:50', '2023-08-25 22:02:24', 1),
(7, '2023-02-08 04:40:39', '2023-11-06 05:13:06', 2),
(6, '2023-02-08 06:52:33', '2023-10-12 04:57:15', 3),
(6, '2023-06-16 04:55:53', '2023-09-06 21:13:24', 4),
(3, '2023-01-06 10:19:59', '2023-09-06 09:36:59', 3),
(1, '2023-02-16 17:43:54', '2023-09-06 19:16:42', 2),
(1, '2023-03-05 00:51:40', '2023-12-03 06:02:55', 4),
(9, '2023-01-14 18:12:15', '2023-09-21 18:05:04', 3),
(9, '2023-04-12 22:07:45', '2023-07-11 18:02:30', 4),
(7, '2023-03-07 19:58:04', '2023-11-13 10:34:02', 2),
(6, '2023-05-08 09:28:24', '2023-09-25 00:27:01', 1),
(4, '2023-02-01 02:58:36', '2023-11-04 13:48:21', 3),
(5, '2023-03-05 15:13:50', '2023-12-07 04:43:11', 3),
(7, '2023-05-24 07:57:53', '2023-10-05 20:51:54', 2),
(4, '2024-04-05 16:26:20', '2024-04-08 16:26:20', 1),
(1, '2023-02-21 08:04:49', '2023-08-07 08:08:22', 3),
(6, '2023-06-15 19:14:50', '2023-07-19 16:15:57', 2),
(10, '2023-01-08 23:27:04', '2023-12-08 07:38:18', 2),
(4, '2023-03-23 16:34:59', '2023-07-27 13:40:42', 2),
(3, '2023-05-07 13:33:17', '2023-09-29 16:04:28', 2);

-- --------------------------------------------------------

--
-- Structure de la table `motif`
--

DROP TABLE IF EXISTS `motif`;
CREATE TABLE IF NOT EXISTS `motif` (
  `idmotif` int(11) NOT NULL AUTO_INCREMENT,
  `libelle` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`idmotif`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `motif`
--

INSERT INTO `motif` (`idmotif`, `libelle`) VALUES
(1, 'vacances'),
(2, 'maladie'),
(3, 'motif familial'),
(4, 'congé parental');

-- --------------------------------------------------------

--
-- Structure de la table `personnel`
--

DROP TABLE IF EXISTS `personnel`;
CREATE TABLE IF NOT EXISTS `personnel` (
  `idpersonnel` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) DEFAULT NULL,
  `prenom` varchar(50) DEFAULT NULL,
  `tel` varchar(15) DEFAULT NULL,
  `mail` varchar(128) DEFAULT NULL,
  `idservice` int(11) NOT NULL,
  PRIMARY KEY (`idpersonnel`),
  KEY `idservice` (`idservice`)
) ENGINE=MyISAM AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `personnel`
--

INSERT INTO `personnel` (`idpersonnel`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES
(1, 'Nero', 'Lawson', '05 16 01 72 60', 'non.bibendum@outlook.ca', 2),
(2, 'Camillia', 'Cruzing', '04 83 82 61 85', 'ut.molestie@yahoo.net', 3),
(3, 'Chancellor', 'Gillette', '01 86 05 46 22', 'nunc@protonmail.couk', 2),
(4, 'Hakeem', 'Alexandre', '03 54 91 46 86', 'adipiscing.elit@outlook.org', 1),
(5, 'Melyssa', 'Wilkerson', '05 21 05 45 87', 'arcu.sed@yahoo.org', 2),
(6, 'Scott', 'Joyce', '07 06 64 34 89', 'eget.varius@outlook.ca', 1),
(7, 'Liberty', 'York', '03 43 85 56 87', 'per.conubia.nostra@protonmail.com', 2),
(8, 'Danish', 'Dawson', '03 78 78 63 98', 'ante@hotmail.ca', 3),
(9, 'Tamekah', 'Hammond', '06 82 78 44 55', 'blandit.mattis.cras@google.org', 3),
(10, 'Uta', 'Riggs', '06 26 57 44 12', 'turpis.in@yahoo.net', 2);

-- --------------------------------------------------------

--
-- Structure de la table `service`
--

DROP TABLE IF EXISTS `service`;
CREATE TABLE IF NOT EXISTS `service` (
  `idservice` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idservice`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `service`
--

INSERT INTO `service` (`idservice`, `nom`) VALUES
(1, 'administratif'),
(2, 'médiation culturelle'),
(3, 'prêt');

-- --------------------------------------------------------

--
-- Création de l'utilisateur SQL autorisé à exécuter l'application
--

CREATE USER IF NOT EXISTS 'directeur'@'%';
SET PASSWORD FOR 'directeur'@'%' = PASSWORD('P@$$word1');
GRANT UPDATE, SELECT, INSERT, DELETE, DROP ON absence TO directeur;
GRANT UPDATE, SELECT, INSERT, DELETE, DROP ON motif TO directeur;
GRANT UPDATE, SELECT, INSERT, DELETE, DROP ON personnel TO directeur;
GRANT UPDATE, SELECT, INSERT, DELETE, DROP ON service TO directeur;

COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
