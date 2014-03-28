/*################################################################################################*/
/* Script     : ClearOA.sql                                                                       */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

connect sys/Emash21@MCDDEV as sysdba
DROP USER OA_ADMIN CASCADE;
DROP USER OA_VALID CASCADE;
DROP USER OA_CONSULT CASCADE;
DROP USER OA CASCADE;
DROP ROLE OA_SELECT;
DROP ROLE OA_UPDATE;
DROP ROLE OA_EXECUTE;
DROP ROLE OA_UPDATE_EXT;
disconnect
