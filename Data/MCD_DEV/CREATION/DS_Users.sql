/*################################################################################################*/
/* Script     : DS_Users.sql                                                                      */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

-- Role Administrateur
CREATE USER DS_ADMIN IDENTIFIED BY DS_ADMIN 
DEFAULT TABLESPACE USERS
/
GRANT CONNECT TO DS_ADMIN;
GRANT PRF_SELECT TO DS_ADMIN;
GRANT PRF_EXECUTE TO DS_ADMIN;
GRANT INF_SELECT TO DS_ADMIN;
GRANT INF_EXECUTE TO DS_ADMIN;
GRANT OH_SELECT TO DS_ADMIN;
GRANT OH_EXECUTE TO DS_ADMIN;
GRANT MAPINFO_SELECT TO DS_ADMIN;
GRANT MAPINFO_EXECUTE TO DS_ADMIN;
GRANT DS_SELECT TO DS_ADMIN;
GRANT DS_EXECUTE TO DS_ADMIN;
GRANT OA_SELECT TO DS_ADMIN;
GRANT OA_EXECUTE TO DS_ADMIN;
GRANT BSN_SELECT TO DS_ADMIN;
GRANT BSN_EXECUTE TO DS_ADMIN;
GRANT WEB_SELECT TO DS_ADMIN;
GRANT WEB_EXECUTE TO DS_ADMIN;
GRANT DS_UPDATE TO DS_ADMIN;
GRANT PRF_UPDATE_EXT TO DS_ADMIN;
GRANT INF_UPDATE_EXT TO DS_ADMIN;
GRANT OH_UPDATE_EXT TO DS_ADMIN;
GRANT MAPINFO_UPDATE_EXT TO DS_ADMIN;
GRANT DS_UPDATE_EXT TO DS_ADMIN;
GRANT OA_UPDATE_EXT TO DS_ADMIN;
GRANT BSN_UPDATE_EXT TO DS_ADMIN;
GRANT WEB_UPDATE_EXT TO DS_ADMIN;

-- Role Consultant
CREATE USER DS_CONSULT IDENTIFIED BY DS_CONSULT 
DEFAULT TABLESPACE USERS
/
GRANT CONNECT TO DS_CONSULT;
GRANT PRF_SELECT TO DS_CONSULT;
GRANT PRF_EXECUTE TO DS_CONSULT;
GRANT INF_SELECT TO DS_CONSULT;
GRANT INF_EXECUTE TO DS_CONSULT;
GRANT OH_SELECT TO DS_CONSULT;
GRANT OH_EXECUTE TO DS_CONSULT;
GRANT MAPINFO_SELECT TO DS_CONSULT;
GRANT MAPINFO_EXECUTE TO DS_CONSULT;
GRANT DS_SELECT TO DS_CONSULT;
GRANT DS_EXECUTE TO DS_CONSULT;
GRANT OA_SELECT TO DS_CONSULT;
GRANT OA_EXECUTE TO DS_CONSULT;
GRANT BSN_SELECT TO DS_CONSULT;
GRANT BSN_EXECUTE TO DS_CONSULT;
GRANT WEB_SELECT TO DS_CONSULT;
GRANT WEB_EXECUTE TO DS_CONSULT;
GRANT PRF_UPDATE_EXT TO DS_CONSULT;
GRANT INF_UPDATE_EXT TO DS_CONSULT;
GRANT OH_UPDATE_EXT TO DS_CONSULT;
GRANT MAPINFO_UPDATE_EXT TO DS_CONSULT;
GRANT DS_UPDATE_EXT TO DS_CONSULT;
GRANT OA_UPDATE_EXT TO DS_CONSULT;
GRANT BSN_UPDATE_EXT TO DS_CONSULT;
GRANT WEB_UPDATE_EXT TO DS_CONSULT;

-- Role Valideur
CREATE USER DS_VALID IDENTIFIED BY DS_VALID 
DEFAULT TABLESPACE USERS
/
GRANT CONNECT TO DS_VALID;
GRANT PRF_SELECT TO DS_VALID;
GRANT PRF_EXECUTE TO DS_VALID;
GRANT INF_SELECT TO DS_VALID;
GRANT INF_EXECUTE TO DS_VALID;
GRANT OH_SELECT TO DS_VALID;
GRANT OH_EXECUTE TO DS_VALID;
GRANT MAPINFO_SELECT TO DS_VALID;
GRANT MAPINFO_EXECUTE TO DS_VALID;
GRANT DS_SELECT TO DS_VALID;
GRANT DS_EXECUTE TO DS_VALID;
GRANT OA_SELECT TO DS_VALID;
GRANT OA_EXECUTE TO DS_VALID;
GRANT BSN_SELECT TO DS_VALID;
GRANT BSN_EXECUTE TO DS_VALID;
GRANT WEB_SELECT TO DS_VALID;
GRANT WEB_EXECUTE TO DS_VALID;
GRANT DS_UPDATE TO DS_VALID;
GRANT PRF_UPDATE_EXT TO DS_VALID;
GRANT INF_UPDATE_EXT TO DS_VALID;
GRANT OH_UPDATE_EXT TO DS_VALID;
GRANT MAPINFO_UPDATE_EXT TO DS_VALID;
GRANT DS_UPDATE_EXT TO DS_VALID;
GRANT OA_UPDATE_EXT TO DS_VALID;
GRANT BSN_UPDATE_EXT TO DS_VALID;
GRANT WEB_UPDATE_EXT TO DS_VALID;

