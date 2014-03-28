/*################################################################################################*/
/* Script     : ClearDS.sql                                                                       */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

connect sys/Emash21@MCDDEV as sysdba
DROP USER DS_ADMIN CASCADE;
DROP USER DS_VALID CASCADE;
DROP USER DS_CONSULT CASCADE;
DROP USER DS CASCADE;
DROP ROLE DS_SELECT;
DROP ROLE DS_UPDATE;
DROP ROLE DS_EXECUTE;
DROP ROLE DS_UPDATE_EXT;
disconnect
