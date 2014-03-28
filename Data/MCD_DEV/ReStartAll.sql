/*################################################################################################*/
/* Script     : ReStartAll.sql                                                                    */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

-- Démontage de la base pour forcer la deconnexion de tous les utilisateurs
connect sys/Emash21 as sysdba
-- Supression de ancienne base
@@SUPRESSION/ClearAll.sql
-- Creation des structures
@@CREATION/Start.sql

-- Initialisation des méta-données
@@INITIALISATION/PRF_SysPrp.sql
@@INITIALISATION/INF_SysPrp.sql
@@INITIALISATION/CHS_SysPrp.sql
@@INITIALISATION/GOT_SysPrp.sql
@@INITIALISATION/GMS_SysPrp.sql
@@INITIALISATION/OH_SysPrp.sql
@@INITIALISATION/MAPINFO_SysPrp.sql
@@INITIALISATION/DS_SysPrp.sql
@@INITIALISATION/OA_SysPrp.sql
@@INITIALISATION/EQP_SysPrp.sql
@@INITIALISATION/BSN_SysPrp.sql
@@INITIALISATION/WEB_SysPrp.sql

-- Initialisation des données profil
@@INITIALISATION/PRF_Data_PRF.sql
@@INITIALISATION/PRF_Data_INF.sql
@@INITIALISATION/PRF_Data_CHS.sql
@@INITIALISATION/PRF_Data_GOT.sql
@@INITIALISATION/PRF_Data_GMS.sql
@@INITIALISATION/PRF_Data_OH.sql
@@INITIALISATION/PRF_Data_MAPINFO.sql
@@INITIALISATION/PRF_Data_DS.sql
@@INITIALISATION/PRF_Data_OA.sql
@@INITIALISATION/PRF_Data_EQP.sql
@@INITIALISATION/PRF_Data_BSN.sql
@@INITIALISATION/PRF_Data_WEB.sql
