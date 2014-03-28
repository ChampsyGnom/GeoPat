/*################################################################################################*/
/* Script     : SystemModifJeuCaractere.sql                                                       */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

update sys.props$ set VALUE$='WE8MSWIN1252' where NAME='NLS_CHARACTERSET';
COMMIT;
SHUTDOWN IMMEDIATE;
STARTUP MOUNT;
ALTER SYSTEM ENABLE RESTRICTED SESSION;
ALTER SYSTEM SET JOB_QUEUE_PROCESSES=0;
ALTER SYSTEM SET AQ_TM_PROCESSES=0;
ALTER DATABASE OPEN;
ALTER DATABASE CHARACTER SET WE8MSWIN1252;
COMMIT WORK;
SHUTDOWN IMMEDIATE;
STARTUP;
connect sys/Emash21@MCDDEV as sysdba
