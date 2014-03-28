/*################################################################################################*/
/* Script     : ClearWEB.sql                                                                      */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

connect sys/Emash21@MCDDEV as sysdba
DROP USER WEB_ADMIN CASCADE;
DROP USER WEB_VALID CASCADE;
DROP USER WEB_CONSULT CASCADE;
DROP USER WEB CASCADE;
DROP ROLE WEB_SELECT;
DROP ROLE WEB_UPDATE;
DROP ROLE WEB_EXECUTE;
DROP ROLE WEB_UPDATE_EXT;
disconnect
