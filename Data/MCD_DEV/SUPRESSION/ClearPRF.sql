/*################################################################################################*/
/* Script     : ClearPRF.sql                                                                      */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

connect sys/Emash21@MCDDEV as sysdba
DROP USER PRF_ADMIN CASCADE;
DROP USER PRF_CONSULT CASCADE;
DROP USER PRF CASCADE;
DROP ROLE PRF_SELECT;
DROP ROLE PRF_UPDATE;
DROP ROLE PRF_EXECUTE;
DROP ROLE PRF_UPDATE_EXT;
disconnect
