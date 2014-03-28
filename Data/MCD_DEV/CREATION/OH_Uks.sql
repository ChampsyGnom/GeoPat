/*################################################################################################*/
/* Script     : OH_Uks.sql                                                                        */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

ALTER TABLE CLS_OH
ADD CONSTRAINT CLS_OH_UK 
UNIQUE (TABLE_NAME,KEY_VALUE) 
USING INDEX
;

ALTER TABLE DOC_OH
ADD CONSTRAINT DOC_OH_UK 
UNIQUE (CD_DOC__CODE,REF) 
USING INDEX
;

