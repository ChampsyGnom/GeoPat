/*################################################################################################*/
/* Script     : ClearCHS.sql                                                                      */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

connect sys/Emash21@MCDDEV as sysdba
DROP USER CHS_ADMIN CASCADE;
DROP USER CHS_VALID CASCADE;
DROP USER CHS_CONSULT CASCADE;
DROP USER CHS CASCADE;
DROP ROLE CHS_SELECT;
DROP ROLE CHS_UPDATE;
DROP ROLE CHS_EXECUTE;
DROP ROLE CHS_UPDATE_EXT;
disconnect
