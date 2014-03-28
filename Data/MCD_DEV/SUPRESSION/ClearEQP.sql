/*################################################################################################*/
/* Script     : ClearEQP.sql                                                                      */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

connect sys/Emash21@MCDDEV as sysdba
DROP USER EQP_ADMIN CASCADE;
DROP USER EQP_VALID CASCADE;
DROP USER EQP_CONSULT CASCADE;
DROP USER EQP CASCADE;
DROP ROLE EQP_SELECT;
DROP ROLE EQP_UPDATE;
DROP ROLE EQP_EXECUTE;
DROP ROLE EQP_UPDATE_EXT;
disconnect
