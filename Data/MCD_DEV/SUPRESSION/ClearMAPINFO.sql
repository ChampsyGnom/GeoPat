/*################################################################################################*/
/* Script     : ClearMAPINFO.sql                                                                  */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

connect sys/Emash21@MCDDEV as sysdba
DROP USER MAPINFO_ADMIN CASCADE;
DROP USER MAPINFO_VALID CASCADE;
DROP USER MAPINFO_CONSULT CASCADE;
DROP USER MAPINFO CASCADE;
DROP ROLE MAPINFO_SELECT;
DROP ROLE MAPINFO_UPDATE;
DROP ROLE MAPINFO_EXECUTE;
DROP ROLE MAPINFO_UPDATE_EXT;
disconnect
