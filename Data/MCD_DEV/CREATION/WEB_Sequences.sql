/*################################################################################################*/
/* Script     : WEB_Sequences.sql                                                                 */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

CREATE SEQUENCE SEQ_NODE_WEB INCREMENT BY 1 START WITH 1 
MAXVALUE 999999 MINVALUE 1 NOCYCLE NOCACHE ORDER;

CREATE SEQUENCE SEQ_STYLE_WEB INCREMENT BY 1 START WITH 1 
MAXVALUE 999999 MINVALUE 1 NOCYCLE NOCACHE ORDER;

CREATE SEQUENCE SEQ_STYLE_RULE_WEB INCREMENT BY 1 START WITH 1 
MAXVALUE 999999 MINVALUE 1 NOCYCLE NOCACHE ORDER;

CREATE SEQUENCE SEQ_MODELE_WEB INCREMENT BY 1 START WITH 1 
MAXVALUE 999999 MINVALUE 1 NOCYCLE NOCACHE ORDER;

