/*################################################################################################*/
/* Script     : ClearBSN.sql                                                                      */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

connect sys/Emash21@MCDDEV as sysdba
DROP USER BSN_ADMIN CASCADE;
DROP USER BSN_VALID CASCADE;
DROP USER BSN_CONSULT CASCADE;
DROP USER BSN CASCADE;
DROP ROLE BSN_SELECT;
DROP ROLE BSN_UPDATE;
DROP ROLE BSN_EXECUTE;
DROP ROLE BSN_UPDATE_EXT;
disconnect
