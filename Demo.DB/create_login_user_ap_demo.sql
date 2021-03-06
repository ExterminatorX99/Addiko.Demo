USE [master]
GO
CREATE LOGIN [ap_demo] WITH PASSWORD=N'ap_demo', DEFAULT_DATABASE=[Demo], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
USE [Demo]
GO
CREATE USER [ap_demo] FOR LOGIN [ap_demo]
GO
USE [Demo]
GO
ALTER USER [ap_demo] WITH DEFAULT_SCHEMA=[ap_demo]
GO
USE [Demo]
GO
CREATE SCHEMA [ap_demo] AUTHORIZATION [ap_demo]
GO
