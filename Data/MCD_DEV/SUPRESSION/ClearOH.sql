/*################################################################################################*/
/* Script     : ClearOH.sql                                                                       */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

connect sys/Emash21@MCDDEV as sysdba
DROP USER OH_ADMIN CASCADE;
DROP USER OH_VALID CASCADE;
DROP USER OH_CONSULT CASCADE;
DROP USER OH CASCADE;
DROP ROLE OH_SELECT;
DROP ROLE OH_UPDATE;
DROP ROLE OH_EXECUTE;
DROP ROLE OH_UPDATE_EXT;
disconnect
