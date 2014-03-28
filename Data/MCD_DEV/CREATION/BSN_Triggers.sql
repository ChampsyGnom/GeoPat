/*################################################################################################*/
/* Script     : BSN_Triggers.sql                                                                  */
/* Base       : Oracle                                                                            */
/* Auteur     : loic                                                                              */
/* Date       : 27/3/2014                                                                         */
/* Heure      : 15:16                                                                             */
/*################################################################################################*/

-- Declaration du package d'integrite
Create or replace package IntegrityPackage AS
  Procedure InitNestLevel;
  Function GetNestLevel return number;
  Procedure NextNestLevel;
  Procedure PreviousNestLevel;
End IntegrityPackage;
/

-- Definition du package d'integrite
Create or replace package body IntegrityPackage AS
  NestLevel number;
  -- Procédure initialisant le niveau d'imbrication des triggers
  Procedure InitNestLevel is
  Begin
    NestLevel := 0;
  End;

  -- Fonction retournant le niveau d'imbrication des triggers
  Function GetNestLevel return number is
  Begin
    If NestLevel Is Null Then
      NestLevel := 0;
    End if;
    Return(NestLevel);
  End;

  -- Procédure augmentant le niveau d'imbrication des triggers
  Procedure NextNestLevel is
  Begin
  If NestLevel Is Null Then
    NestLevel := 0;
   End if;
   NestLevel := NestLevel + 1;
  End;

  -- Procédure diminuant le niveau d'imbrication des triggers
  Procedure PreviousNestLevel is
  Begin
    NestLevel := NestLevel - 1;
  End;

End IntegrityPackage;
/


create or replace TRIGGER "BSN"."TIB_DSCBSN" before insert
on BSN.DSC_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_FAM_BSN"
	cursor c1_dsc_bsn(Vcd_fam_bsn__famille varchar) is
		select 1 
		from BSN.CD_FAM_BSN 
		where 
		FAMILLE = Vcd_fam_bsn__famille and Vcd_fam_bsn__famille is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_PERMEABLE_BSN"
	cursor c2_dsc_bsn(Vcd_permeable_bsn__type varchar) is
		select 1 
		from BSN.CD_PERMEABLE_BSN 
		where 
		TYPE = Vcd_permeable_bsn__type and Vcd_permeable_bsn__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_TYPE_BSN"
	cursor c3_dsc_bsn(Vcd_type_bsn__type varchar) is
		select 1 
		from BSN.CD_TYPE_BSN 
		where 
		TYPE = Vcd_type_bsn__type and Vcd_type_bsn__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_EXT_BSN"
	cursor c4_dsc_bsn(Vcd_ext_bsn__type varchar) is
		select 1 
		from BSN.CD_EXT_BSN 
		where 
		TYPE = Vcd_ext_bsn__type and Vcd_ext_bsn__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_QUALITE_BSN"
	cursor c5_dsc_bsn(Vcd_qualite_bsn__qualite varchar) is
		select 1 
		from BSN.CD_QUALITE_BSN 
		where 
		QUALITE = Vcd_qualite_bsn__qualite and Vcd_qualite_bsn__qualite is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_ACCES_BSN"
	cursor c6_dsc_bsn(Vcd_acces_bsn__vacces varchar) is
		select 1 
		from BSN.CD_ACCES_BSN 
		where 
		VACCES = Vcd_acces_bsn__vacces and Vcd_acces_bsn__vacces is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_SOUS_TYPE_BSN"
	cursor c7_dsc_bsn(Vcd_sous_type_bsn__nat_sensib varchar) is
		select 1 
		from BSN.CD_SOUS_TYPE_BSN 
		where 
		NAT_SENSIB = Vcd_sous_type_bsn__nat_sensib and Vcd_sous_type_bsn__nat_sensib is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_FREQUENCE_BSN"
	cursor c8_dsc_bsn(Vcd_frequence_bsn__freq varchar) is
		select 1 
		from BSN.CD_FREQUENCE_BSN 
		where 
		FREQ = Vcd_frequence_bsn__freq and Vcd_frequence_bsn__freq is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_ENTP_BSN"
	cursor c9_dsc_bsn(Vcd_entp_bsn__entreprise varchar) is
		select 1 
		from BSN.CD_ENTP_BSN 
		where 
		ENTREPRISE = Vcd_entp_bsn__entreprise and Vcd_entp_bsn__entreprise is not null;
begin

	
	--  Le parent "BSN.CD_FAM_BSN" doit exister à la création d'un enfant dans "BSN.DSC_BSN"
	if :new.CD_FAM_BSN__FAMILLE is not null then 
		open c1_dsc_bsn ( :new.CD_FAM_BSN__FAMILLE);
		fetch c1_dsc_bsn into dummy;
		found := c1_dsc_bsn%FOUND;
		close c1_dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_FAM_BSN". Impossible de créer un enfant dans "BSN.DSC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_PERMEABLE_BSN" doit exister à la création d'un enfant dans "BSN.DSC_BSN"
	if :new.CD_PERMEABLE_BSN__TYPE is not null then 
		open c2_dsc_bsn ( :new.CD_PERMEABLE_BSN__TYPE);
		fetch c2_dsc_bsn into dummy;
		found := c2_dsc_bsn%FOUND;
		close c2_dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_PERMEABLE_BSN". Impossible de créer un enfant dans "BSN.DSC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_TYPE_BSN" doit exister à la création d'un enfant dans "BSN.DSC_BSN"
	if :new.CD_TYPE_BSN__TYPE is not null then 
		open c3_dsc_bsn ( :new.CD_TYPE_BSN__TYPE);
		fetch c3_dsc_bsn into dummy;
		found := c3_dsc_bsn%FOUND;
		close c3_dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_TYPE_BSN". Impossible de créer un enfant dans "BSN.DSC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_EXT_BSN" doit exister à la création d'un enfant dans "BSN.DSC_BSN"
	if :new.CD_EXT_BSN__TYPE is not null then 
		open c4_dsc_bsn ( :new.CD_EXT_BSN__TYPE);
		fetch c4_dsc_bsn into dummy;
		found := c4_dsc_bsn%FOUND;
		close c4_dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_EXT_BSN". Impossible de créer un enfant dans "BSN.DSC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_QUALITE_BSN" doit exister à la création d'un enfant dans "BSN.DSC_BSN"
	if :new.CD_QUALITE_BSN__QUALITE is not null then 
		open c5_dsc_bsn ( :new.CD_QUALITE_BSN__QUALITE);
		fetch c5_dsc_bsn into dummy;
		found := c5_dsc_bsn%FOUND;
		close c5_dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_QUALITE_BSN". Impossible de créer un enfant dans "BSN.DSC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_ACCES_BSN" doit exister à la création d'un enfant dans "BSN.DSC_BSN"
	if :new.CD_ACCES_BSN__VACCES is not null then 
		open c6_dsc_bsn ( :new.CD_ACCES_BSN__VACCES);
		fetch c6_dsc_bsn into dummy;
		found := c6_dsc_bsn%FOUND;
		close c6_dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ACCES_BSN". Impossible de créer un enfant dans "BSN.DSC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_SOUS_TYPE_BSN" doit exister à la création d'un enfant dans "BSN.DSC_BSN"
	if :new.CD_SOUS_TYPE_BSN__NAT_SENSIB is not null then 
		open c7_dsc_bsn ( :new.CD_SOUS_TYPE_BSN__NAT_SENSIB);
		fetch c7_dsc_bsn into dummy;
		found := c7_dsc_bsn%FOUND;
		close c7_dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_SOUS_TYPE_BSN". Impossible de créer un enfant dans "BSN.DSC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_FREQUENCE_BSN" doit exister à la création d'un enfant dans "BSN.DSC_BSN"
	if :new.CD_FREQUENCE_BSN__FREQ is not null then 
		open c8_dsc_bsn ( :new.CD_FREQUENCE_BSN__FREQ);
		fetch c8_dsc_bsn into dummy;
		found := c8_dsc_bsn%FOUND;
		close c8_dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_FREQUENCE_BSN". Impossible de créer un enfant dans "BSN.DSC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_ENTP_BSN" doit exister à la création d'un enfant dans "BSN.DSC_BSN"
	if :new.CD_ENTP_BSN__ENTREPRISE is not null then 
		open c9_dsc_bsn ( :new.CD_ENTP_BSN__ENTREPRISE);
		fetch c9_dsc_bsn into dummy;
		found := c9_dsc_bsn%FOUND;
		close c9_dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ENTP_BSN". Impossible de créer un enfant dans "BSN.DSC_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_DSCBSN" before update
on BSN.DSC_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_FAM_BSN"
	cursor c1_dsc_bsn (Vcd_fam_bsn__famille varchar) is
		select 1 
		from BSN.CD_FAM_BSN 
		where 
		FAMILLE = Vcd_fam_bsn__famille and Vcd_fam_bsn__famille is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_PERMEABLE_BSN"
	cursor c2_dsc_bsn (Vcd_permeable_bsn__type varchar) is
		select 1 
		from BSN.CD_PERMEABLE_BSN 
		where 
		TYPE = Vcd_permeable_bsn__type and Vcd_permeable_bsn__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_TYPE_BSN"
	cursor c3_dsc_bsn (Vcd_type_bsn__type varchar) is
		select 1 
		from BSN.CD_TYPE_BSN 
		where 
		TYPE = Vcd_type_bsn__type and Vcd_type_bsn__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_EXT_BSN"
	cursor c4_dsc_bsn (Vcd_ext_bsn__type varchar) is
		select 1 
		from BSN.CD_EXT_BSN 
		where 
		TYPE = Vcd_ext_bsn__type and Vcd_ext_bsn__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_QUALITE_BSN"
	cursor c5_dsc_bsn (Vcd_qualite_bsn__qualite varchar) is
		select 1 
		from BSN.CD_QUALITE_BSN 
		where 
		QUALITE = Vcd_qualite_bsn__qualite and Vcd_qualite_bsn__qualite is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_ACCES_BSN"
	cursor c6_dsc_bsn (Vcd_acces_bsn__vacces varchar) is
		select 1 
		from BSN.CD_ACCES_BSN 
		where 
		VACCES = Vcd_acces_bsn__vacces and Vcd_acces_bsn__vacces is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_SOUS_TYPE_BSN"
	cursor c7_dsc_bsn (Vcd_sous_type_bsn__nat_sensib varchar) is
		select 1 
		from BSN.CD_SOUS_TYPE_BSN 
		where 
		NAT_SENSIB = Vcd_sous_type_bsn__nat_sensib and Vcd_sous_type_bsn__nat_sensib is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_FREQUENCE_BSN"
	cursor c8_dsc_bsn (Vcd_frequence_bsn__freq varchar) is
		select 1 
		from BSN.CD_FREQUENCE_BSN 
		where 
		FREQ = Vcd_frequence_bsn__freq and Vcd_frequence_bsn__freq is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_ENTP_BSN"
	cursor c9_dsc_bsn (Vcd_entp_bsn__entreprise varchar) is
		select 1 
		from BSN.CD_ENTP_BSN 
		where 
		ENTREPRISE = Vcd_entp_bsn__entreprise and Vcd_entp_bsn__entreprise is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.CD_FAM_BSN" doit exister à la création d'un enfant dans "BSN.DSC_BSN"
	if :new.CD_FAM_BSN__FAMILLE is not null and seq = 0 then 
		open c1_dsc_bsn ( :new.CD_FAM_BSN__FAMILLE);
		fetch c1_dsc_bsn into dummy;
		found := c1_dsc_bsn%FOUND;
		close c1_dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_FAM_BSN". Impossible de modifier un enfant dans "BSN.DSC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_PERMEABLE_BSN" doit exister à la création d'un enfant dans "BSN.DSC_BSN"
	if :new.CD_PERMEABLE_BSN__TYPE is not null and seq = 0 then 
		open c2_dsc_bsn ( :new.CD_PERMEABLE_BSN__TYPE);
		fetch c2_dsc_bsn into dummy;
		found := c2_dsc_bsn%FOUND;
		close c2_dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_PERMEABLE_BSN". Impossible de modifier un enfant dans "BSN.DSC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_TYPE_BSN" doit exister à la création d'un enfant dans "BSN.DSC_BSN"
	if :new.CD_TYPE_BSN__TYPE is not null and seq = 0 then 
		open c3_dsc_bsn ( :new.CD_TYPE_BSN__TYPE);
		fetch c3_dsc_bsn into dummy;
		found := c3_dsc_bsn%FOUND;
		close c3_dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_TYPE_BSN". Impossible de modifier un enfant dans "BSN.DSC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_EXT_BSN" doit exister à la création d'un enfant dans "BSN.DSC_BSN"
	if :new.CD_EXT_BSN__TYPE is not null and seq = 0 then 
		open c4_dsc_bsn ( :new.CD_EXT_BSN__TYPE);
		fetch c4_dsc_bsn into dummy;
		found := c4_dsc_bsn%FOUND;
		close c4_dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_EXT_BSN". Impossible de modifier un enfant dans "BSN.DSC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_QUALITE_BSN" doit exister à la création d'un enfant dans "BSN.DSC_BSN"
	if :new.CD_QUALITE_BSN__QUALITE is not null and seq = 0 then 
		open c5_dsc_bsn ( :new.CD_QUALITE_BSN__QUALITE);
		fetch c5_dsc_bsn into dummy;
		found := c5_dsc_bsn%FOUND;
		close c5_dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_QUALITE_BSN". Impossible de modifier un enfant dans "BSN.DSC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_ACCES_BSN" doit exister à la création d'un enfant dans "BSN.DSC_BSN"
	if :new.CD_ACCES_BSN__VACCES is not null and seq = 0 then 
		open c6_dsc_bsn ( :new.CD_ACCES_BSN__VACCES);
		fetch c6_dsc_bsn into dummy;
		found := c6_dsc_bsn%FOUND;
		close c6_dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ACCES_BSN". Impossible de modifier un enfant dans "BSN.DSC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_SOUS_TYPE_BSN" doit exister à la création d'un enfant dans "BSN.DSC_BSN"
	if :new.CD_SOUS_TYPE_BSN__NAT_SENSIB is not null and seq = 0 then 
		open c7_dsc_bsn ( :new.CD_SOUS_TYPE_BSN__NAT_SENSIB);
		fetch c7_dsc_bsn into dummy;
		found := c7_dsc_bsn%FOUND;
		close c7_dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_SOUS_TYPE_BSN". Impossible de modifier un enfant dans "BSN.DSC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_FREQUENCE_BSN" doit exister à la création d'un enfant dans "BSN.DSC_BSN"
	if :new.CD_FREQUENCE_BSN__FREQ is not null and seq = 0 then 
		open c8_dsc_bsn ( :new.CD_FREQUENCE_BSN__FREQ);
		fetch c8_dsc_bsn into dummy;
		found := c8_dsc_bsn%FOUND;
		close c8_dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_FREQUENCE_BSN". Impossible de modifier un enfant dans "BSN.DSC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_ENTP_BSN" doit exister à la création d'un enfant dans "BSN.DSC_BSN"
	if :new.CD_ENTP_BSN__ENTREPRISE is not null and seq = 0 then 
		open c9_dsc_bsn ( :new.CD_ENTP_BSN__ENTREPRISE);
		fetch c9_dsc_bsn into dummy;
		found := c9_dsc_bsn%FOUND;
		close c9_dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ENTP_BSN". Impossible de modifier un enfant dans "BSN.DSC_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_DSCBSN" after update
of NUM_BSN
on BSN.DSC_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.DSC_BSN" dans les enfants "BSN.TRAVAUX_BSN"
	if ((updating('NUM_BSN') and :old.NUM_BSN != :new.NUM_BSN)) then 
		update BSN.TRAVAUX_BSN
		set DSC_BSN__NUM_BSN = :new.NUM_BSN  
		where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	end if;
	--  Modification du code du parent "BSN.DSC_BSN" dans les enfants "BSN.PREVISION_BSN"
	if ((updating('NUM_BSN') and :old.NUM_BSN != :new.NUM_BSN)) then 
		update BSN.PREVISION_BSN
		set DSC_BSN__NUM_BSN = :new.NUM_BSN  
		where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	end if;
	--  Modification du code du parent "BSN.DSC_BSN" dans les enfants "BSN.VST_BSN"
	if ((updating('NUM_BSN') and :old.NUM_BSN != :new.NUM_BSN)) then 
		update BSN.VST_BSN
		set DSC_BSN__NUM_BSN = :new.NUM_BSN  
		where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	end if;
	--  Modification du code du parent "BSN.DSC_BSN" dans les enfants "BSN.INSP_BSN"
	if ((updating('NUM_BSN') and :old.NUM_BSN != :new.NUM_BSN)) then 
		update BSN.INSP_BSN
		set DSC_BSN__NUM_BSN = :new.NUM_BSN  
		where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	end if;
	--  Modification du code du parent "BSN.DSC_BSN" dans les enfants "BSN.HISTO_NOTE_BSN"
	if ((updating('NUM_BSN') and :old.NUM_BSN != :new.NUM_BSN)) then 
		update BSN.HISTO_NOTE_BSN
		set DSC_BSN__NUM_BSN = :new.NUM_BSN  
		where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	end if;
	--  Modification du code du parent "BSN.DSC_BSN" dans les enfants "BSN.EVT_BSN"
	if ((updating('NUM_BSN') and :old.NUM_BSN != :new.NUM_BSN)) then 
		update BSN.EVT_BSN
		set DSC_BSN__NUM_BSN = :new.NUM_BSN  
		where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	end if;
	--  Modification du code du parent "BSN.DSC_BSN" dans les enfants "BSN.IMPLUVIUM_BSN"
	if ((updating('NUM_BSN') and :old.NUM_BSN != :new.NUM_BSN)) then 
		update BSN.IMPLUVIUM_BSN
		set DSC_BSN__NUM_BSN = :new.NUM_BSN  
		where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	end if;
	--  Modification du code du parent "BSN.DSC_BSN" dans les enfants "BSN.GEOMETRIE_BSN"
	if ((updating('NUM_BSN') and :old.NUM_BSN != :new.NUM_BSN)) then 
		update BSN.GEOMETRIE_BSN
		set DSC_BSN__NUM_BSN = :new.NUM_BSN  
		where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	end if;
	--  Modification du code du parent "BSN.DSC_BSN" dans les enfants "BSN.EQUIPEMENT_BSN"
	if ((updating('NUM_BSN') and :old.NUM_BSN != :new.NUM_BSN)) then 
		update BSN.EQUIPEMENT_BSN
		set DSC_BSN__NUM_BSN = :new.NUM_BSN  
		where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	end if;
	--  Modification du code du parent "BSN.DSC_BSN" dans les enfants "BSN.DSC_TEMP_BSN"
	if ((updating('NUM_BSN') and :old.NUM_BSN != :new.NUM_BSN)) then 
		update BSN.DSC_TEMP_BSN
		set DSC_BSN__NUM_BSN = :new.NUM_BSN  
		where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	end if;
	--  Modification du code du parent "BSN.DSC_BSN" dans les enfants "BSN.DSC_CAMP_BSN"
	if ((updating('NUM_BSN') and :old.NUM_BSN != :new.NUM_BSN)) then 
		update BSN.DSC_CAMP_BSN
		set DSC_BSN__NUM_BSN = :new.NUM_BSN  
		where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	end if;
	--  Modification du code du parent "BSN.DSC_BSN" dans les enfants "BSN.CD_ROLE__DSC_BSN"
	if ((updating('NUM_BSN') and :old.NUM_BSN != :new.NUM_BSN)) then 
		update BSN.CD_ROLE__DSC_BSN
		set DSC_BSN__NUM_BSN = :new.NUM_BSN  
		where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_DSCBSN" after delete
on BSN.DSC_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.TRAVAUX_BSN"
	delete BSN.TRAVAUX_BSN
	where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	
	--  Suppression des enfants dans "BSN.PREVISION_BSN"
	delete BSN.PREVISION_BSN
	where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	
	--  Suppression des enfants dans "BSN.VST_BSN"
	delete BSN.VST_BSN
	where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	
	--  Suppression des enfants dans "BSN.INSP_BSN"
	delete BSN.INSP_BSN
	where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	
	--  Suppression des enfants dans "BSN.HISTO_NOTE_BSN"
	delete BSN.HISTO_NOTE_BSN
	where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	
	--  Suppression des enfants dans "BSN.EVT_BSN"
	delete BSN.EVT_BSN
	where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	
	--  Suppression des enfants dans "BSN.IMPLUVIUM_BSN"
	delete BSN.IMPLUVIUM_BSN
	where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	
	--  Suppression des enfants dans "BSN.GEOMETRIE_BSN"
	delete BSN.GEOMETRIE_BSN
	where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	
	--  Suppression des enfants dans "BSN.EQUIPEMENT_BSN"
	delete BSN.EQUIPEMENT_BSN
	where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	
	--  Suppression des enfants dans "BSN.DSC_TEMP_BSN"
	delete BSN.DSC_TEMP_BSN
	where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	
	--  Suppression des enfants dans "BSN.DSC_CAMP_BSN"
	delete BSN.DSC_CAMP_BSN
	where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	
	--  Suppression des enfants dans "BSN.CD_ROLE__DSC_BSN"
	delete BSN.CD_ROLE__DSC_BSN
	where DSC_BSN__NUM_BSN = :old.NUM_BSN;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_DSCTEMPBSN" before insert
on BSN.DSC_TEMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_FAM_BSN"
	cursor c1_dsc_temp_bsn(Vcd_fam_bsn__famille varchar) is
		select 1 
		from BSN.CD_FAM_BSN 
		where 
		FAMILLE = Vcd_fam_bsn__famille and Vcd_fam_bsn__famille is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_TYPE_BSN"
	cursor c2_dsc_temp_bsn(Vcd_type_bsn__type varchar) is
		select 1 
		from BSN.CD_TYPE_BSN 
		where 
		TYPE = Vcd_type_bsn__type and Vcd_type_bsn__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_SOUS_TYPE_BSN"
	cursor c3_dsc_temp_bsn(Vcd_sous_type_bsn__nat_sensib varchar) is
		select 1 
		from BSN.CD_SOUS_TYPE_BSN 
		where 
		NAT_SENSIB = Vcd_sous_type_bsn__nat_sensib and Vcd_sous_type_bsn__nat_sensib is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_ENTP_BSN"
	cursor c4_dsc_temp_bsn(Vcd_entp_bsn__entreprise varchar) is
		select 1 
		from BSN.CD_ENTP_BSN 
		where 
		ENTREPRISE = Vcd_entp_bsn__entreprise and Vcd_entp_bsn__entreprise is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_EXT_BSN"
	cursor c5_dsc_temp_bsn(Vcd_ext_bsn__type varchar) is
		select 1 
		from BSN.CD_EXT_BSN 
		where 
		TYPE = Vcd_ext_bsn__type and Vcd_ext_bsn__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_PERMEABLE_BSN"
	cursor c6_dsc_temp_bsn(Vcd_permeable_bsn__type varchar) is
		select 1 
		from BSN.CD_PERMEABLE_BSN 
		where 
		TYPE = Vcd_permeable_bsn__type and Vcd_permeable_bsn__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_FREQUENCE_BSN"
	cursor c7_dsc_temp_bsn(Vcd_frequence_bsn__freq varchar) is
		select 1 
		from BSN.CD_FREQUENCE_BSN 
		where 
		FREQ = Vcd_frequence_bsn__freq and Vcd_frequence_bsn__freq is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_ACCES_BSN"
	cursor c8_dsc_temp_bsn(Vcd_acces_bsn__vacces varchar) is
		select 1 
		from BSN.CD_ACCES_BSN 
		where 
		VACCES = Vcd_acces_bsn__vacces and Vcd_acces_bsn__vacces is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CAMP_BSN"
	cursor c9_dsc_temp_bsn(Vcamp_bsn__id_camp varchar) is
		select 1 
		from BSN.CAMP_BSN 
		where 
		ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c10_dsc_temp_bsn(Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	
	--  Le parent "BSN.CD_FAM_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.CD_FAM_BSN__FAMILLE is not null then 
		open c1_dsc_temp_bsn ( :new.CD_FAM_BSN__FAMILLE);
		fetch c1_dsc_temp_bsn into dummy;
		found := c1_dsc_temp_bsn%FOUND;
		close c1_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_FAM_BSN". Impossible de créer un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_TYPE_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.CD_TYPE_BSN__TYPE is not null then 
		open c2_dsc_temp_bsn ( :new.CD_TYPE_BSN__TYPE);
		fetch c2_dsc_temp_bsn into dummy;
		found := c2_dsc_temp_bsn%FOUND;
		close c2_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_TYPE_BSN". Impossible de créer un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_SOUS_TYPE_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.CD_SOUS_TYPE_BSN__NAT_SENSIB is not null then 
		open c3_dsc_temp_bsn ( :new.CD_SOUS_TYPE_BSN__NAT_SENSIB);
		fetch c3_dsc_temp_bsn into dummy;
		found := c3_dsc_temp_bsn%FOUND;
		close c3_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_SOUS_TYPE_BSN". Impossible de créer un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_ENTP_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.CD_ENTP_BSN__ENTREPRISE is not null then 
		open c4_dsc_temp_bsn ( :new.CD_ENTP_BSN__ENTREPRISE);
		fetch c4_dsc_temp_bsn into dummy;
		found := c4_dsc_temp_bsn%FOUND;
		close c4_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ENTP_BSN". Impossible de créer un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_EXT_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.CD_EXT_BSN__TYPE is not null then 
		open c5_dsc_temp_bsn ( :new.CD_EXT_BSN__TYPE);
		fetch c5_dsc_temp_bsn into dummy;
		found := c5_dsc_temp_bsn%FOUND;
		close c5_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_EXT_BSN". Impossible de créer un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_PERMEABLE_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.CD_PERMEABLE_BSN__TYPE is not null then 
		open c6_dsc_temp_bsn ( :new.CD_PERMEABLE_BSN__TYPE);
		fetch c6_dsc_temp_bsn into dummy;
		found := c6_dsc_temp_bsn%FOUND;
		close c6_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_PERMEABLE_BSN". Impossible de créer un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_FREQUENCE_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.CD_FREQUENCE_BSN__FREQ is not null then 
		open c7_dsc_temp_bsn ( :new.CD_FREQUENCE_BSN__FREQ);
		fetch c7_dsc_temp_bsn into dummy;
		found := c7_dsc_temp_bsn%FOUND;
		close c7_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_FREQUENCE_BSN". Impossible de créer un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_ACCES_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.CD_ACCES_BSN__VACCES is not null then 
		open c8_dsc_temp_bsn ( :new.CD_ACCES_BSN__VACCES);
		fetch c8_dsc_temp_bsn into dummy;
		found := c8_dsc_temp_bsn%FOUND;
		close c8_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ACCES_BSN". Impossible de créer un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CAMP_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null then 
		open c9_dsc_temp_bsn ( :new.CAMP_BSN__ID_CAMP);
		fetch c9_dsc_temp_bsn into dummy;
		found := c9_dsc_temp_bsn%FOUND;
		close c9_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CAMP_BSN". Impossible de créer un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.DSC_BSN__NUM_BSN is not null then 
		open c10_dsc_temp_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c10_dsc_temp_bsn into dummy;
		found := c10_dsc_temp_bsn%FOUND;
		close c10_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de créer un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_DSCTEMPBSN" before update
on BSN.DSC_TEMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_FAM_BSN"
	cursor c1_dsc_temp_bsn (Vcd_fam_bsn__famille varchar) is
		select 1 
		from BSN.CD_FAM_BSN 
		where 
		FAMILLE = Vcd_fam_bsn__famille and Vcd_fam_bsn__famille is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_TYPE_BSN"
	cursor c2_dsc_temp_bsn (Vcd_type_bsn__type varchar) is
		select 1 
		from BSN.CD_TYPE_BSN 
		where 
		TYPE = Vcd_type_bsn__type and Vcd_type_bsn__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_SOUS_TYPE_BSN"
	cursor c3_dsc_temp_bsn (Vcd_sous_type_bsn__nat_sensib varchar) is
		select 1 
		from BSN.CD_SOUS_TYPE_BSN 
		where 
		NAT_SENSIB = Vcd_sous_type_bsn__nat_sensib and Vcd_sous_type_bsn__nat_sensib is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_ENTP_BSN"
	cursor c4_dsc_temp_bsn (Vcd_entp_bsn__entreprise varchar) is
		select 1 
		from BSN.CD_ENTP_BSN 
		where 
		ENTREPRISE = Vcd_entp_bsn__entreprise and Vcd_entp_bsn__entreprise is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_EXT_BSN"
	cursor c5_dsc_temp_bsn (Vcd_ext_bsn__type varchar) is
		select 1 
		from BSN.CD_EXT_BSN 
		where 
		TYPE = Vcd_ext_bsn__type and Vcd_ext_bsn__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_PERMEABLE_BSN"
	cursor c6_dsc_temp_bsn (Vcd_permeable_bsn__type varchar) is
		select 1 
		from BSN.CD_PERMEABLE_BSN 
		where 
		TYPE = Vcd_permeable_bsn__type and Vcd_permeable_bsn__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_FREQUENCE_BSN"
	cursor c7_dsc_temp_bsn (Vcd_frequence_bsn__freq varchar) is
		select 1 
		from BSN.CD_FREQUENCE_BSN 
		where 
		FREQ = Vcd_frequence_bsn__freq and Vcd_frequence_bsn__freq is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_ACCES_BSN"
	cursor c8_dsc_temp_bsn (Vcd_acces_bsn__vacces varchar) is
		select 1 
		from BSN.CD_ACCES_BSN 
		where 
		VACCES = Vcd_acces_bsn__vacces and Vcd_acces_bsn__vacces is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CAMP_BSN"
	cursor c9_dsc_temp_bsn (Vcamp_bsn__id_camp varchar) is
		select 1 
		from BSN.CAMP_BSN 
		where 
		ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c10_dsc_temp_bsn (Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.CD_FAM_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.CD_FAM_BSN__FAMILLE is not null and seq = 0 then 
		open c1_dsc_temp_bsn ( :new.CD_FAM_BSN__FAMILLE);
		fetch c1_dsc_temp_bsn into dummy;
		found := c1_dsc_temp_bsn%FOUND;
		close c1_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_FAM_BSN". Impossible de modifier un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_TYPE_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.CD_TYPE_BSN__TYPE is not null and seq = 0 then 
		open c2_dsc_temp_bsn ( :new.CD_TYPE_BSN__TYPE);
		fetch c2_dsc_temp_bsn into dummy;
		found := c2_dsc_temp_bsn%FOUND;
		close c2_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_TYPE_BSN". Impossible de modifier un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_SOUS_TYPE_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.CD_SOUS_TYPE_BSN__NAT_SENSIB is not null and seq = 0 then 
		open c3_dsc_temp_bsn ( :new.CD_SOUS_TYPE_BSN__NAT_SENSIB);
		fetch c3_dsc_temp_bsn into dummy;
		found := c3_dsc_temp_bsn%FOUND;
		close c3_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_SOUS_TYPE_BSN". Impossible de modifier un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_ENTP_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.CD_ENTP_BSN__ENTREPRISE is not null and seq = 0 then 
		open c4_dsc_temp_bsn ( :new.CD_ENTP_BSN__ENTREPRISE);
		fetch c4_dsc_temp_bsn into dummy;
		found := c4_dsc_temp_bsn%FOUND;
		close c4_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ENTP_BSN". Impossible de modifier un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_EXT_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.CD_EXT_BSN__TYPE is not null and seq = 0 then 
		open c5_dsc_temp_bsn ( :new.CD_EXT_BSN__TYPE);
		fetch c5_dsc_temp_bsn into dummy;
		found := c5_dsc_temp_bsn%FOUND;
		close c5_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_EXT_BSN". Impossible de modifier un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_PERMEABLE_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.CD_PERMEABLE_BSN__TYPE is not null and seq = 0 then 
		open c6_dsc_temp_bsn ( :new.CD_PERMEABLE_BSN__TYPE);
		fetch c6_dsc_temp_bsn into dummy;
		found := c6_dsc_temp_bsn%FOUND;
		close c6_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_PERMEABLE_BSN". Impossible de modifier un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_FREQUENCE_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.CD_FREQUENCE_BSN__FREQ is not null and seq = 0 then 
		open c7_dsc_temp_bsn ( :new.CD_FREQUENCE_BSN__FREQ);
		fetch c7_dsc_temp_bsn into dummy;
		found := c7_dsc_temp_bsn%FOUND;
		close c7_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_FREQUENCE_BSN". Impossible de modifier un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_ACCES_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.CD_ACCES_BSN__VACCES is not null and seq = 0 then 
		open c8_dsc_temp_bsn ( :new.CD_ACCES_BSN__VACCES);
		fetch c8_dsc_temp_bsn into dummy;
		found := c8_dsc_temp_bsn%FOUND;
		close c8_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ACCES_BSN". Impossible de modifier un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CAMP_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and seq = 0 then 
		open c9_dsc_temp_bsn ( :new.CAMP_BSN__ID_CAMP);
		fetch c9_dsc_temp_bsn into dummy;
		found := c9_dsc_temp_bsn%FOUND;
		close c9_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CAMP_BSN". Impossible de modifier un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.DSC_TEMP_BSN"
	if :new.DSC_BSN__NUM_BSN is not null and seq = 0 then 
		open c10_dsc_temp_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c10_dsc_temp_bsn into dummy;
		found := c10_dsc_temp_bsn%FOUND;
		close c10_dsc_temp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de modifier un enfant dans "BSN.DSC_TEMP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_DSCTEMPBSN" after update
of CAMP_BSN__ID_CAMP,NUM_BSN
on BSN.DSC_TEMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.DSC_TEMP_BSN" dans les enfants "BSN.INSP_TMP_BSN"
	if ((updating('CAMP_BSN__ID_CAMP') and :old.CAMP_BSN__ID_CAMP != :new.CAMP_BSN__ID_CAMP) or 
	(updating('NUM_BSN') and :old.NUM_BSN != :new.NUM_BSN)) then 
		update BSN.INSP_TMP_BSN
		set CAMP_BSN__ID_CAMP = :new.CAMP_BSN__ID_CAMP,
		DSC_TEMP_BSN__NUM_BSN = :new.NUM_BSN  
		where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
		DSC_TEMP_BSN__NUM_BSN = :old.NUM_BSN;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_DSCTEMPBSN" after delete
on BSN.DSC_TEMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.INSP_TMP_BSN"
	delete BSN.INSP_TMP_BSN
	where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
	DSC_TEMP_BSN__NUM_BSN = :old.NUM_BSN;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_BPUBSN" before insert
on BSN.BPU_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_TRAVAUX_BSN"
	cursor c1_bpu_bsn(Vcd_travaux_bsn__code varchar) is
		select 1 
		from BSN.CD_TRAVAUX_BSN 
		where 
		CODE = Vcd_travaux_bsn__code and Vcd_travaux_bsn__code is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_UNITE_BSN"
	cursor c2_bpu_bsn(Vcd_unite_bsn__unite varchar) is
		select 1 
		from BSN.CD_UNITE_BSN 
		where 
		UNITE = Vcd_unite_bsn__unite and Vcd_unite_bsn__unite is not null;
begin

	
	--  Le parent "BSN.CD_TRAVAUX_BSN" doit exister à la création d'un enfant dans "BSN.BPU_BSN"
	if :new.CD_TRAVAUX_BSN__CODE is not null then 
		open c1_bpu_bsn ( :new.CD_TRAVAUX_BSN__CODE);
		fetch c1_bpu_bsn into dummy;
		found := c1_bpu_bsn%FOUND;
		close c1_bpu_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_TRAVAUX_BSN". Impossible de créer un enfant dans "BSN.BPU_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_UNITE_BSN" doit exister à la création d'un enfant dans "BSN.BPU_BSN"
	if :new.CD_UNITE_BSN__UNITE is not null then 
		open c2_bpu_bsn ( :new.CD_UNITE_BSN__UNITE);
		fetch c2_bpu_bsn into dummy;
		found := c2_bpu_bsn%FOUND;
		close c2_bpu_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_UNITE_BSN". Impossible de créer un enfant dans "BSN.BPU_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_BPUBSN" before update
on BSN.BPU_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_TRAVAUX_BSN"
	cursor c1_bpu_bsn (Vcd_travaux_bsn__code varchar) is
		select 1 
		from BSN.CD_TRAVAUX_BSN 
		where 
		CODE = Vcd_travaux_bsn__code and Vcd_travaux_bsn__code is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_UNITE_BSN"
	cursor c2_bpu_bsn (Vcd_unite_bsn__unite varchar) is
		select 1 
		from BSN.CD_UNITE_BSN 
		where 
		UNITE = Vcd_unite_bsn__unite and Vcd_unite_bsn__unite is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.CD_TRAVAUX_BSN" doit exister à la création d'un enfant dans "BSN.BPU_BSN"
	if :new.CD_TRAVAUX_BSN__CODE is not null and seq = 0 then 
		open c1_bpu_bsn ( :new.CD_TRAVAUX_BSN__CODE);
		fetch c1_bpu_bsn into dummy;
		found := c1_bpu_bsn%FOUND;
		close c1_bpu_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_TRAVAUX_BSN". Impossible de modifier un enfant dans "BSN.BPU_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_UNITE_BSN" doit exister à la création d'un enfant dans "BSN.BPU_BSN"
	if :new.CD_UNITE_BSN__UNITE is not null and seq = 0 then 
		open c2_bpu_bsn ( :new.CD_UNITE_BSN__UNITE);
		fetch c2_bpu_bsn into dummy;
		found := c2_bpu_bsn%FOUND;
		close c2_bpu_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_UNITE_BSN". Impossible de modifier un enfant dans "BSN.BPU_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_BPUBSN" after update
of ID_BPU
on BSN.BPU_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.BPU_BSN" dans les enfants "BSN.PREVISION_BSN"
	if ((updating('ID_BPU') and :old.ID_BPU != :new.ID_BPU)) then 
		update BSN.PREVISION_BSN
		set BPU_BSN__ID_BPU = :new.ID_BPU  
		where BPU_BSN__ID_BPU = :old.ID_BPU;
	end if;
	--  Modification du code du parent "BSN.BPU_BSN" dans les enfants "BSN.CD_PRECO__SPRT_VST_BSN"
	if ((updating('ID_BPU') and :old.ID_BPU != :new.ID_BPU)) then 
		update BSN.CD_PRECO__SPRT_VST_BSN
		set BPU_BSN__ID_BPU = :new.ID_BPU  
		where BPU_BSN__ID_BPU = :old.ID_BPU;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_BPUBSN" after delete
on BSN.BPU_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.PREVISION_BSN"
	delete BSN.PREVISION_BSN
	where BPU_BSN__ID_BPU = :old.ID_BPU;
	
	--  Suppression des enfants dans "BSN.CD_PRECO__SPRT_VST_BSN"
	delete BSN.CD_PRECO__SPRT_VST_BSN
	where BPU_BSN__ID_BPU = :old.ID_BPU;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_CAMPBSN" before insert
on BSN.CAMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_PRESTA_BSN"
	cursor c1_camp_bsn(Vcd_presta_bsn__prestataire varchar) is
		select 1 
		from BSN.CD_PRESTA_BSN 
		where 
		PRESTATAIRE = Vcd_presta_bsn__prestataire and Vcd_presta_bsn__prestataire is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_TYPE_PV_BSN"
	cursor c2_camp_bsn(Vcd_type_pv_bsn__code varchar) is
		select 1 
		from BSN.CD_TYPE_PV_BSN 
		where 
		CODE = Vcd_type_pv_bsn__code and Vcd_type_pv_bsn__code is not null;
begin

	
	--  Le parent "BSN.CD_PRESTA_BSN" doit exister à la création d'un enfant dans "BSN.CAMP_BSN"
	if :new.CD_PRESTA_BSN__PRESTATAIRE is not null then 
		open c1_camp_bsn ( :new.CD_PRESTA_BSN__PRESTATAIRE);
		fetch c1_camp_bsn into dummy;
		found := c1_camp_bsn%FOUND;
		close c1_camp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_PRESTA_BSN". Impossible de créer un enfant dans "BSN.CAMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_TYPE_PV_BSN" doit exister à la création d'un enfant dans "BSN.CAMP_BSN"
	if :new.CD_TYPE_PV_BSN__CODE is not null then 
		open c2_camp_bsn ( :new.CD_TYPE_PV_BSN__CODE);
		fetch c2_camp_bsn into dummy;
		found := c2_camp_bsn%FOUND;
		close c2_camp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_TYPE_PV_BSN". Impossible de créer un enfant dans "BSN.CAMP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_CAMPBSN" before update
on BSN.CAMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_PRESTA_BSN"
	cursor c1_camp_bsn (Vcd_presta_bsn__prestataire varchar) is
		select 1 
		from BSN.CD_PRESTA_BSN 
		where 
		PRESTATAIRE = Vcd_presta_bsn__prestataire and Vcd_presta_bsn__prestataire is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_TYPE_PV_BSN"
	cursor c2_camp_bsn (Vcd_type_pv_bsn__code varchar) is
		select 1 
		from BSN.CD_TYPE_PV_BSN 
		where 
		CODE = Vcd_type_pv_bsn__code and Vcd_type_pv_bsn__code is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.CD_PRESTA_BSN" doit exister à la création d'un enfant dans "BSN.CAMP_BSN"
	if :new.CD_PRESTA_BSN__PRESTATAIRE is not null and seq = 0 then 
		open c1_camp_bsn ( :new.CD_PRESTA_BSN__PRESTATAIRE);
		fetch c1_camp_bsn into dummy;
		found := c1_camp_bsn%FOUND;
		close c1_camp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_PRESTA_BSN". Impossible de modifier un enfant dans "BSN.CAMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_TYPE_PV_BSN" doit exister à la création d'un enfant dans "BSN.CAMP_BSN"
	if :new.CD_TYPE_PV_BSN__CODE is not null and seq = 0 then 
		open c2_camp_bsn ( :new.CD_TYPE_PV_BSN__CODE);
		fetch c2_camp_bsn into dummy;
		found := c2_camp_bsn%FOUND;
		close c2_camp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_TYPE_PV_BSN". Impossible de modifier un enfant dans "BSN.CAMP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_CAMPBSN" after update
of ID_CAMP
on BSN.CAMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CAMP_BSN" dans les enfants "BSN.INSP_BSN"
	if ((updating('ID_CAMP') and :old.ID_CAMP != :new.ID_CAMP)) then 
		update BSN.INSP_BSN
		set CAMP_BSN__ID_CAMP = :new.ID_CAMP  
		where CAMP_BSN__ID_CAMP = :old.ID_CAMP;
	end if;
	--  Modification du code du parent "BSN.CAMP_BSN" dans les enfants "BSN.VST_BSN"
	if ((updating('ID_CAMP') and :old.ID_CAMP != :new.ID_CAMP)) then 
		update BSN.VST_BSN
		set CAMP_BSN__ID_CAMP = :new.ID_CAMP  
		where CAMP_BSN__ID_CAMP = :old.ID_CAMP;
	end if;
	--  Modification du code du parent "BSN.CAMP_BSN" dans les enfants "BSN.DSC_TEMP_BSN"
	if ((updating('ID_CAMP') and :old.ID_CAMP != :new.ID_CAMP)) then 
		update BSN.DSC_TEMP_BSN
		set CAMP_BSN__ID_CAMP = :new.ID_CAMP  
		where CAMP_BSN__ID_CAMP = :old.ID_CAMP;
	end if;
	--  Modification du code du parent "BSN.CAMP_BSN" dans les enfants "BSN.DSC_CAMP_BSN"
	if ((updating('ID_CAMP') and :old.ID_CAMP != :new.ID_CAMP)) then 
		update BSN.DSC_CAMP_BSN
		set CAMP_BSN__ID_CAMP = :new.ID_CAMP  
		where CAMP_BSN__ID_CAMP = :old.ID_CAMP;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CAMPBSN" after delete
on BSN.CAMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.INSP_BSN"
	delete BSN.INSP_BSN
	where CAMP_BSN__ID_CAMP = :old.ID_CAMP;
	
	--  Suppression des enfants dans "BSN.VST_BSN"
	delete BSN.VST_BSN
	where CAMP_BSN__ID_CAMP = :old.ID_CAMP;
	
	--  Suppression des enfants dans "BSN.DSC_TEMP_BSN"
	delete BSN.DSC_TEMP_BSN
	where CAMP_BSN__ID_CAMP = :old.ID_CAMP;
	
	--  Suppression des enfants dans "BSN.DSC_CAMP_BSN"
	delete BSN.DSC_CAMP_BSN
	where CAMP_BSN__ID_CAMP = :old.ID_CAMP;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TUA_CDCHAPITREBSN" after update
of ID_CHAP
on BSN.CD_CHAPITRE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_CHAPITRE_BSN" dans les enfants "BSN.CD_LIGNE_BSN"
	if ((updating('ID_CHAP') and :old.ID_CHAP != :new.ID_CHAP)) then 
		update BSN.CD_LIGNE_BSN
		set CD_CHAPITRE_BSN__ID_CHAP = :new.ID_CHAP  
		where CD_CHAPITRE_BSN__ID_CHAP = :old.ID_CHAP;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDCHAPITREBSN" after delete
on BSN.CD_CHAPITRE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.CD_LIGNE_BSN"
	delete BSN.CD_LIGNE_BSN
	where CD_CHAPITRE_BSN__ID_CHAP = :old.ID_CHAP;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TUA_CLSBSN" after update
of ID
on BSN.CLS_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CLS_BSN" dans les enfants "BSN.CLS_DOC_BSN"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update BSN.CLS_DOC_BSN
		set CLS__ID = :new.ID  
		where CLS__ID = :old.ID;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CLSBSN" after delete
on BSN.CLS_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.CLS_DOC_BSN"
	delete BSN.CLS_DOC_BSN
	where CLS__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TUA_CDCONCLUSIONBSN" after update
of ID_CONC
on BSN.CD_CONCLUSION_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_CONCLUSION_BSN" dans les enfants "BSN.CD_CONCLUSION__INSP_BSN"
	if ((updating('ID_CONC') and :old.ID_CONC != :new.ID_CONC)) then 
		update BSN.CD_CONCLUSION__INSP_BSN
		set CD_CONCLUSION_BSN__ID_CONC = :new.ID_CONC  
		where CD_CONCLUSION_BSN__ID_CONC = :old.ID_CONC;
	end if;
	--  Modification du code du parent "BSN.CD_CONCLUSION_BSN" dans les enfants "BSN.CD_CONCLUSION__INSP_TMP_BSN"
	if ((updating('ID_CONC') and :old.ID_CONC != :new.ID_CONC)) then 
		update BSN.CD_CONCLUSION__INSP_TMP_BSN
		set CD_CONCLUSION_BSN__ID_CONC = :new.ID_CONC  
		where CD_CONCLUSION_BSN__ID_CONC = :old.ID_CONC;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDCONCLUSIONBSN" after delete
on BSN.CD_CONCLUSION_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.CD_CONCLUSION__INSP_BSN"
	delete BSN.CD_CONCLUSION__INSP_BSN
	where CD_CONCLUSION_BSN__ID_CONC = :old.ID_CONC;
	
	--  Suppression des enfants dans "BSN.CD_CONCLUSION__INSP_TMP_BSN"
	delete BSN.CD_CONCLUSION__INSP_TMP_BSN
	where CD_CONCLUSION_BSN__ID_CONC = :old.ID_CONC;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TUA_CDQUALITEBSN" after update
of QUALITE
on BSN.CD_QUALITE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_QUALITE_BSN" dans les enfants "BSN.SEUIL_QUALITE_BSN"
	if ((updating('QUALITE') and :old.QUALITE != :new.QUALITE)) then 
		update BSN.SEUIL_QUALITE_BSN
		set CD_QUALITE_BSN__QUALITE = :new.QUALITE  
		where CD_QUALITE_BSN__QUALITE = :old.QUALITE;
	end if;
	--  Modification du code du parent "BSN.CD_QUALITE_BSN" dans les enfants "BSN.DSC_BSN"
	if ((updating('QUALITE') and :old.QUALITE != :new.QUALITE)) then 
		update BSN.DSC_BSN
		set CD_QUALITE_BSN__QUALITE = :new.QUALITE  
		where CD_QUALITE_BSN__QUALITE = :old.QUALITE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDQUALITEBSN" after delete
on BSN.CD_QUALITE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.SEUIL_QUALITE_BSN"
	delete BSN.SEUIL_QUALITE_BSN
	where CD_QUALITE_BSN__QUALITE = :old.QUALITE;
	
	--  Suppression des enfants dans "BSN.DSC_BSN"
	delete BSN.DSC_BSN
	where CD_QUALITE_BSN__QUALITE = :old.QUALITE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_CDCONCLUSIONINSPBSN" before insert
on BSN.CD_CONCLUSION__INSP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.INSP_BSN"
	cursor c1_cd_conclusion__insp_bsn(Vcamp_bsn__id_camp varchar,
	Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.INSP_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_BSN__NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_CONCLUSION_BSN"
	cursor c2_cd_conclusion__insp_bsn(Vcd_conclusion_bsn__id_conc number) is
		select 1 
		from BSN.CD_CONCLUSION_BSN 
		where 
		ID_CONC = Vcd_conclusion_bsn__id_conc and Vcd_conclusion_bsn__id_conc is not null;
begin

	
	--  Le parent "BSN.INSP_BSN" doit exister à la création d'un enfant dans "BSN.CD_CONCLUSION__INSP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and 
	:new.DSC_BSN__NUM_BSN is not null then 
		open c1_cd_conclusion__insp_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_BSN__NUM_BSN);
		fetch c1_cd_conclusion__insp_bsn into dummy;
		found := c1_cd_conclusion__insp_bsn%FOUND;
		close c1_cd_conclusion__insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.INSP_BSN". Impossible de créer un enfant dans "BSN.CD_CONCLUSION__INSP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_CONCLUSION_BSN" doit exister à la création d'un enfant dans "BSN.CD_CONCLUSION__INSP_BSN"
	if :new.CD_CONCLUSION_BSN__ID_CONC is not null then 
		open c2_cd_conclusion__insp_bsn ( :new.CD_CONCLUSION_BSN__ID_CONC);
		fetch c2_cd_conclusion__insp_bsn into dummy;
		found := c2_cd_conclusion__insp_bsn%FOUND;
		close c2_cd_conclusion__insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_CONCLUSION_BSN". Impossible de créer un enfant dans "BSN.CD_CONCLUSION__INSP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_CDCONCLUSIONINSPBSN" before update
on BSN.CD_CONCLUSION__INSP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.INSP_BSN"
	cursor c1_cd_conclusion__insp_bsn (Vcamp_bsn__id_camp varchar,
	Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.INSP_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_BSN__NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_CONCLUSION_BSN"
	cursor c2_cd_conclusion__insp_bsn (Vcd_conclusion_bsn__id_conc number) is
		select 1 
		from BSN.CD_CONCLUSION_BSN 
		where 
		ID_CONC = Vcd_conclusion_bsn__id_conc and Vcd_conclusion_bsn__id_conc is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.INSP_BSN" doit exister à la création d'un enfant dans "BSN.CD_CONCLUSION__INSP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and seq = 0 and 
	:new.DSC_BSN__NUM_BSN is not null and seq = 0 then 
		open c1_cd_conclusion__insp_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_BSN__NUM_BSN);
		fetch c1_cd_conclusion__insp_bsn into dummy;
		found := c1_cd_conclusion__insp_bsn%FOUND;
		close c1_cd_conclusion__insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.INSP_BSN". Impossible de modifier un enfant dans "BSN.CD_CONCLUSION__INSP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_CONCLUSION_BSN" doit exister à la création d'un enfant dans "BSN.CD_CONCLUSION__INSP_BSN"
	if :new.CD_CONCLUSION_BSN__ID_CONC is not null and seq = 0 then 
		open c2_cd_conclusion__insp_bsn ( :new.CD_CONCLUSION_BSN__ID_CONC);
		fetch c2_cd_conclusion__insp_bsn into dummy;
		found := c2_cd_conclusion__insp_bsn%FOUND;
		close c2_cd_conclusion__insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_CONCLUSION_BSN". Impossible de modifier un enfant dans "BSN.CD_CONCLUSION__INSP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TIB_CDCONCLUSIONINSPTMPBSN" before insert
on BSN.CD_CONCLUSION__INSP_TMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_CONCLUSION_BSN"
	cursor c1_cd_conclusion__insp_tmp_bsn(Vcd_conclusion_bsn__id_conc number) is
		select 1 
		from BSN.CD_CONCLUSION_BSN 
		where 
		ID_CONC = Vcd_conclusion_bsn__id_conc and Vcd_conclusion_bsn__id_conc is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.INSP_TMP_BSN"
	cursor c2_cd_conclusion__insp_tmp_bsn(Vcamp_bsn__id_camp varchar,
	Vdsc_temp_bsn__num_bsn varchar) is
		select 1 
		from BSN.INSP_TMP_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_TEMP_BSN__NUM_BSN = Vdsc_temp_bsn__num_bsn and Vdsc_temp_bsn__num_bsn is not null;
begin

	
	--  Le parent "BSN.CD_CONCLUSION_BSN" doit exister à la création d'un enfant dans "BSN.CD_CONCLUSION__INSP_TMP_BSN"
	if :new.CD_CONCLUSION_BSN__ID_CONC is not null then 
		open c1_cd_conclusion__insp_tmp_bsn ( :new.CD_CONCLUSION_BSN__ID_CONC);
		fetch c1_cd_conclusion__insp_tmp_bsn into dummy;
		found := c1_cd_conclusion__insp_tmp_bsn%FOUND;
		close c1_cd_conclusion__insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_CONCLUSION_BSN". Impossible de créer un enfant dans "BSN.CD_CONCLUSION__INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.INSP_TMP_BSN" doit exister à la création d'un enfant dans "BSN.CD_CONCLUSION__INSP_TMP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and 
	:new.DSC_TEMP_BSN__NUM_BSN is not null then 
		open c2_cd_conclusion__insp_tmp_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_TEMP_BSN__NUM_BSN);
		fetch c2_cd_conclusion__insp_tmp_bsn into dummy;
		found := c2_cd_conclusion__insp_tmp_bsn%FOUND;
		close c2_cd_conclusion__insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.INSP_TMP_BSN". Impossible de créer un enfant dans "BSN.CD_CONCLUSION__INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_CDCONCLUSIONINSPTMPBSN" before update
on BSN.CD_CONCLUSION__INSP_TMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_CONCLUSION_BSN"
	cursor c1_cd_conclusion__insp_tmp_bsn (Vcd_conclusion_bsn__id_conc number) is
		select 1 
		from BSN.CD_CONCLUSION_BSN 
		where 
		ID_CONC = Vcd_conclusion_bsn__id_conc and Vcd_conclusion_bsn__id_conc is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.INSP_TMP_BSN"
	cursor c2_cd_conclusion__insp_tmp_bsn (Vcamp_bsn__id_camp varchar,
	Vdsc_temp_bsn__num_bsn varchar) is
		select 1 
		from BSN.INSP_TMP_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_TEMP_BSN__NUM_BSN = Vdsc_temp_bsn__num_bsn and Vdsc_temp_bsn__num_bsn is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.CD_CONCLUSION_BSN" doit exister à la création d'un enfant dans "BSN.CD_CONCLUSION__INSP_TMP_BSN"
	if :new.CD_CONCLUSION_BSN__ID_CONC is not null and seq = 0 then 
		open c1_cd_conclusion__insp_tmp_bsn ( :new.CD_CONCLUSION_BSN__ID_CONC);
		fetch c1_cd_conclusion__insp_tmp_bsn into dummy;
		found := c1_cd_conclusion__insp_tmp_bsn%FOUND;
		close c1_cd_conclusion__insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_CONCLUSION_BSN". Impossible de modifier un enfant dans "BSN.CD_CONCLUSION__INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.INSP_TMP_BSN" doit exister à la création d'un enfant dans "BSN.CD_CONCLUSION__INSP_TMP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and seq = 0 and 
	:new.DSC_TEMP_BSN__NUM_BSN is not null and seq = 0 then 
		open c2_cd_conclusion__insp_tmp_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_TEMP_BSN__NUM_BSN);
		fetch c2_cd_conclusion__insp_tmp_bsn into dummy;
		found := c2_cd_conclusion__insp_tmp_bsn%FOUND;
		close c2_cd_conclusion__insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.INSP_TMP_BSN". Impossible de modifier un enfant dans "BSN.CD_CONCLUSION__INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TIB_CONTACTBSN" before insert
on BSN.CONTACT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.DOC_BSN"
	cursor c1_contact_bsn(Vdoc__id number) is
		select 1 
		from BSN.DOC_BSN 
		where 
		ID = Vdoc__id and Vdoc__id is not null;
begin

	
	--  Le parent "BSN.DOC_BSN" doit exister à la création d'un enfant dans "BSN.CONTACT_BSN"
	if :new.DOC__ID is not null then 
		open c1_contact_bsn ( :new.DOC__ID);
		fetch c1_contact_bsn into dummy;
		found := c1_contact_bsn%FOUND;
		close c1_contact_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DOC_BSN". Impossible de créer un enfant dans "BSN.CONTACT_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_CONTACTBSN" before update
on BSN.CONTACT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.DOC_BSN"
	cursor c1_contact_bsn (Vdoc__id number) is
		select 1 
		from BSN.DOC_BSN 
		where 
		ID = Vdoc__id and Vdoc__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.DOC_BSN" doit exister à la création d'un enfant dans "BSN.CONTACT_BSN"
	if :new.DOC__ID is not null and seq = 0 then 
		open c1_contact_bsn ( :new.DOC__ID);
		fetch c1_contact_bsn into dummy;
		found := c1_contact_bsn%FOUND;
		close c1_contact_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DOC_BSN". Impossible de modifier un enfant dans "BSN.CONTACT_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TIB_CLSDOCBSN" before insert
on BSN.CLS_DOC_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CLS_BSN"
	cursor c1_cls_doc_bsn(Vcls__id number) is
		select 1 
		from BSN.CLS_BSN 
		where 
		ID = Vcls__id and Vcls__id is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.DOC_BSN"
	cursor c2_cls_doc_bsn(Vdoc__id number) is
		select 1 
		from BSN.DOC_BSN 
		where 
		ID = Vdoc__id and Vdoc__id is not null;
begin

	
	--  Le parent "BSN.CLS_BSN" doit exister à la création d'un enfant dans "BSN.CLS_DOC_BSN"
	if :new.CLS__ID is not null then 
		open c1_cls_doc_bsn ( :new.CLS__ID);
		fetch c1_cls_doc_bsn into dummy;
		found := c1_cls_doc_bsn%FOUND;
		close c1_cls_doc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CLS_BSN". Impossible de créer un enfant dans "BSN.CLS_DOC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.DOC_BSN" doit exister à la création d'un enfant dans "BSN.CLS_DOC_BSN"
	if :new.DOC__ID is not null then 
		open c2_cls_doc_bsn ( :new.DOC__ID);
		fetch c2_cls_doc_bsn into dummy;
		found := c2_cls_doc_bsn%FOUND;
		close c2_cls_doc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DOC_BSN". Impossible de créer un enfant dans "BSN.CLS_DOC_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_CLSDOCBSN" before update
on BSN.CLS_DOC_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CLS_BSN"
	cursor c1_cls_doc_bsn (Vcls__id number) is
		select 1 
		from BSN.CLS_BSN 
		where 
		ID = Vcls__id and Vcls__id is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.DOC_BSN"
	cursor c2_cls_doc_bsn (Vdoc__id number) is
		select 1 
		from BSN.DOC_BSN 
		where 
		ID = Vdoc__id and Vdoc__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.CLS_BSN" doit exister à la création d'un enfant dans "BSN.CLS_DOC_BSN"
	if :new.CLS__ID is not null and seq = 0 then 
		open c1_cls_doc_bsn ( :new.CLS__ID);
		fetch c1_cls_doc_bsn into dummy;
		found := c1_cls_doc_bsn%FOUND;
		close c1_cls_doc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CLS_BSN". Impossible de modifier un enfant dans "BSN.CLS_DOC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.DOC_BSN" doit exister à la création d'un enfant dans "BSN.CLS_DOC_BSN"
	if :new.DOC__ID is not null and seq = 0 then 
		open c2_cls_doc_bsn ( :new.DOC__ID);
		fetch c2_cls_doc_bsn into dummy;
		found := c2_cls_doc_bsn%FOUND;
		close c2_cls_doc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DOC_BSN". Impossible de modifier un enfant dans "BSN.CLS_DOC_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_CDCONTRAINTEBSN" after update
of TYPE
on BSN.CD_CONTRAINTE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_CONTRAINTE_BSN" dans les enfants "BSN.PREVISION_BSN"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update BSN.PREVISION_BSN
		set CD_CONTRAINTE_BSN__TYPE = :new.TYPE  
		where CD_CONTRAINTE_BSN__TYPE = :old.TYPE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDCONTRAINTEBSN" after delete
on BSN.CD_CONTRAINTE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.PREVISION_BSN"
	delete BSN.PREVISION_BSN
	where CD_CONTRAINTE_BSN__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_EQUIPEMENTBSN" before insert
on BSN.EQUIPEMENT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_TYPEQP_BSN"
	cursor c1_equipement_bsn(Vcd_fameqp_bsn__fam varchar,
	Vcd_typeqp_bsn__type varchar) is
		select 1 
		from BSN.CD_TYPEQP_BSN 
		where 
		CD_FAMEQP_BSN__FAM = Vcd_fameqp_bsn__fam and Vcd_fameqp_bsn__fam is not null and 
		TYPE = Vcd_typeqp_bsn__type and Vcd_typeqp_bsn__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c2_equipement_bsn(Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	
	--  Le parent "BSN.CD_TYPEQP_BSN" doit exister à la création d'un enfant dans "BSN.EQUIPEMENT_BSN"
	if :new.CD_FAMEQP_BSN__FAM is not null and 
	:new.CD_TYPEQP_BSN__TYPE is not null then 
		open c1_equipement_bsn ( :new.CD_FAMEQP_BSN__FAM,
		:new.CD_TYPEQP_BSN__TYPE);
		fetch c1_equipement_bsn into dummy;
		found := c1_equipement_bsn%FOUND;
		close c1_equipement_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_TYPEQP_BSN". Impossible de créer un enfant dans "BSN.EQUIPEMENT_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.EQUIPEMENT_BSN"
	if :new.DSC_BSN__NUM_BSN is not null then 
		open c2_equipement_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c2_equipement_bsn into dummy;
		found := c2_equipement_bsn%FOUND;
		close c2_equipement_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de créer un enfant dans "BSN.EQUIPEMENT_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_EQUIPEMENTBSN" before update
on BSN.EQUIPEMENT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_TYPEQP_BSN"
	cursor c1_equipement_bsn (Vcd_fameqp_bsn__fam varchar,
	Vcd_typeqp_bsn__type varchar) is
		select 1 
		from BSN.CD_TYPEQP_BSN 
		where 
		CD_FAMEQP_BSN__FAM = Vcd_fameqp_bsn__fam and Vcd_fameqp_bsn__fam is not null and 
		TYPE = Vcd_typeqp_bsn__type and Vcd_typeqp_bsn__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c2_equipement_bsn (Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.CD_TYPEQP_BSN" doit exister à la création d'un enfant dans "BSN.EQUIPEMENT_BSN"
	if :new.CD_FAMEQP_BSN__FAM is not null and seq = 0 and 
	:new.CD_TYPEQP_BSN__TYPE is not null and seq = 0 then 
		open c1_equipement_bsn ( :new.CD_FAMEQP_BSN__FAM,
		:new.CD_TYPEQP_BSN__TYPE);
		fetch c1_equipement_bsn into dummy;
		found := c1_equipement_bsn%FOUND;
		close c1_equipement_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_TYPEQP_BSN". Impossible de modifier un enfant dans "BSN.EQUIPEMENT_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.EQUIPEMENT_BSN"
	if :new.DSC_BSN__NUM_BSN is not null and seq = 0 then 
		open c2_equipement_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c2_equipement_bsn into dummy;
		found := c2_equipement_bsn%FOUND;
		close c2_equipement_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de modifier un enfant dans "BSN.EQUIPEMENT_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TIB_ELTINSPBSN" before insert
on BSN.ELT_INSP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.ELT_BSN"
	cursor c1_elt_insp_bsn(Vgrp_bsn__id_grp number,
	Vprt_bsn__id_prt number,
	Vsprt_bsn__id_sprt number,
	Velt_bsn__id_elem number) is
		select 1 
		from BSN.ELT_BSN 
		where 
		GRP_BSN__ID_GRP = Vgrp_bsn__id_grp and Vgrp_bsn__id_grp is not null and 
		PRT_BSN__ID_PRT = Vprt_bsn__id_prt and Vprt_bsn__id_prt is not null and 
		SPRT_BSN__ID_SPRT = Vsprt_bsn__id_sprt and Vsprt_bsn__id_sprt is not null and 
		ID_ELEM = Velt_bsn__id_elem and Velt_bsn__id_elem is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.INSP_BSN"
	cursor c2_elt_insp_bsn(Vcamp_bsn__id_camp varchar,
	Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.INSP_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_BSN__NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	
	--  Le parent "BSN.ELT_BSN" doit exister à la création d'un enfant dans "BSN.ELT_INSP_BSN"
	if :new.GRP_BSN__ID_GRP is not null and 
	:new.PRT_BSN__ID_PRT is not null and 
	:new.SPRT_BSN__ID_SPRT is not null and 
	:new.ELT_BSN__ID_ELEM is not null then 
		open c1_elt_insp_bsn ( :new.GRP_BSN__ID_GRP,
		:new.PRT_BSN__ID_PRT,
		:new.SPRT_BSN__ID_SPRT,
		:new.ELT_BSN__ID_ELEM);
		fetch c1_elt_insp_bsn into dummy;
		found := c1_elt_insp_bsn%FOUND;
		close c1_elt_insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.ELT_BSN". Impossible de créer un enfant dans "BSN.ELT_INSP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.INSP_BSN" doit exister à la création d'un enfant dans "BSN.ELT_INSP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and 
	:new.DSC_BSN__NUM_BSN is not null then 
		open c2_elt_insp_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_BSN__NUM_BSN);
		fetch c2_elt_insp_bsn into dummy;
		found := c2_elt_insp_bsn%FOUND;
		close c2_elt_insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.INSP_BSN". Impossible de créer un enfant dans "BSN.ELT_INSP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_ELTINSPBSN" before update
on BSN.ELT_INSP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.ELT_BSN"
	cursor c1_elt_insp_bsn (Vgrp_bsn__id_grp number,
	Vprt_bsn__id_prt number,
	Vsprt_bsn__id_sprt number,
	Velt_bsn__id_elem number) is
		select 1 
		from BSN.ELT_BSN 
		where 
		GRP_BSN__ID_GRP = Vgrp_bsn__id_grp and Vgrp_bsn__id_grp is not null and 
		PRT_BSN__ID_PRT = Vprt_bsn__id_prt and Vprt_bsn__id_prt is not null and 
		SPRT_BSN__ID_SPRT = Vsprt_bsn__id_sprt and Vsprt_bsn__id_sprt is not null and 
		ID_ELEM = Velt_bsn__id_elem and Velt_bsn__id_elem is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.INSP_BSN"
	cursor c2_elt_insp_bsn (Vcamp_bsn__id_camp varchar,
	Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.INSP_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_BSN__NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.ELT_BSN" doit exister à la création d'un enfant dans "BSN.ELT_INSP_BSN"
	if :new.GRP_BSN__ID_GRP is not null and seq = 0 and 
	:new.PRT_BSN__ID_PRT is not null and seq = 0 and 
	:new.SPRT_BSN__ID_SPRT is not null and seq = 0 and 
	:new.ELT_BSN__ID_ELEM is not null and seq = 0 then 
		open c1_elt_insp_bsn ( :new.GRP_BSN__ID_GRP,
		:new.PRT_BSN__ID_PRT,
		:new.SPRT_BSN__ID_SPRT,
		:new.ELT_BSN__ID_ELEM);
		fetch c1_elt_insp_bsn into dummy;
		found := c1_elt_insp_bsn%FOUND;
		close c1_elt_insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.ELT_BSN". Impossible de modifier un enfant dans "BSN.ELT_INSP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.INSP_BSN" doit exister à la création d'un enfant dans "BSN.ELT_INSP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and seq = 0 and 
	:new.DSC_BSN__NUM_BSN is not null and seq = 0 then 
		open c2_elt_insp_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_BSN__NUM_BSN);
		fetch c2_elt_insp_bsn into dummy;
		found := c2_elt_insp_bsn%FOUND;
		close c2_elt_insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.INSP_BSN". Impossible de modifier un enfant dans "BSN.ELT_INSP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_ELTINSPBSN" after update
of GRP_BSN__ID_GRP,PRT_BSN__ID_PRT,SPRT_BSN__ID_SPRT,CAMP_BSN__ID_CAMP,ELT_BSN__ID_ELEM,DSC_BSN__NUM_BSN
on BSN.ELT_INSP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.ELT_INSP_BSN" dans les enfants "BSN.PHOTO_ELT_INSP_BSN"
	if ((updating('GRP_BSN__ID_GRP') and :old.GRP_BSN__ID_GRP != :new.GRP_BSN__ID_GRP) or 
	(updating('PRT_BSN__ID_PRT') and :old.PRT_BSN__ID_PRT != :new.PRT_BSN__ID_PRT) or 
	(updating('SPRT_BSN__ID_SPRT') and :old.SPRT_BSN__ID_SPRT != :new.SPRT_BSN__ID_SPRT) or 
	(updating('CAMP_BSN__ID_CAMP') and :old.CAMP_BSN__ID_CAMP != :new.CAMP_BSN__ID_CAMP) or 
	(updating('ELT_BSN__ID_ELEM') and :old.ELT_BSN__ID_ELEM != :new.ELT_BSN__ID_ELEM) or 
	(updating('DSC_BSN__NUM_BSN') and :old.DSC_BSN__NUM_BSN != :new.DSC_BSN__NUM_BSN)) then 
		update BSN.PHOTO_ELT_INSP_BSN
		set GRP_BSN__ID_GRP = :new.GRP_BSN__ID_GRP,
		PRT_BSN__ID_PRT = :new.PRT_BSN__ID_PRT,
		SPRT_BSN__ID_SPRT = :new.SPRT_BSN__ID_SPRT,
		CAMP_BSN__ID_CAMP = :new.CAMP_BSN__ID_CAMP,
		ELT_BSN__ID_ELEM = :new.ELT_BSN__ID_ELEM,
		DSC_BSN__NUM_BSN = :new.DSC_BSN__NUM_BSN  
		where GRP_BSN__ID_GRP = :old.GRP_BSN__ID_GRP and 
		PRT_BSN__ID_PRT = :old.PRT_BSN__ID_PRT and 
		SPRT_BSN__ID_SPRT = :old.SPRT_BSN__ID_SPRT and 
		CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
		ELT_BSN__ID_ELEM = :old.ELT_BSN__ID_ELEM and 
		DSC_BSN__NUM_BSN = :old.DSC_BSN__NUM_BSN;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_ELTINSPBSN" after delete
on BSN.ELT_INSP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.PHOTO_ELT_INSP_BSN"
	delete BSN.PHOTO_ELT_INSP_BSN
	where GRP_BSN__ID_GRP = :old.GRP_BSN__ID_GRP and 
	PRT_BSN__ID_PRT = :old.PRT_BSN__ID_PRT and 
	SPRT_BSN__ID_SPRT = :old.SPRT_BSN__ID_SPRT and 
	CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
	ELT_BSN__ID_ELEM = :old.ELT_BSN__ID_ELEM and 
	DSC_BSN__NUM_BSN = :old.DSC_BSN__NUM_BSN;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_ELTINSPTMPBSN" before insert
on BSN.ELT_INSP_TMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.INSP_TMP_BSN"
	cursor c1_elt_insp_tmp_bsn(Vcamp_bsn__id_camp varchar,
	Vdsc_temp_bsn__num_bsn varchar) is
		select 1 
		from BSN.INSP_TMP_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_TEMP_BSN__NUM_BSN = Vdsc_temp_bsn__num_bsn and Vdsc_temp_bsn__num_bsn is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.ELT_BSN"
	cursor c2_elt_insp_tmp_bsn(Vgrp_bsn__id_grp number,
	Vprt_bsn__id_prt number,
	Vsprt_bsn__id_sprt number,
	Velt_bsn__id_elem number) is
		select 1 
		from BSN.ELT_BSN 
		where 
		GRP_BSN__ID_GRP = Vgrp_bsn__id_grp and Vgrp_bsn__id_grp is not null and 
		PRT_BSN__ID_PRT = Vprt_bsn__id_prt and Vprt_bsn__id_prt is not null and 
		SPRT_BSN__ID_SPRT = Vsprt_bsn__id_sprt and Vsprt_bsn__id_sprt is not null and 
		ID_ELEM = Velt_bsn__id_elem and Velt_bsn__id_elem is not null;
begin

	
	--  Le parent "BSN.INSP_TMP_BSN" doit exister à la création d'un enfant dans "BSN.ELT_INSP_TMP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and 
	:new.DSC_TEMP_BSN__NUM_BSN is not null then 
		open c1_elt_insp_tmp_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_TEMP_BSN__NUM_BSN);
		fetch c1_elt_insp_tmp_bsn into dummy;
		found := c1_elt_insp_tmp_bsn%FOUND;
		close c1_elt_insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.INSP_TMP_BSN". Impossible de créer un enfant dans "BSN.ELT_INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.ELT_BSN" doit exister à la création d'un enfant dans "BSN.ELT_INSP_TMP_BSN"
	if :new.GRP_BSN__ID_GRP is not null and 
	:new.PRT_BSN__ID_PRT is not null and 
	:new.SPRT_BSN__ID_SPRT is not null and 
	:new.ELT_BSN__ID_ELEM is not null then 
		open c2_elt_insp_tmp_bsn ( :new.GRP_BSN__ID_GRP,
		:new.PRT_BSN__ID_PRT,
		:new.SPRT_BSN__ID_SPRT,
		:new.ELT_BSN__ID_ELEM);
		fetch c2_elt_insp_tmp_bsn into dummy;
		found := c2_elt_insp_tmp_bsn%FOUND;
		close c2_elt_insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.ELT_BSN". Impossible de créer un enfant dans "BSN.ELT_INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_ELTINSPTMPBSN" before update
on BSN.ELT_INSP_TMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.INSP_TMP_BSN"
	cursor c1_elt_insp_tmp_bsn (Vcamp_bsn__id_camp varchar,
	Vdsc_temp_bsn__num_bsn varchar) is
		select 1 
		from BSN.INSP_TMP_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_TEMP_BSN__NUM_BSN = Vdsc_temp_bsn__num_bsn and Vdsc_temp_bsn__num_bsn is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.ELT_BSN"
	cursor c2_elt_insp_tmp_bsn (Vgrp_bsn__id_grp number,
	Vprt_bsn__id_prt number,
	Vsprt_bsn__id_sprt number,
	Velt_bsn__id_elem number) is
		select 1 
		from BSN.ELT_BSN 
		where 
		GRP_BSN__ID_GRP = Vgrp_bsn__id_grp and Vgrp_bsn__id_grp is not null and 
		PRT_BSN__ID_PRT = Vprt_bsn__id_prt and Vprt_bsn__id_prt is not null and 
		SPRT_BSN__ID_SPRT = Vsprt_bsn__id_sprt and Vsprt_bsn__id_sprt is not null and 
		ID_ELEM = Velt_bsn__id_elem and Velt_bsn__id_elem is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.INSP_TMP_BSN" doit exister à la création d'un enfant dans "BSN.ELT_INSP_TMP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and seq = 0 and 
	:new.DSC_TEMP_BSN__NUM_BSN is not null and seq = 0 then 
		open c1_elt_insp_tmp_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_TEMP_BSN__NUM_BSN);
		fetch c1_elt_insp_tmp_bsn into dummy;
		found := c1_elt_insp_tmp_bsn%FOUND;
		close c1_elt_insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.INSP_TMP_BSN". Impossible de modifier un enfant dans "BSN.ELT_INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.ELT_BSN" doit exister à la création d'un enfant dans "BSN.ELT_INSP_TMP_BSN"
	if :new.GRP_BSN__ID_GRP is not null and seq = 0 and 
	:new.PRT_BSN__ID_PRT is not null and seq = 0 and 
	:new.SPRT_BSN__ID_SPRT is not null and seq = 0 and 
	:new.ELT_BSN__ID_ELEM is not null and seq = 0 then 
		open c2_elt_insp_tmp_bsn ( :new.GRP_BSN__ID_GRP,
		:new.PRT_BSN__ID_PRT,
		:new.SPRT_BSN__ID_SPRT,
		:new.ELT_BSN__ID_ELEM);
		fetch c2_elt_insp_tmp_bsn into dummy;
		found := c2_elt_insp_tmp_bsn%FOUND;
		close c2_elt_insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.ELT_BSN". Impossible de modifier un enfant dans "BSN.ELT_INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_ELTINSPTMPBSN" after update
of GRP_BSN__ID_GRP,PRT_BSN__ID_PRT,SPRT_BSN__ID_SPRT,CAMP_BSN__ID_CAMP,DSC_TEMP_BSN__NUM_BSN,ELT_BSN__ID_ELEM
on BSN.ELT_INSP_TMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.ELT_INSP_TMP_BSN" dans les enfants "BSN.PHOTO_ELT_INSP_TMP_BSN"
	if ((updating('GRP_BSN__ID_GRP') and :old.GRP_BSN__ID_GRP != :new.GRP_BSN__ID_GRP) or 
	(updating('PRT_BSN__ID_PRT') and :old.PRT_BSN__ID_PRT != :new.PRT_BSN__ID_PRT) or 
	(updating('SPRT_BSN__ID_SPRT') and :old.SPRT_BSN__ID_SPRT != :new.SPRT_BSN__ID_SPRT) or 
	(updating('CAMP_BSN__ID_CAMP') and :old.CAMP_BSN__ID_CAMP != :new.CAMP_BSN__ID_CAMP) or 
	(updating('DSC_TEMP_BSN__NUM_BSN') and :old.DSC_TEMP_BSN__NUM_BSN != :new.DSC_TEMP_BSN__NUM_BSN) or 
	(updating('ELT_BSN__ID_ELEM') and :old.ELT_BSN__ID_ELEM != :new.ELT_BSN__ID_ELEM)) then 
		update BSN.PHOTO_ELT_INSP_TMP_BSN
		set GRP_BSN__ID_GRP = :new.GRP_BSN__ID_GRP,
		PRT_BSN__ID_PRT = :new.PRT_BSN__ID_PRT,
		SPRT_BSN__ID_SPRT = :new.SPRT_BSN__ID_SPRT,
		CAMP_BSN__ID_CAMP = :new.CAMP_BSN__ID_CAMP,
		DSC_TEMP_BSN__NUM_BSN = :new.DSC_TEMP_BSN__NUM_BSN,
		ELT_BSN__ID_ELEM = :new.ELT_BSN__ID_ELEM  
		where GRP_BSN__ID_GRP = :old.GRP_BSN__ID_GRP and 
		PRT_BSN__ID_PRT = :old.PRT_BSN__ID_PRT and 
		SPRT_BSN__ID_SPRT = :old.SPRT_BSN__ID_SPRT and 
		CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
		DSC_TEMP_BSN__NUM_BSN = :old.DSC_TEMP_BSN__NUM_BSN and 
		ELT_BSN__ID_ELEM = :old.ELT_BSN__ID_ELEM;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_ELTINSPTMPBSN" after delete
on BSN.ELT_INSP_TMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.PHOTO_ELT_INSP_TMP_BSN"
	delete BSN.PHOTO_ELT_INSP_TMP_BSN
	where GRP_BSN__ID_GRP = :old.GRP_BSN__ID_GRP and 
	PRT_BSN__ID_PRT = :old.PRT_BSN__ID_PRT and 
	SPRT_BSN__ID_SPRT = :old.SPRT_BSN__ID_SPRT and 
	CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
	DSC_TEMP_BSN__NUM_BSN = :old.DSC_TEMP_BSN__NUM_BSN and 
	ELT_BSN__ID_ELEM = :old.ELT_BSN__ID_ELEM;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_SPRTVSTBSN" before insert
on BSN.SPRT_VST_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.VST_BSN"
	cursor c1_sprt_vst_bsn(Vcamp_bsn__id_camp varchar,
	Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.VST_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_BSN__NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_LIGNE_BSN"
	cursor c2_sprt_vst_bsn(Vcd_chapitre_bsn__id_chap number,
	Vcd_ligne_bsn__id_ligne number) is
		select 1 
		from BSN.CD_LIGNE_BSN 
		where 
		CD_CHAPITRE_BSN__ID_CHAP = Vcd_chapitre_bsn__id_chap and Vcd_chapitre_bsn__id_chap is not null and 
		ID_LIGNE = Vcd_ligne_bsn__id_ligne and Vcd_ligne_bsn__id_ligne is not null;
begin

	
	--  Le parent "BSN.VST_BSN" doit exister à la création d'un enfant dans "BSN.SPRT_VST_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and 
	:new.DSC_BSN__NUM_BSN is not null then 
		open c1_sprt_vst_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_BSN__NUM_BSN);
		fetch c1_sprt_vst_bsn into dummy;
		found := c1_sprt_vst_bsn%FOUND;
		close c1_sprt_vst_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.VST_BSN". Impossible de créer un enfant dans "BSN.SPRT_VST_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_LIGNE_BSN" doit exister à la création d'un enfant dans "BSN.SPRT_VST_BSN"
	if :new.CD_CHAPITRE_BSN__ID_CHAP is not null and 
	:new.CD_LIGNE_BSN__ID_LIGNE is not null then 
		open c2_sprt_vst_bsn ( :new.CD_CHAPITRE_BSN__ID_CHAP,
		:new.CD_LIGNE_BSN__ID_LIGNE);
		fetch c2_sprt_vst_bsn into dummy;
		found := c2_sprt_vst_bsn%FOUND;
		close c2_sprt_vst_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_LIGNE_BSN". Impossible de créer un enfant dans "BSN.SPRT_VST_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_SPRTVSTBSN" before update
on BSN.SPRT_VST_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.VST_BSN"
	cursor c1_sprt_vst_bsn (Vcamp_bsn__id_camp varchar,
	Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.VST_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_BSN__NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_LIGNE_BSN"
	cursor c2_sprt_vst_bsn (Vcd_chapitre_bsn__id_chap number,
	Vcd_ligne_bsn__id_ligne number) is
		select 1 
		from BSN.CD_LIGNE_BSN 
		where 
		CD_CHAPITRE_BSN__ID_CHAP = Vcd_chapitre_bsn__id_chap and Vcd_chapitre_bsn__id_chap is not null and 
		ID_LIGNE = Vcd_ligne_bsn__id_ligne and Vcd_ligne_bsn__id_ligne is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.VST_BSN" doit exister à la création d'un enfant dans "BSN.SPRT_VST_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and seq = 0 and 
	:new.DSC_BSN__NUM_BSN is not null and seq = 0 then 
		open c1_sprt_vst_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_BSN__NUM_BSN);
		fetch c1_sprt_vst_bsn into dummy;
		found := c1_sprt_vst_bsn%FOUND;
		close c1_sprt_vst_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.VST_BSN". Impossible de modifier un enfant dans "BSN.SPRT_VST_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_LIGNE_BSN" doit exister à la création d'un enfant dans "BSN.SPRT_VST_BSN"
	if :new.CD_CHAPITRE_BSN__ID_CHAP is not null and seq = 0 and 
	:new.CD_LIGNE_BSN__ID_LIGNE is not null and seq = 0 then 
		open c2_sprt_vst_bsn ( :new.CD_CHAPITRE_BSN__ID_CHAP,
		:new.CD_LIGNE_BSN__ID_LIGNE);
		fetch c2_sprt_vst_bsn into dummy;
		found := c2_sprt_vst_bsn%FOUND;
		close c2_sprt_vst_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_LIGNE_BSN". Impossible de modifier un enfant dans "BSN.SPRT_VST_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_SPRTVSTBSN" after update
of CAMP_BSN__ID_CAMP,DSC_BSN__NUM_BSN,CD_CHAPITRE_BSN__ID_CHAP,CD_LIGNE_BSN__ID_LIGNE
on BSN.SPRT_VST_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.SPRT_VST_BSN" dans les enfants "BSN.PHOTO_SPRT_VST_BSN"
	if ((updating('CAMP_BSN__ID_CAMP') and :old.CAMP_BSN__ID_CAMP != :new.CAMP_BSN__ID_CAMP) or 
	(updating('DSC_BSN__NUM_BSN') and :old.DSC_BSN__NUM_BSN != :new.DSC_BSN__NUM_BSN) or 
	(updating('CD_CHAPITRE_BSN__ID_CHAP') and :old.CD_CHAPITRE_BSN__ID_CHAP != :new.CD_CHAPITRE_BSN__ID_CHAP) or 
	(updating('CD_LIGNE_BSN__ID_LIGNE') and :old.CD_LIGNE_BSN__ID_LIGNE != :new.CD_LIGNE_BSN__ID_LIGNE)) then 
		update BSN.PHOTO_SPRT_VST_BSN
		set CAMP_BSN__ID_CAMP = :new.CAMP_BSN__ID_CAMP,
		DSC_BSN__NUM_BSN = :new.DSC_BSN__NUM_BSN,
		CD_CHAPITRE_BSN__ID_CHAP = :new.CD_CHAPITRE_BSN__ID_CHAP,
		CD_LIGNE_BSN__ID_LIGNE = :new.CD_LIGNE_BSN__ID_LIGNE  
		where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
		DSC_BSN__NUM_BSN = :old.DSC_BSN__NUM_BSN and 
		CD_CHAPITRE_BSN__ID_CHAP = :old.CD_CHAPITRE_BSN__ID_CHAP and 
		CD_LIGNE_BSN__ID_LIGNE = :old.CD_LIGNE_BSN__ID_LIGNE;
	end if;
	--  Modification du code du parent "BSN.SPRT_VST_BSN" dans les enfants "BSN.CD_PRECO__SPRT_VST_BSN"
	if ((updating('CAMP_BSN__ID_CAMP') and :old.CAMP_BSN__ID_CAMP != :new.CAMP_BSN__ID_CAMP) or 
	(updating('DSC_BSN__NUM_BSN') and :old.DSC_BSN__NUM_BSN != :new.DSC_BSN__NUM_BSN) or 
	(updating('CD_CHAPITRE_BSN__ID_CHAP') and :old.CD_CHAPITRE_BSN__ID_CHAP != :new.CD_CHAPITRE_BSN__ID_CHAP) or 
	(updating('CD_LIGNE_BSN__ID_LIGNE') and :old.CD_LIGNE_BSN__ID_LIGNE != :new.CD_LIGNE_BSN__ID_LIGNE)) then 
		update BSN.CD_PRECO__SPRT_VST_BSN
		set CAMP_BSN__ID_CAMP = :new.CAMP_BSN__ID_CAMP,
		DSC_BSN__NUM_BSN = :new.DSC_BSN__NUM_BSN,
		CD_CHAPITRE_BSN__ID_CHAP = :new.CD_CHAPITRE_BSN__ID_CHAP,
		CD_LIGNE_BSN__ID_LIGNE = :new.CD_LIGNE_BSN__ID_LIGNE  
		where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
		DSC_BSN__NUM_BSN = :old.DSC_BSN__NUM_BSN and 
		CD_CHAPITRE_BSN__ID_CHAP = :old.CD_CHAPITRE_BSN__ID_CHAP and 
		CD_LIGNE_BSN__ID_LIGNE = :old.CD_LIGNE_BSN__ID_LIGNE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_SPRTVSTBSN" after delete
on BSN.SPRT_VST_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.PHOTO_SPRT_VST_BSN"
	delete BSN.PHOTO_SPRT_VST_BSN
	where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
	DSC_BSN__NUM_BSN = :old.DSC_BSN__NUM_BSN and 
	CD_CHAPITRE_BSN__ID_CHAP = :old.CD_CHAPITRE_BSN__ID_CHAP and 
	CD_LIGNE_BSN__ID_LIGNE = :old.CD_LIGNE_BSN__ID_LIGNE;
	
	--  Suppression des enfants dans "BSN.CD_PRECO__SPRT_VST_BSN"
	delete BSN.CD_PRECO__SPRT_VST_BSN
	where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
	DSC_BSN__NUM_BSN = :old.DSC_BSN__NUM_BSN and 
	CD_CHAPITRE_BSN__ID_CHAP = :old.CD_CHAPITRE_BSN__ID_CHAP and 
	CD_LIGNE_BSN__ID_LIGNE = :old.CD_LIGNE_BSN__ID_LIGNE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TUA_CDFREQUENCEBSN" after update
of FREQ
on BSN.CD_FREQUENCE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_FREQUENCE_BSN" dans les enfants "BSN.DSC_BSN"
	if ((updating('FREQ') and :old.FREQ != :new.FREQ)) then 
		update BSN.DSC_BSN
		set CD_FREQUENCE_BSN__FREQ = :new.FREQ  
		where CD_FREQUENCE_BSN__FREQ = :old.FREQ;
	end if;
	--  Modification du code du parent "BSN.CD_FREQUENCE_BSN" dans les enfants "BSN.DSC_TEMP_BSN"
	if ((updating('FREQ') and :old.FREQ != :new.FREQ)) then 
		update BSN.DSC_TEMP_BSN
		set CD_FREQUENCE_BSN__FREQ = :new.FREQ  
		where CD_FREQUENCE_BSN__FREQ = :old.FREQ;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDFREQUENCEBSN" after delete
on BSN.CD_FREQUENCE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.DSC_BSN"
	delete BSN.DSC_BSN
	where CD_FREQUENCE_BSN__FREQ = :old.FREQ;
	
	--  Suppression des enfants dans "BSN.DSC_TEMP_BSN"
	delete BSN.DSC_TEMP_BSN
	where CD_FREQUENCE_BSN__FREQ = :old.FREQ;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_DOCBSN" before insert
on BSN.DOC_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_DOC_BSN"
	cursor c1_doc_bsn(Vcd_doc__code varchar) is
		select 1 
		from BSN.CD_DOC_BSN 
		where 
		CODE = Vcd_doc__code and Vcd_doc__code is not null;
begin

	
	--  Le parent "BSN.CD_DOC_BSN" doit exister à la création d'un enfant dans "BSN.DOC_BSN"
	if :new.CD_DOC__CODE is not null then 
		open c1_doc_bsn ( :new.CD_DOC__CODE);
		fetch c1_doc_bsn into dummy;
		found := c1_doc_bsn%FOUND;
		close c1_doc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_DOC_BSN". Impossible de créer un enfant dans "BSN.DOC_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_DOCBSN" before update
on BSN.DOC_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_DOC_BSN"
	cursor c1_doc_bsn (Vcd_doc__code varchar) is
		select 1 
		from BSN.CD_DOC_BSN 
		where 
		CODE = Vcd_doc__code and Vcd_doc__code is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.CD_DOC_BSN" doit exister à la création d'un enfant dans "BSN.DOC_BSN"
	if :new.CD_DOC__CODE is not null and seq = 0 then 
		open c1_doc_bsn ( :new.CD_DOC__CODE);
		fetch c1_doc_bsn into dummy;
		found := c1_doc_bsn%FOUND;
		close c1_doc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_DOC_BSN". Impossible de modifier un enfant dans "BSN.DOC_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_DOCBSN" after update
of ID
on BSN.DOC_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.DOC_BSN" dans les enfants "BSN.CONTACT_BSN"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update BSN.CONTACT_BSN
		set DOC__ID = :new.ID  
		where DOC__ID = :old.ID;
	end if;
	--  Modification du code du parent "BSN.DOC_BSN" dans les enfants "BSN.CLS_DOC_BSN"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update BSN.CLS_DOC_BSN
		set DOC__ID = :new.ID  
		where DOC__ID = :old.ID;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_DOCBSN" after delete
on BSN.DOC_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.CONTACT_BSN"
	delete BSN.CONTACT_BSN
	where DOC__ID = :old.ID;
	
	--  Suppression des enfants dans "BSN.CLS_DOC_BSN"
	delete BSN.CLS_DOC_BSN
	where DOC__ID = :old.ID;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_ELTBSN" before insert
on BSN.ELT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.SPRT_BSN"
	cursor c1_elt_bsn(Vgrp_bsn__id_grp number,
	Vprt_bsn__id_prt number,
	Vsprt_bsn__id_sprt number) is
		select 1 
		from BSN.SPRT_BSN 
		where 
		GRP_BSN__ID_GRP = Vgrp_bsn__id_grp and Vgrp_bsn__id_grp is not null and 
		PRT_BSN__ID_PRT = Vprt_bsn__id_prt and Vprt_bsn__id_prt is not null and 
		ID_SPRT = Vsprt_bsn__id_sprt and Vsprt_bsn__id_sprt is not null;
begin

	
	--  Le parent "BSN.SPRT_BSN" doit exister à la création d'un enfant dans "BSN.ELT_BSN"
	if :new.GRP_BSN__ID_GRP is not null and 
	:new.PRT_BSN__ID_PRT is not null and 
	:new.SPRT_BSN__ID_SPRT is not null then 
		open c1_elt_bsn ( :new.GRP_BSN__ID_GRP,
		:new.PRT_BSN__ID_PRT,
		:new.SPRT_BSN__ID_SPRT);
		fetch c1_elt_bsn into dummy;
		found := c1_elt_bsn%FOUND;
		close c1_elt_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.SPRT_BSN". Impossible de créer un enfant dans "BSN.ELT_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_ELTBSN" before update
on BSN.ELT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.SPRT_BSN"
	cursor c1_elt_bsn (Vgrp_bsn__id_grp number,
	Vprt_bsn__id_prt number,
	Vsprt_bsn__id_sprt number) is
		select 1 
		from BSN.SPRT_BSN 
		where 
		GRP_BSN__ID_GRP = Vgrp_bsn__id_grp and Vgrp_bsn__id_grp is not null and 
		PRT_BSN__ID_PRT = Vprt_bsn__id_prt and Vprt_bsn__id_prt is not null and 
		ID_SPRT = Vsprt_bsn__id_sprt and Vsprt_bsn__id_sprt is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.SPRT_BSN" doit exister à la création d'un enfant dans "BSN.ELT_BSN"
	if :new.GRP_BSN__ID_GRP is not null and seq = 0 and 
	:new.PRT_BSN__ID_PRT is not null and seq = 0 and 
	:new.SPRT_BSN__ID_SPRT is not null and seq = 0 then 
		open c1_elt_bsn ( :new.GRP_BSN__ID_GRP,
		:new.PRT_BSN__ID_PRT,
		:new.SPRT_BSN__ID_SPRT);
		fetch c1_elt_bsn into dummy;
		found := c1_elt_bsn%FOUND;
		close c1_elt_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.SPRT_BSN". Impossible de modifier un enfant dans "BSN.ELT_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_ELTBSN" after update
of GRP_BSN__ID_GRP,PRT_BSN__ID_PRT,SPRT_BSN__ID_SPRT,ID_ELEM
on BSN.ELT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.ELT_BSN" dans les enfants "BSN.ELT_INSP_BSN"
	if ((updating('GRP_BSN__ID_GRP') and :old.GRP_BSN__ID_GRP != :new.GRP_BSN__ID_GRP) or 
	(updating('PRT_BSN__ID_PRT') and :old.PRT_BSN__ID_PRT != :new.PRT_BSN__ID_PRT) or 
	(updating('SPRT_BSN__ID_SPRT') and :old.SPRT_BSN__ID_SPRT != :new.SPRT_BSN__ID_SPRT) or 
	(updating('ID_ELEM') and :old.ID_ELEM != :new.ID_ELEM)) then 
		update BSN.ELT_INSP_BSN
		set GRP_BSN__ID_GRP = :new.GRP_BSN__ID_GRP,
		PRT_BSN__ID_PRT = :new.PRT_BSN__ID_PRT,
		SPRT_BSN__ID_SPRT = :new.SPRT_BSN__ID_SPRT,
		ELT_BSN__ID_ELEM = :new.ID_ELEM  
		where GRP_BSN__ID_GRP = :old.GRP_BSN__ID_GRP and 
		PRT_BSN__ID_PRT = :old.PRT_BSN__ID_PRT and 
		SPRT_BSN__ID_SPRT = :old.SPRT_BSN__ID_SPRT and 
		ELT_BSN__ID_ELEM = :old.ID_ELEM;
	end if;
	--  Modification du code du parent "BSN.ELT_BSN" dans les enfants "BSN.ELT_INSP_TMP_BSN"
	if ((updating('GRP_BSN__ID_GRP') and :old.GRP_BSN__ID_GRP != :new.GRP_BSN__ID_GRP) or 
	(updating('PRT_BSN__ID_PRT') and :old.PRT_BSN__ID_PRT != :new.PRT_BSN__ID_PRT) or 
	(updating('SPRT_BSN__ID_SPRT') and :old.SPRT_BSN__ID_SPRT != :new.SPRT_BSN__ID_SPRT) or 
	(updating('ID_ELEM') and :old.ID_ELEM != :new.ID_ELEM)) then 
		update BSN.ELT_INSP_TMP_BSN
		set GRP_BSN__ID_GRP = :new.GRP_BSN__ID_GRP,
		PRT_BSN__ID_PRT = :new.PRT_BSN__ID_PRT,
		SPRT_BSN__ID_SPRT = :new.SPRT_BSN__ID_SPRT,
		ELT_BSN__ID_ELEM = :new.ID_ELEM  
		where GRP_BSN__ID_GRP = :old.GRP_BSN__ID_GRP and 
		PRT_BSN__ID_PRT = :old.PRT_BSN__ID_PRT and 
		SPRT_BSN__ID_SPRT = :old.SPRT_BSN__ID_SPRT and 
		ELT_BSN__ID_ELEM = :old.ID_ELEM;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_ELTBSN" after delete
on BSN.ELT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.ELT_INSP_BSN"
	delete BSN.ELT_INSP_BSN
	where GRP_BSN__ID_GRP = :old.GRP_BSN__ID_GRP and 
	PRT_BSN__ID_PRT = :old.PRT_BSN__ID_PRT and 
	SPRT_BSN__ID_SPRT = :old.SPRT_BSN__ID_SPRT and 
	ELT_BSN__ID_ELEM = :old.ID_ELEM;
	
	--  Suppression des enfants dans "BSN.ELT_INSP_TMP_BSN"
	delete BSN.ELT_INSP_TMP_BSN
	where GRP_BSN__ID_GRP = :old.GRP_BSN__ID_GRP and 
	PRT_BSN__ID_PRT = :old.PRT_BSN__ID_PRT and 
	SPRT_BSN__ID_SPRT = :old.SPRT_BSN__ID_SPRT and 
	ELT_BSN__ID_ELEM = :old.ID_ELEM;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_CDENTETEBSN" before insert
on BSN.CD_ENTETE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_COMPOSANT_BSN"
	cursor c1_cd_entete_bsn(Vcd_composant_bsn__type_comp varchar) is
		select 1 
		from BSN.CD_COMPOSANT_BSN 
		where 
		TYPE_COMP = Vcd_composant_bsn__type_comp and Vcd_composant_bsn__type_comp is not null;
begin

	
	--  Le parent "BSN.CD_COMPOSANT_BSN" doit exister à la création d'un enfant dans "BSN.CD_ENTETE_BSN"
	if :new.CD_COMPOSANT_BSN__TYPE_COMP is not null then 
		open c1_cd_entete_bsn ( :new.CD_COMPOSANT_BSN__TYPE_COMP);
		fetch c1_cd_entete_bsn into dummy;
		found := c1_cd_entete_bsn%FOUND;
		close c1_cd_entete_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_COMPOSANT_BSN". Impossible de créer un enfant dans "BSN.CD_ENTETE_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_CDENTETEBSN" before update
on BSN.CD_ENTETE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_COMPOSANT_BSN"
	cursor c1_cd_entete_bsn (Vcd_composant_bsn__type_comp varchar) is
		select 1 
		from BSN.CD_COMPOSANT_BSN 
		where 
		TYPE_COMP = Vcd_composant_bsn__type_comp and Vcd_composant_bsn__type_comp is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.CD_COMPOSANT_BSN" doit exister à la création d'un enfant dans "BSN.CD_ENTETE_BSN"
	if :new.CD_COMPOSANT_BSN__TYPE_COMP is not null and seq = 0 then 
		open c1_cd_entete_bsn ( :new.CD_COMPOSANT_BSN__TYPE_COMP);
		fetch c1_cd_entete_bsn into dummy;
		found := c1_cd_entete_bsn%FOUND;
		close c1_cd_entete_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_COMPOSANT_BSN". Impossible de modifier un enfant dans "BSN.CD_ENTETE_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_CDENTETEBSN" after update
of ID_ENTETE
on BSN.CD_ENTETE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_ENTETE_BSN" dans les enfants "BSN.ENTETE_BSN"
	if ((updating('ID_ENTETE') and :old.ID_ENTETE != :new.ID_ENTETE)) then 
		update BSN.ENTETE_BSN
		set CD_ENTETE_BSN__ID_ENTETE = :new.ID_ENTETE  
		where CD_ENTETE_BSN__ID_ENTETE = :old.ID_ENTETE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDENTETEBSN" after delete
on BSN.CD_ENTETE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.ENTETE_BSN"
	delete BSN.ENTETE_BSN
	where CD_ENTETE_BSN__ID_ENTETE = :old.ID_ENTETE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TUA_CDENTPBSN" after update
of ENTREPRISE
on BSN.CD_ENTP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_ENTP_BSN" dans les enfants "BSN.TRAVAUX_BSN"
	if ((updating('ENTREPRISE') and :old.ENTREPRISE != :new.ENTREPRISE)) then 
		update BSN.TRAVAUX_BSN
		set CD_ENTP_BSN__ENTREPRISE = :new.ENTREPRISE  
		where CD_ENTP_BSN__ENTREPRISE = :old.ENTREPRISE;
	end if;
	--  Modification du code du parent "BSN.CD_ENTP_BSN" dans les enfants "BSN.DSC_BSN"
	if ((updating('ENTREPRISE') and :old.ENTREPRISE != :new.ENTREPRISE)) then 
		update BSN.DSC_BSN
		set CD_ENTP_BSN__ENTREPRISE = :new.ENTREPRISE  
		where CD_ENTP_BSN__ENTREPRISE = :old.ENTREPRISE;
	end if;
	--  Modification du code du parent "BSN.CD_ENTP_BSN" dans les enfants "BSN.DSC_TEMP_BSN"
	if ((updating('ENTREPRISE') and :old.ENTREPRISE != :new.ENTREPRISE)) then 
		update BSN.DSC_TEMP_BSN
		set CD_ENTP_BSN__ENTREPRISE = :new.ENTREPRISE  
		where CD_ENTP_BSN__ENTREPRISE = :old.ENTREPRISE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDENTPBSN" after delete
on BSN.CD_ENTP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.TRAVAUX_BSN"
	delete BSN.TRAVAUX_BSN
	where CD_ENTP_BSN__ENTREPRISE = :old.ENTREPRISE;
	
	--  Suppression des enfants dans "BSN.DSC_BSN"
	delete BSN.DSC_BSN
	where CD_ENTP_BSN__ENTREPRISE = :old.ENTREPRISE;
	
	--  Suppression des enfants dans "BSN.DSC_TEMP_BSN"
	delete BSN.DSC_TEMP_BSN
	where CD_ENTP_BSN__ENTREPRISE = :old.ENTREPRISE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TUA_CDETUDEBSN" after update
of ETUDE
on BSN.CD_ETUDE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_ETUDE_BSN" dans les enfants "BSN.INSP_BSN"
	if ((updating('ETUDE') and :old.ETUDE != :new.ETUDE)) then 
		update BSN.INSP_BSN
		set CD_ETUDE_BSN__ETUDE = :new.ETUDE  
		where CD_ETUDE_BSN__ETUDE = :old.ETUDE;
	end if;
	--  Modification du code du parent "BSN.CD_ETUDE_BSN" dans les enfants "BSN.INSP_TMP_BSN"
	if ((updating('ETUDE') and :old.ETUDE != :new.ETUDE)) then 
		update BSN.INSP_TMP_BSN
		set CD_ETUDE_BSN__ETUDE = :new.ETUDE  
		where CD_ETUDE_BSN__ETUDE = :old.ETUDE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDETUDEBSN" after delete
on BSN.CD_ETUDE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.INSP_BSN"
	delete BSN.INSP_BSN
	where CD_ETUDE_BSN__ETUDE = :old.ETUDE;
	
	--  Suppression des enfants dans "BSN.INSP_TMP_BSN"
	delete BSN.INSP_TMP_BSN
	where CD_ETUDE_BSN__ETUDE = :old.ETUDE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_EVTBSN" before insert
on BSN.EVT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_EVT_BSN"
	cursor c1_evt_bsn(Vcd_evt_bsn__type varchar) is
		select 1 
		from BSN.CD_EVT_BSN 
		where 
		TYPE = Vcd_evt_bsn__type and Vcd_evt_bsn__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c2_evt_bsn(Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	
	--  Le parent "BSN.CD_EVT_BSN" doit exister à la création d'un enfant dans "BSN.EVT_BSN"
	if :new.CD_EVT_BSN__TYPE is not null then 
		open c1_evt_bsn ( :new.CD_EVT_BSN__TYPE);
		fetch c1_evt_bsn into dummy;
		found := c1_evt_bsn%FOUND;
		close c1_evt_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_EVT_BSN". Impossible de créer un enfant dans "BSN.EVT_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.EVT_BSN"
	if :new.DSC_BSN__NUM_BSN is not null then 
		open c2_evt_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c2_evt_bsn into dummy;
		found := c2_evt_bsn%FOUND;
		close c2_evt_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de créer un enfant dans "BSN.EVT_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_EVTBSN" before update
on BSN.EVT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_EVT_BSN"
	cursor c1_evt_bsn (Vcd_evt_bsn__type varchar) is
		select 1 
		from BSN.CD_EVT_BSN 
		where 
		TYPE = Vcd_evt_bsn__type and Vcd_evt_bsn__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c2_evt_bsn (Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.CD_EVT_BSN" doit exister à la création d'un enfant dans "BSN.EVT_BSN"
	if :new.CD_EVT_BSN__TYPE is not null and seq = 0 then 
		open c1_evt_bsn ( :new.CD_EVT_BSN__TYPE);
		fetch c1_evt_bsn into dummy;
		found := c1_evt_bsn%FOUND;
		close c1_evt_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_EVT_BSN". Impossible de modifier un enfant dans "BSN.EVT_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.EVT_BSN"
	if :new.DSC_BSN__NUM_BSN is not null and seq = 0 then 
		open c2_evt_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c2_evt_bsn into dummy;
		found := c2_evt_bsn%FOUND;
		close c2_evt_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de modifier un enfant dans "BSN.EVT_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_CDEXTBSN" after update
of TYPE
on BSN.CD_EXT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_EXT_BSN" dans les enfants "BSN.DSC_BSN"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update BSN.DSC_BSN
		set CD_EXT_BSN__TYPE = :new.TYPE  
		where CD_EXT_BSN__TYPE = :old.TYPE;
	end if;
	--  Modification du code du parent "BSN.CD_EXT_BSN" dans les enfants "BSN.DSC_TEMP_BSN"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update BSN.DSC_TEMP_BSN
		set CD_EXT_BSN__TYPE = :new.TYPE  
		where CD_EXT_BSN__TYPE = :old.TYPE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDEXTBSN" after delete
on BSN.CD_EXT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.DSC_BSN"
	delete BSN.DSC_BSN
	where CD_EXT_BSN__TYPE = :old.TYPE;
	
	--  Suppression des enfants dans "BSN.DSC_TEMP_BSN"
	delete BSN.DSC_TEMP_BSN
	where CD_EXT_BSN__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TUA_CDFAMBSN" after update
of FAMILLE
on BSN.CD_FAM_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_FAM_BSN" dans les enfants "BSN.DSC_BSN"
	if ((updating('FAMILLE') and :old.FAMILLE != :new.FAMILLE)) then 
		update BSN.DSC_BSN
		set CD_FAM_BSN__FAMILLE = :new.FAMILLE  
		where CD_FAM_BSN__FAMILLE = :old.FAMILLE;
	end if;
	--  Modification du code du parent "BSN.CD_FAM_BSN" dans les enfants "BSN.DSC_TEMP_BSN"
	if ((updating('FAMILLE') and :old.FAMILLE != :new.FAMILLE)) then 
		update BSN.DSC_TEMP_BSN
		set CD_FAM_BSN__FAMILLE = :new.FAMILLE  
		where CD_FAM_BSN__FAMILLE = :old.FAMILLE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDFAMBSN" after delete
on BSN.CD_FAM_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.DSC_BSN"
	delete BSN.DSC_BSN
	where CD_FAM_BSN__FAMILLE = :old.FAMILLE;
	
	--  Suppression des enfants dans "BSN.DSC_TEMP_BSN"
	delete BSN.DSC_TEMP_BSN
	where CD_FAM_BSN__FAMILLE = :old.FAMILLE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TUA_CDFAMEQPBSN" after update
of FAM
on BSN.CD_FAMEQP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_FAMEQP_BSN" dans les enfants "BSN.CD_TYPEQP_BSN"
	if ((updating('FAM') and :old.FAM != :new.FAM)) then 
		update BSN.CD_TYPEQP_BSN
		set CD_FAMEQP_BSN__FAM = :new.FAM  
		where CD_FAMEQP_BSN__FAM = :old.FAM;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDFAMEQPBSN" after delete
on BSN.CD_FAMEQP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.CD_TYPEQP_BSN"
	delete BSN.CD_TYPEQP_BSN
	where CD_FAMEQP_BSN__FAM = :old.FAM;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_GEOMETRIEBSN" before insert
on BSN.GEOMETRIE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c1_geometrie_bsn(Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.GEOMETRIE_BSN"
	if :new.DSC_BSN__NUM_BSN is not null then 
		open c1_geometrie_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c1_geometrie_bsn into dummy;
		found := c1_geometrie_bsn%FOUND;
		close c1_geometrie_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de créer un enfant dans "BSN.GEOMETRIE_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_GEOMETRIEBSN" before update
on BSN.GEOMETRIE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c1_geometrie_bsn (Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.GEOMETRIE_BSN"
	if :new.DSC_BSN__NUM_BSN is not null and seq = 0 then 
		open c1_geometrie_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c1_geometrie_bsn into dummy;
		found := c1_geometrie_bsn%FOUND;
		close c1_geometrie_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de modifier un enfant dans "BSN.GEOMETRIE_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_GRPBSN" after update
of ID_GRP
on BSN.GRP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.GRP_BSN" dans les enfants "BSN.PRT_BSN"
	if ((updating('ID_GRP') and :old.ID_GRP != :new.ID_GRP)) then 
		update BSN.PRT_BSN
		set GRP_BSN__ID_GRP = :new.ID_GRP  
		where GRP_BSN__ID_GRP = :old.ID_GRP;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_GRPBSN" after delete
on BSN.GRP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.PRT_BSN"
	delete BSN.PRT_BSN
	where GRP_BSN__ID_GRP = :old.ID_GRP;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_HISTONOTEBSN" before insert
on BSN.HISTO_NOTE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c1_histo_note_bsn(Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_ORIGIN_BSN"
	cursor c2_histo_note_bsn(Vcd_origin_bsn__origine varchar) is
		select 1 
		from BSN.CD_ORIGIN_BSN 
		where 
		ORIGINE = Vcd_origin_bsn__origine and Vcd_origin_bsn__origine is not null;
begin

	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.HISTO_NOTE_BSN"
	if :new.DSC_BSN__NUM_BSN is not null then 
		open c1_histo_note_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c1_histo_note_bsn into dummy;
		found := c1_histo_note_bsn%FOUND;
		close c1_histo_note_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de créer un enfant dans "BSN.HISTO_NOTE_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_ORIGIN_BSN" doit exister à la création d'un enfant dans "BSN.HISTO_NOTE_BSN"
	if :new.CD_ORIGIN_BSN__ORIGINE is not null then 
		open c2_histo_note_bsn ( :new.CD_ORIGIN_BSN__ORIGINE);
		fetch c2_histo_note_bsn into dummy;
		found := c2_histo_note_bsn%FOUND;
		close c2_histo_note_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ORIGIN_BSN". Impossible de créer un enfant dans "BSN.HISTO_NOTE_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_HISTONOTEBSN" before update
on BSN.HISTO_NOTE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c1_histo_note_bsn (Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_ORIGIN_BSN"
	cursor c2_histo_note_bsn (Vcd_origin_bsn__origine varchar) is
		select 1 
		from BSN.CD_ORIGIN_BSN 
		where 
		ORIGINE = Vcd_origin_bsn__origine and Vcd_origin_bsn__origine is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.HISTO_NOTE_BSN"
	if :new.DSC_BSN__NUM_BSN is not null and seq = 0 then 
		open c1_histo_note_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c1_histo_note_bsn into dummy;
		found := c1_histo_note_bsn%FOUND;
		close c1_histo_note_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de modifier un enfant dans "BSN.HISTO_NOTE_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_ORIGIN_BSN" doit exister à la création d'un enfant dans "BSN.HISTO_NOTE_BSN"
	if :new.CD_ORIGIN_BSN__ORIGINE is not null and seq = 0 then 
		open c2_histo_note_bsn ( :new.CD_ORIGIN_BSN__ORIGINE);
		fetch c2_histo_note_bsn into dummy;
		found := c2_histo_note_bsn%FOUND;
		close c2_histo_note_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ORIGIN_BSN". Impossible de modifier un enfant dans "BSN.HISTO_NOTE_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TIB_DSCCAMPBSN" before insert
on BSN.DSC_CAMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c1_dsc_camp_bsn(Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CAMP_BSN"
	cursor c2_dsc_camp_bsn(Vcamp_bsn__id_camp varchar) is
		select 1 
		from BSN.CAMP_BSN 
		where 
		ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null;
begin

	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.DSC_CAMP_BSN"
	if :new.DSC_BSN__NUM_BSN is not null then 
		open c1_dsc_camp_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c1_dsc_camp_bsn into dummy;
		found := c1_dsc_camp_bsn%FOUND;
		close c1_dsc_camp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de créer un enfant dans "BSN.DSC_CAMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CAMP_BSN" doit exister à la création d'un enfant dans "BSN.DSC_CAMP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null then 
		open c2_dsc_camp_bsn ( :new.CAMP_BSN__ID_CAMP);
		fetch c2_dsc_camp_bsn into dummy;
		found := c2_dsc_camp_bsn%FOUND;
		close c2_dsc_camp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CAMP_BSN". Impossible de créer un enfant dans "BSN.DSC_CAMP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_DSCCAMPBSN" before update
on BSN.DSC_CAMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c1_dsc_camp_bsn (Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CAMP_BSN"
	cursor c2_dsc_camp_bsn (Vcamp_bsn__id_camp varchar) is
		select 1 
		from BSN.CAMP_BSN 
		where 
		ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.DSC_CAMP_BSN"
	if :new.DSC_BSN__NUM_BSN is not null and seq = 0 then 
		open c1_dsc_camp_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c1_dsc_camp_bsn into dummy;
		found := c1_dsc_camp_bsn%FOUND;
		close c1_dsc_camp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de modifier un enfant dans "BSN.DSC_CAMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CAMP_BSN" doit exister à la création d'un enfant dans "BSN.DSC_CAMP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and seq = 0 then 
		open c2_dsc_camp_bsn ( :new.CAMP_BSN__ID_CAMP);
		fetch c2_dsc_camp_bsn into dummy;
		found := c2_dsc_camp_bsn%FOUND;
		close c2_dsc_camp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CAMP_BSN". Impossible de modifier un enfant dans "BSN.DSC_CAMP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TIB_IMPLUVIUMBSN" before insert
on BSN.IMPLUVIUM_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c1_impluvium_bsn(Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.IMPLUVIUM_BSN"
	if :new.DSC_BSN__NUM_BSN is not null then 
		open c1_impluvium_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c1_impluvium_bsn into dummy;
		found := c1_impluvium_bsn%FOUND;
		close c1_impluvium_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de créer un enfant dans "BSN.IMPLUVIUM_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_IMPLUVIUMBSN" before update
on BSN.IMPLUVIUM_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c1_impluvium_bsn (Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.IMPLUVIUM_BSN"
	if :new.DSC_BSN__NUM_BSN is not null and seq = 0 then 
		open c1_impluvium_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c1_impluvium_bsn into dummy;
		found := c1_impluvium_bsn%FOUND;
		close c1_impluvium_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de modifier un enfant dans "BSN.IMPLUVIUM_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TIB_INSPECTEURBSN" before insert
on BSN.INSPECTEUR_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_PRESTA_BSN"
	cursor c1_inspecteur_bsn(Vcd_presta_bsn__prestataire varchar) is
		select 1 
		from BSN.CD_PRESTA_BSN 
		where 
		PRESTATAIRE = Vcd_presta_bsn__prestataire and Vcd_presta_bsn__prestataire is not null;
begin

	
	--  Le parent "BSN.CD_PRESTA_BSN" doit exister à la création d'un enfant dans "BSN.INSPECTEUR_BSN"
	if :new.CD_PRESTA_BSN__PRESTATAIRE is not null then 
		open c1_inspecteur_bsn ( :new.CD_PRESTA_BSN__PRESTATAIRE);
		fetch c1_inspecteur_bsn into dummy;
		found := c1_inspecteur_bsn%FOUND;
		close c1_inspecteur_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_PRESTA_BSN". Impossible de créer un enfant dans "BSN.INSPECTEUR_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_INSPECTEURBSN" before update
on BSN.INSPECTEUR_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_PRESTA_BSN"
	cursor c1_inspecteur_bsn (Vcd_presta_bsn__prestataire varchar) is
		select 1 
		from BSN.CD_PRESTA_BSN 
		where 
		PRESTATAIRE = Vcd_presta_bsn__prestataire and Vcd_presta_bsn__prestataire is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.CD_PRESTA_BSN" doit exister à la création d'un enfant dans "BSN.INSPECTEUR_BSN"
	if :new.CD_PRESTA_BSN__PRESTATAIRE is not null and seq = 0 then 
		open c1_inspecteur_bsn ( :new.CD_PRESTA_BSN__PRESTATAIRE);
		fetch c1_inspecteur_bsn into dummy;
		found := c1_inspecteur_bsn%FOUND;
		close c1_inspecteur_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_PRESTA_BSN". Impossible de modifier un enfant dans "BSN.INSPECTEUR_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_INSPECTEURBSN" after update
of NOM
on BSN.INSPECTEUR_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.INSPECTEUR_BSN" dans les enfants "BSN.INSP_BSN"
	if ((updating('NOM') and :old.NOM != :new.NOM)) then 
		update BSN.INSP_BSN
		set INSPECTEUR_BSN__NOM = :new.NOM  
		where INSPECTEUR_BSN__NOM = :old.NOM;
	end if;
	--  Modification du code du parent "BSN.INSPECTEUR_BSN" dans les enfants "BSN.VST_BSN"
	if ((updating('NOM') and :old.NOM != :new.NOM)) then 
		update BSN.VST_BSN
		set INSPECTEUR_BSN__NOM = :new.NOM  
		where INSPECTEUR_BSN__NOM = :old.NOM;
	end if;
	--  Modification du code du parent "BSN.INSPECTEUR_BSN" dans les enfants "BSN.INSP_TMP_BSN"
	if ((updating('NOM') and :old.NOM != :new.NOM)) then 
		update BSN.INSP_TMP_BSN
		set INSPECTEUR_BSN__NOM = :new.NOM  
		where INSPECTEUR_BSN__NOM = :old.NOM;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_INSPECTEURBSN" after delete
on BSN.INSPECTEUR_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.INSP_BSN"
	delete BSN.INSP_BSN
	where INSPECTEUR_BSN__NOM = :old.NOM;
	
	--  Suppression des enfants dans "BSN.VST_BSN"
	delete BSN.VST_BSN
	where INSPECTEUR_BSN__NOM = :old.NOM;
	
	--  Suppression des enfants dans "BSN.INSP_TMP_BSN"
	delete BSN.INSP_TMP_BSN
	where INSPECTEUR_BSN__NOM = :old.NOM;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_INSPBSN" before insert
on BSN.INSP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CAMP_BSN"
	cursor c1_insp_bsn(Vcamp_bsn__id_camp varchar) is
		select 1 
		from BSN.CAMP_BSN 
		where 
		ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_ETUDE_BSN"
	cursor c2_insp_bsn(Vcd_etude_bsn__etude varchar) is
		select 1 
		from BSN.CD_ETUDE_BSN 
		where 
		ETUDE = Vcd_etude_bsn__etude and Vcd_etude_bsn__etude is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_METEO_BSN"
	cursor c3_insp_bsn(Vcd_meteo_bsn__meteo varchar) is
		select 1 
		from BSN.CD_METEO_BSN 
		where 
		METEO = Vcd_meteo_bsn__meteo and Vcd_meteo_bsn__meteo is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c4_insp_bsn(Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.INSPECTEUR_BSN"
	cursor c5_insp_bsn(Vinspecteur_bsn__nom varchar) is
		select 1 
		from BSN.INSPECTEUR_BSN 
		where 
		NOM = Vinspecteur_bsn__nom and Vinspecteur_bsn__nom is not null;
begin

	
	--  Le parent "BSN.CAMP_BSN" doit exister à la création d'un enfant dans "BSN.INSP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null then 
		open c1_insp_bsn ( :new.CAMP_BSN__ID_CAMP);
		fetch c1_insp_bsn into dummy;
		found := c1_insp_bsn%FOUND;
		close c1_insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CAMP_BSN". Impossible de créer un enfant dans "BSN.INSP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_ETUDE_BSN" doit exister à la création d'un enfant dans "BSN.INSP_BSN"
	if :new.CD_ETUDE_BSN__ETUDE is not null then 
		open c2_insp_bsn ( :new.CD_ETUDE_BSN__ETUDE);
		fetch c2_insp_bsn into dummy;
		found := c2_insp_bsn%FOUND;
		close c2_insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ETUDE_BSN". Impossible de créer un enfant dans "BSN.INSP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_METEO_BSN" doit exister à la création d'un enfant dans "BSN.INSP_BSN"
	if :new.CD_METEO_BSN__METEO is not null then 
		open c3_insp_bsn ( :new.CD_METEO_BSN__METEO);
		fetch c3_insp_bsn into dummy;
		found := c3_insp_bsn%FOUND;
		close c3_insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_METEO_BSN". Impossible de créer un enfant dans "BSN.INSP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.INSP_BSN"
	if :new.DSC_BSN__NUM_BSN is not null then 
		open c4_insp_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c4_insp_bsn into dummy;
		found := c4_insp_bsn%FOUND;
		close c4_insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de créer un enfant dans "BSN.INSP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.INSPECTEUR_BSN" doit exister à la création d'un enfant dans "BSN.INSP_BSN"
	if :new.INSPECTEUR_BSN__NOM is not null then 
		open c5_insp_bsn ( :new.INSPECTEUR_BSN__NOM);
		fetch c5_insp_bsn into dummy;
		found := c5_insp_bsn%FOUND;
		close c5_insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.INSPECTEUR_BSN". Impossible de créer un enfant dans "BSN.INSP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_INSPBSN" before update
on BSN.INSP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CAMP_BSN"
	cursor c1_insp_bsn (Vcamp_bsn__id_camp varchar) is
		select 1 
		from BSN.CAMP_BSN 
		where 
		ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_ETUDE_BSN"
	cursor c2_insp_bsn (Vcd_etude_bsn__etude varchar) is
		select 1 
		from BSN.CD_ETUDE_BSN 
		where 
		ETUDE = Vcd_etude_bsn__etude and Vcd_etude_bsn__etude is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_METEO_BSN"
	cursor c3_insp_bsn (Vcd_meteo_bsn__meteo varchar) is
		select 1 
		from BSN.CD_METEO_BSN 
		where 
		METEO = Vcd_meteo_bsn__meteo and Vcd_meteo_bsn__meteo is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c4_insp_bsn (Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.INSPECTEUR_BSN"
	cursor c5_insp_bsn (Vinspecteur_bsn__nom varchar) is
		select 1 
		from BSN.INSPECTEUR_BSN 
		where 
		NOM = Vinspecteur_bsn__nom and Vinspecteur_bsn__nom is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.CAMP_BSN" doit exister à la création d'un enfant dans "BSN.INSP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and seq = 0 then 
		open c1_insp_bsn ( :new.CAMP_BSN__ID_CAMP);
		fetch c1_insp_bsn into dummy;
		found := c1_insp_bsn%FOUND;
		close c1_insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CAMP_BSN". Impossible de modifier un enfant dans "BSN.INSP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_ETUDE_BSN" doit exister à la création d'un enfant dans "BSN.INSP_BSN"
	if :new.CD_ETUDE_BSN__ETUDE is not null and seq = 0 then 
		open c2_insp_bsn ( :new.CD_ETUDE_BSN__ETUDE);
		fetch c2_insp_bsn into dummy;
		found := c2_insp_bsn%FOUND;
		close c2_insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ETUDE_BSN". Impossible de modifier un enfant dans "BSN.INSP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_METEO_BSN" doit exister à la création d'un enfant dans "BSN.INSP_BSN"
	if :new.CD_METEO_BSN__METEO is not null and seq = 0 then 
		open c3_insp_bsn ( :new.CD_METEO_BSN__METEO);
		fetch c3_insp_bsn into dummy;
		found := c3_insp_bsn%FOUND;
		close c3_insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_METEO_BSN". Impossible de modifier un enfant dans "BSN.INSP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.INSP_BSN"
	if :new.DSC_BSN__NUM_BSN is not null and seq = 0 then 
		open c4_insp_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c4_insp_bsn into dummy;
		found := c4_insp_bsn%FOUND;
		close c4_insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de modifier un enfant dans "BSN.INSP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.INSPECTEUR_BSN" doit exister à la création d'un enfant dans "BSN.INSP_BSN"
	if :new.INSPECTEUR_BSN__NOM is not null and seq = 0 then 
		open c5_insp_bsn ( :new.INSPECTEUR_BSN__NOM);
		fetch c5_insp_bsn into dummy;
		found := c5_insp_bsn%FOUND;
		close c5_insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.INSPECTEUR_BSN". Impossible de modifier un enfant dans "BSN.INSP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_INSPBSN" after update
of CAMP_BSN__ID_CAMP,DSC_BSN__NUM_BSN
on BSN.INSP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.INSP_BSN" dans les enfants "BSN.ELT_INSP_BSN"
	if ((updating('CAMP_BSN__ID_CAMP') and :old.CAMP_BSN__ID_CAMP != :new.CAMP_BSN__ID_CAMP) or 
	(updating('DSC_BSN__NUM_BSN') and :old.DSC_BSN__NUM_BSN != :new.DSC_BSN__NUM_BSN)) then 
		update BSN.ELT_INSP_BSN
		set CAMP_BSN__ID_CAMP = :new.CAMP_BSN__ID_CAMP,
		DSC_BSN__NUM_BSN = :new.DSC_BSN__NUM_BSN  
		where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
		DSC_BSN__NUM_BSN = :old.DSC_BSN__NUM_BSN;
	end if;
	--  Modification du code du parent "BSN.INSP_BSN" dans les enfants "BSN.PHOTO_INSP_BSN"
	if ((updating('CAMP_BSN__ID_CAMP') and :old.CAMP_BSN__ID_CAMP != :new.CAMP_BSN__ID_CAMP) or 
	(updating('DSC_BSN__NUM_BSN') and :old.DSC_BSN__NUM_BSN != :new.DSC_BSN__NUM_BSN)) then 
		update BSN.PHOTO_INSP_BSN
		set CAMP_BSN__ID_CAMP = :new.CAMP_BSN__ID_CAMP,
		DSC_BSN__NUM_BSN = :new.DSC_BSN__NUM_BSN  
		where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
		DSC_BSN__NUM_BSN = :old.DSC_BSN__NUM_BSN;
	end if;
	--  Modification du code du parent "BSN.INSP_BSN" dans les enfants "BSN.CD_CONCLUSION__INSP_BSN"
	if ((updating('CAMP_BSN__ID_CAMP') and :old.CAMP_BSN__ID_CAMP != :new.CAMP_BSN__ID_CAMP) or 
	(updating('DSC_BSN__NUM_BSN') and :old.DSC_BSN__NUM_BSN != :new.DSC_BSN__NUM_BSN)) then 
		update BSN.CD_CONCLUSION__INSP_BSN
		set CAMP_BSN__ID_CAMP = :new.CAMP_BSN__ID_CAMP,
		DSC_BSN__NUM_BSN = :new.DSC_BSN__NUM_BSN  
		where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
		DSC_BSN__NUM_BSN = :old.DSC_BSN__NUM_BSN;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_INSPBSN" after delete
on BSN.INSP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.ELT_INSP_BSN"
	delete BSN.ELT_INSP_BSN
	where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
	DSC_BSN__NUM_BSN = :old.DSC_BSN__NUM_BSN;
	
	--  Suppression des enfants dans "BSN.PHOTO_INSP_BSN"
	delete BSN.PHOTO_INSP_BSN
	where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
	DSC_BSN__NUM_BSN = :old.DSC_BSN__NUM_BSN;
	
	--  Suppression des enfants dans "BSN.CD_CONCLUSION__INSP_BSN"
	delete BSN.CD_CONCLUSION__INSP_BSN
	where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
	DSC_BSN__NUM_BSN = :old.DSC_BSN__NUM_BSN;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_INSPTMPBSN" before insert
on BSN.INSP_TMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_ETUDE_BSN"
	cursor c1_insp_tmp_bsn(Vcd_etude_bsn__etude varchar) is
		select 1 
		from BSN.CD_ETUDE_BSN 
		where 
		ETUDE = Vcd_etude_bsn__etude and Vcd_etude_bsn__etude is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_METEO_BSN"
	cursor c2_insp_tmp_bsn(Vcd_meteo_bsn__meteo varchar) is
		select 1 
		from BSN.CD_METEO_BSN 
		where 
		METEO = Vcd_meteo_bsn__meteo and Vcd_meteo_bsn__meteo is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.DSC_TEMP_BSN"
	cursor c3_insp_tmp_bsn(Vcamp_bsn__id_camp varchar,
	Vdsc_temp_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_TEMP_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		NUM_BSN = Vdsc_temp_bsn__num_bsn and Vdsc_temp_bsn__num_bsn is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.INSPECTEUR_BSN"
	cursor c4_insp_tmp_bsn(Vinspecteur_bsn__nom varchar) is
		select 1 
		from BSN.INSPECTEUR_BSN 
		where 
		NOM = Vinspecteur_bsn__nom and Vinspecteur_bsn__nom is not null;
begin

	
	--  Le parent "BSN.CD_ETUDE_BSN" doit exister à la création d'un enfant dans "BSN.INSP_TMP_BSN"
	if :new.CD_ETUDE_BSN__ETUDE is not null then 
		open c1_insp_tmp_bsn ( :new.CD_ETUDE_BSN__ETUDE);
		fetch c1_insp_tmp_bsn into dummy;
		found := c1_insp_tmp_bsn%FOUND;
		close c1_insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ETUDE_BSN". Impossible de créer un enfant dans "BSN.INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_METEO_BSN" doit exister à la création d'un enfant dans "BSN.INSP_TMP_BSN"
	if :new.CD_METEO_BSN__METEO is not null then 
		open c2_insp_tmp_bsn ( :new.CD_METEO_BSN__METEO);
		fetch c2_insp_tmp_bsn into dummy;
		found := c2_insp_tmp_bsn%FOUND;
		close c2_insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_METEO_BSN". Impossible de créer un enfant dans "BSN.INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.DSC_TEMP_BSN" doit exister à la création d'un enfant dans "BSN.INSP_TMP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and 
	:new.DSC_TEMP_BSN__NUM_BSN is not null then 
		open c3_insp_tmp_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_TEMP_BSN__NUM_BSN);
		fetch c3_insp_tmp_bsn into dummy;
		found := c3_insp_tmp_bsn%FOUND;
		close c3_insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_TEMP_BSN". Impossible de créer un enfant dans "BSN.INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.INSPECTEUR_BSN" doit exister à la création d'un enfant dans "BSN.INSP_TMP_BSN"
	if :new.INSPECTEUR_BSN__NOM is not null then 
		open c4_insp_tmp_bsn ( :new.INSPECTEUR_BSN__NOM);
		fetch c4_insp_tmp_bsn into dummy;
		found := c4_insp_tmp_bsn%FOUND;
		close c4_insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.INSPECTEUR_BSN". Impossible de créer un enfant dans "BSN.INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_INSPTMPBSN" before update
on BSN.INSP_TMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_ETUDE_BSN"
	cursor c1_insp_tmp_bsn (Vcd_etude_bsn__etude varchar) is
		select 1 
		from BSN.CD_ETUDE_BSN 
		where 
		ETUDE = Vcd_etude_bsn__etude and Vcd_etude_bsn__etude is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_METEO_BSN"
	cursor c2_insp_tmp_bsn (Vcd_meteo_bsn__meteo varchar) is
		select 1 
		from BSN.CD_METEO_BSN 
		where 
		METEO = Vcd_meteo_bsn__meteo and Vcd_meteo_bsn__meteo is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.DSC_TEMP_BSN"
	cursor c3_insp_tmp_bsn (Vcamp_bsn__id_camp varchar,
	Vdsc_temp_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_TEMP_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		NUM_BSN = Vdsc_temp_bsn__num_bsn and Vdsc_temp_bsn__num_bsn is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.INSPECTEUR_BSN"
	cursor c4_insp_tmp_bsn (Vinspecteur_bsn__nom varchar) is
		select 1 
		from BSN.INSPECTEUR_BSN 
		where 
		NOM = Vinspecteur_bsn__nom and Vinspecteur_bsn__nom is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.CD_ETUDE_BSN" doit exister à la création d'un enfant dans "BSN.INSP_TMP_BSN"
	if :new.CD_ETUDE_BSN__ETUDE is not null and seq = 0 then 
		open c1_insp_tmp_bsn ( :new.CD_ETUDE_BSN__ETUDE);
		fetch c1_insp_tmp_bsn into dummy;
		found := c1_insp_tmp_bsn%FOUND;
		close c1_insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ETUDE_BSN". Impossible de modifier un enfant dans "BSN.INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_METEO_BSN" doit exister à la création d'un enfant dans "BSN.INSP_TMP_BSN"
	if :new.CD_METEO_BSN__METEO is not null and seq = 0 then 
		open c2_insp_tmp_bsn ( :new.CD_METEO_BSN__METEO);
		fetch c2_insp_tmp_bsn into dummy;
		found := c2_insp_tmp_bsn%FOUND;
		close c2_insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_METEO_BSN". Impossible de modifier un enfant dans "BSN.INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.DSC_TEMP_BSN" doit exister à la création d'un enfant dans "BSN.INSP_TMP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and seq = 0 and 
	:new.DSC_TEMP_BSN__NUM_BSN is not null and seq = 0 then 
		open c3_insp_tmp_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_TEMP_BSN__NUM_BSN);
		fetch c3_insp_tmp_bsn into dummy;
		found := c3_insp_tmp_bsn%FOUND;
		close c3_insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_TEMP_BSN". Impossible de modifier un enfant dans "BSN.INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.INSPECTEUR_BSN" doit exister à la création d'un enfant dans "BSN.INSP_TMP_BSN"
	if :new.INSPECTEUR_BSN__NOM is not null and seq = 0 then 
		open c4_insp_tmp_bsn ( :new.INSPECTEUR_BSN__NOM);
		fetch c4_insp_tmp_bsn into dummy;
		found := c4_insp_tmp_bsn%FOUND;
		close c4_insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.INSPECTEUR_BSN". Impossible de modifier un enfant dans "BSN.INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_INSPTMPBSN" after update
of CAMP_BSN__ID_CAMP,DSC_TEMP_BSN__NUM_BSN
on BSN.INSP_TMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.INSP_TMP_BSN" dans les enfants "BSN.PHOTO_INSP_TMP_BSN"
	if ((updating('CAMP_BSN__ID_CAMP') and :old.CAMP_BSN__ID_CAMP != :new.CAMP_BSN__ID_CAMP) or 
	(updating('DSC_TEMP_BSN__NUM_BSN') and :old.DSC_TEMP_BSN__NUM_BSN != :new.DSC_TEMP_BSN__NUM_BSN)) then 
		update BSN.PHOTO_INSP_TMP_BSN
		set CAMP_BSN__ID_CAMP = :new.CAMP_BSN__ID_CAMP,
		DSC_TEMP_BSN__NUM_BSN = :new.DSC_TEMP_BSN__NUM_BSN  
		where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
		DSC_TEMP_BSN__NUM_BSN = :old.DSC_TEMP_BSN__NUM_BSN;
	end if;
	--  Modification du code du parent "BSN.INSP_TMP_BSN" dans les enfants "BSN.ELT_INSP_TMP_BSN"
	if ((updating('CAMP_BSN__ID_CAMP') and :old.CAMP_BSN__ID_CAMP != :new.CAMP_BSN__ID_CAMP) or 
	(updating('DSC_TEMP_BSN__NUM_BSN') and :old.DSC_TEMP_BSN__NUM_BSN != :new.DSC_TEMP_BSN__NUM_BSN)) then 
		update BSN.ELT_INSP_TMP_BSN
		set CAMP_BSN__ID_CAMP = :new.CAMP_BSN__ID_CAMP,
		DSC_TEMP_BSN__NUM_BSN = :new.DSC_TEMP_BSN__NUM_BSN  
		where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
		DSC_TEMP_BSN__NUM_BSN = :old.DSC_TEMP_BSN__NUM_BSN;
	end if;
	--  Modification du code du parent "BSN.INSP_TMP_BSN" dans les enfants "BSN.CD_CONCLUSION__INSP_TMP_BSN"
	if ((updating('CAMP_BSN__ID_CAMP') and :old.CAMP_BSN__ID_CAMP != :new.CAMP_BSN__ID_CAMP) or 
	(updating('DSC_TEMP_BSN__NUM_BSN') and :old.DSC_TEMP_BSN__NUM_BSN != :new.DSC_TEMP_BSN__NUM_BSN)) then 
		update BSN.CD_CONCLUSION__INSP_TMP_BSN
		set CAMP_BSN__ID_CAMP = :new.CAMP_BSN__ID_CAMP,
		DSC_TEMP_BSN__NUM_BSN = :new.DSC_TEMP_BSN__NUM_BSN  
		where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
		DSC_TEMP_BSN__NUM_BSN = :old.DSC_TEMP_BSN__NUM_BSN;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_INSPTMPBSN" after delete
on BSN.INSP_TMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.PHOTO_INSP_TMP_BSN"
	delete BSN.PHOTO_INSP_TMP_BSN
	where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
	DSC_TEMP_BSN__NUM_BSN = :old.DSC_TEMP_BSN__NUM_BSN;
	
	--  Suppression des enfants dans "BSN.ELT_INSP_TMP_BSN"
	delete BSN.ELT_INSP_TMP_BSN
	where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
	DSC_TEMP_BSN__NUM_BSN = :old.DSC_TEMP_BSN__NUM_BSN;
	
	--  Suppression des enfants dans "BSN.CD_CONCLUSION__INSP_TMP_BSN"
	delete BSN.CD_CONCLUSION__INSP_TMP_BSN
	where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
	DSC_TEMP_BSN__NUM_BSN = :old.DSC_TEMP_BSN__NUM_BSN;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_CDLIGNEBSN" before insert
on BSN.CD_LIGNE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_CHAPITRE_BSN"
	cursor c1_cd_ligne_bsn(Vcd_chapitre_bsn__id_chap number) is
		select 1 
		from BSN.CD_CHAPITRE_BSN 
		where 
		ID_CHAP = Vcd_chapitre_bsn__id_chap and Vcd_chapitre_bsn__id_chap is not null;
begin

	
	--  Le parent "BSN.CD_CHAPITRE_BSN" doit exister à la création d'un enfant dans "BSN.CD_LIGNE_BSN"
	if :new.CD_CHAPITRE_BSN__ID_CHAP is not null then 
		open c1_cd_ligne_bsn ( :new.CD_CHAPITRE_BSN__ID_CHAP);
		fetch c1_cd_ligne_bsn into dummy;
		found := c1_cd_ligne_bsn%FOUND;
		close c1_cd_ligne_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_CHAPITRE_BSN". Impossible de créer un enfant dans "BSN.CD_LIGNE_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_CDLIGNEBSN" before update
on BSN.CD_LIGNE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_CHAPITRE_BSN"
	cursor c1_cd_ligne_bsn (Vcd_chapitre_bsn__id_chap number) is
		select 1 
		from BSN.CD_CHAPITRE_BSN 
		where 
		ID_CHAP = Vcd_chapitre_bsn__id_chap and Vcd_chapitre_bsn__id_chap is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.CD_CHAPITRE_BSN" doit exister à la création d'un enfant dans "BSN.CD_LIGNE_BSN"
	if :new.CD_CHAPITRE_BSN__ID_CHAP is not null and seq = 0 then 
		open c1_cd_ligne_bsn ( :new.CD_CHAPITRE_BSN__ID_CHAP);
		fetch c1_cd_ligne_bsn into dummy;
		found := c1_cd_ligne_bsn%FOUND;
		close c1_cd_ligne_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_CHAPITRE_BSN". Impossible de modifier un enfant dans "BSN.CD_LIGNE_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_CDLIGNEBSN" after update
of CD_CHAPITRE_BSN__ID_CHAP,ID_LIGNE
on BSN.CD_LIGNE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_LIGNE_BSN" dans les enfants "BSN.SPRT_VST_BSN"
	if ((updating('CD_CHAPITRE_BSN__ID_CHAP') and :old.CD_CHAPITRE_BSN__ID_CHAP != :new.CD_CHAPITRE_BSN__ID_CHAP) or 
	(updating('ID_LIGNE') and :old.ID_LIGNE != :new.ID_LIGNE)) then 
		update BSN.SPRT_VST_BSN
		set CD_CHAPITRE_BSN__ID_CHAP = :new.CD_CHAPITRE_BSN__ID_CHAP,
		CD_LIGNE_BSN__ID_LIGNE = :new.ID_LIGNE  
		where CD_CHAPITRE_BSN__ID_CHAP = :old.CD_CHAPITRE_BSN__ID_CHAP and 
		CD_LIGNE_BSN__ID_LIGNE = :old.ID_LIGNE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDLIGNEBSN" after delete
on BSN.CD_LIGNE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.SPRT_VST_BSN"
	delete BSN.SPRT_VST_BSN
	where CD_CHAPITRE_BSN__ID_CHAP = :old.CD_CHAPITRE_BSN__ID_CHAP and 
	CD_LIGNE_BSN__ID_LIGNE = :old.ID_LIGNE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TUA_CDMETEOBSN" after update
of METEO
on BSN.CD_METEO_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_METEO_BSN" dans les enfants "BSN.INSP_BSN"
	if ((updating('METEO') and :old.METEO != :new.METEO)) then 
		update BSN.INSP_BSN
		set CD_METEO_BSN__METEO = :new.METEO  
		where CD_METEO_BSN__METEO = :old.METEO;
	end if;
	--  Modification du code du parent "BSN.CD_METEO_BSN" dans les enfants "BSN.INSP_TMP_BSN"
	if ((updating('METEO') and :old.METEO != :new.METEO)) then 
		update BSN.INSP_TMP_BSN
		set CD_METEO_BSN__METEO = :new.METEO  
		where CD_METEO_BSN__METEO = :old.METEO;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDMETEOBSN" after delete
on BSN.CD_METEO_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.INSP_BSN"
	delete BSN.INSP_BSN
	where CD_METEO_BSN__METEO = :old.METEO;
	
	--  Suppression des enfants dans "BSN.INSP_TMP_BSN"
	delete BSN.INSP_TMP_BSN
	where CD_METEO_BSN__METEO = :old.METEO;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TUA_CDSOUSTYPEBSN" after update
of NAT_SENSIB
on BSN.CD_SOUS_TYPE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_SOUS_TYPE_BSN" dans les enfants "BSN.DSC_BSN"
	if ((updating('NAT_SENSIB') and :old.NAT_SENSIB != :new.NAT_SENSIB)) then 
		update BSN.DSC_BSN
		set CD_SOUS_TYPE_BSN__NAT_SENSIB = :new.NAT_SENSIB  
		where CD_SOUS_TYPE_BSN__NAT_SENSIB = :old.NAT_SENSIB;
	end if;
	--  Modification du code du parent "BSN.CD_SOUS_TYPE_BSN" dans les enfants "BSN.DSC_TEMP_BSN"
	if ((updating('NAT_SENSIB') and :old.NAT_SENSIB != :new.NAT_SENSIB)) then 
		update BSN.DSC_TEMP_BSN
		set CD_SOUS_TYPE_BSN__NAT_SENSIB = :new.NAT_SENSIB  
		where CD_SOUS_TYPE_BSN__NAT_SENSIB = :old.NAT_SENSIB;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDSOUSTYPEBSN" after delete
on BSN.CD_SOUS_TYPE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.DSC_BSN"
	delete BSN.DSC_BSN
	where CD_SOUS_TYPE_BSN__NAT_SENSIB = :old.NAT_SENSIB;
	
	--  Suppression des enfants dans "BSN.DSC_TEMP_BSN"
	delete BSN.DSC_TEMP_BSN
	where CD_SOUS_TYPE_BSN__NAT_SENSIB = :old.NAT_SENSIB;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_NATURETRAVBSN" before insert
on BSN.NATURE_TRAV_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_TRAVAUX_BSN"
	cursor c1_nature_trav_bsn(Vcd_travaux_bsn__code varchar) is
		select 1 
		from BSN.CD_TRAVAUX_BSN 
		where 
		CODE = Vcd_travaux_bsn__code and Vcd_travaux_bsn__code is not null;
begin

	
	--  Le parent "BSN.CD_TRAVAUX_BSN" doit exister à la création d'un enfant dans "BSN.NATURE_TRAV_BSN"
	if :new.CD_TRAVAUX_BSN__CODE is not null then 
		open c1_nature_trav_bsn ( :new.CD_TRAVAUX_BSN__CODE);
		fetch c1_nature_trav_bsn into dummy;
		found := c1_nature_trav_bsn%FOUND;
		close c1_nature_trav_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_TRAVAUX_BSN". Impossible de créer un enfant dans "BSN.NATURE_TRAV_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_NATURETRAVBSN" before update
on BSN.NATURE_TRAV_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_TRAVAUX_BSN"
	cursor c1_nature_trav_bsn (Vcd_travaux_bsn__code varchar) is
		select 1 
		from BSN.CD_TRAVAUX_BSN 
		where 
		CODE = Vcd_travaux_bsn__code and Vcd_travaux_bsn__code is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.CD_TRAVAUX_BSN" doit exister à la création d'un enfant dans "BSN.NATURE_TRAV_BSN"
	if :new.CD_TRAVAUX_BSN__CODE is not null and seq = 0 then 
		open c1_nature_trav_bsn ( :new.CD_TRAVAUX_BSN__CODE);
		fetch c1_nature_trav_bsn into dummy;
		found := c1_nature_trav_bsn%FOUND;
		close c1_nature_trav_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_TRAVAUX_BSN". Impossible de modifier un enfant dans "BSN.NATURE_TRAV_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_NATURETRAVBSN" after update
of CD_TRAVAUX_BSN__CODE,NATURE
on BSN.NATURE_TRAV_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.NATURE_TRAV_BSN" dans les enfants "BSN.TRAVAUX_BSN"
	if ((updating('CD_TRAVAUX_BSN__CODE') and :old.CD_TRAVAUX_BSN__CODE != :new.CD_TRAVAUX_BSN__CODE) or 
	(updating('NATURE') and :old.NATURE != :new.NATURE)) then 
		update BSN.TRAVAUX_BSN
		set CD_TRAVAUX_BSN__CODE = :new.CD_TRAVAUX_BSN__CODE,
		NATURE_TRAV_BSN__NATURE = :new.NATURE  
		where CD_TRAVAUX_BSN__CODE = :old.CD_TRAVAUX_BSN__CODE and 
		NATURE_TRAV_BSN__NATURE = :old.NATURE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_NATURETRAVBSN" after delete
on BSN.NATURE_TRAV_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.TRAVAUX_BSN"
	delete BSN.TRAVAUX_BSN
	where CD_TRAVAUX_BSN__CODE = :old.CD_TRAVAUX_BSN__CODE and 
	NATURE_TRAV_BSN__NATURE = :old.NATURE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TUA_CDORIGINBSN" after update
of ORIGINE
on BSN.CD_ORIGIN_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_ORIGIN_BSN" dans les enfants "BSN.HISTO_NOTE_BSN"
	if ((updating('ORIGINE') and :old.ORIGINE != :new.ORIGINE)) then 
		update BSN.HISTO_NOTE_BSN
		set CD_ORIGIN_BSN__ORIGINE = :new.ORIGINE  
		where CD_ORIGIN_BSN__ORIGINE = :old.ORIGINE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDORIGINBSN" after delete
on BSN.CD_ORIGIN_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.HISTO_NOTE_BSN"
	delete BSN.HISTO_NOTE_BSN
	where CD_ORIGIN_BSN__ORIGINE = :old.ORIGINE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_PRTBSN" before insert
on BSN.PRT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.GRP_BSN"
	cursor c1_prt_bsn(Vgrp_bsn__id_grp number) is
		select 1 
		from BSN.GRP_BSN 
		where 
		ID_GRP = Vgrp_bsn__id_grp and Vgrp_bsn__id_grp is not null;
begin

	
	--  Le parent "BSN.GRP_BSN" doit exister à la création d'un enfant dans "BSN.PRT_BSN"
	if :new.GRP_BSN__ID_GRP is not null then 
		open c1_prt_bsn ( :new.GRP_BSN__ID_GRP);
		fetch c1_prt_bsn into dummy;
		found := c1_prt_bsn%FOUND;
		close c1_prt_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.GRP_BSN". Impossible de créer un enfant dans "BSN.PRT_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_PRTBSN" before update
on BSN.PRT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.GRP_BSN"
	cursor c1_prt_bsn (Vgrp_bsn__id_grp number) is
		select 1 
		from BSN.GRP_BSN 
		where 
		ID_GRP = Vgrp_bsn__id_grp and Vgrp_bsn__id_grp is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.GRP_BSN" doit exister à la création d'un enfant dans "BSN.PRT_BSN"
	if :new.GRP_BSN__ID_GRP is not null and seq = 0 then 
		open c1_prt_bsn ( :new.GRP_BSN__ID_GRP);
		fetch c1_prt_bsn into dummy;
		found := c1_prt_bsn%FOUND;
		close c1_prt_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.GRP_BSN". Impossible de modifier un enfant dans "BSN.PRT_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_PRTBSN" after update
of GRP_BSN__ID_GRP,ID_PRT
on BSN.PRT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.PRT_BSN" dans les enfants "BSN.SPRT_BSN"
	if ((updating('GRP_BSN__ID_GRP') and :old.GRP_BSN__ID_GRP != :new.GRP_BSN__ID_GRP) or 
	(updating('ID_PRT') and :old.ID_PRT != :new.ID_PRT)) then 
		update BSN.SPRT_BSN
		set GRP_BSN__ID_GRP = :new.GRP_BSN__ID_GRP,
		PRT_BSN__ID_PRT = :new.ID_PRT  
		where GRP_BSN__ID_GRP = :old.GRP_BSN__ID_GRP and 
		PRT_BSN__ID_PRT = :old.ID_PRT;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_PRTBSN" after delete
on BSN.PRT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.SPRT_BSN"
	delete BSN.SPRT_BSN
	where GRP_BSN__ID_GRP = :old.GRP_BSN__ID_GRP and 
	PRT_BSN__ID_PRT = :old.ID_PRT;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TUA_CDPERMEABLEBSN" after update
of TYPE
on BSN.CD_PERMEABLE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_PERMEABLE_BSN" dans les enfants "BSN.DSC_BSN"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update BSN.DSC_BSN
		set CD_PERMEABLE_BSN__TYPE = :new.TYPE  
		where CD_PERMEABLE_BSN__TYPE = :old.TYPE;
	end if;
	--  Modification du code du parent "BSN.CD_PERMEABLE_BSN" dans les enfants "BSN.DSC_TEMP_BSN"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update BSN.DSC_TEMP_BSN
		set CD_PERMEABLE_BSN__TYPE = :new.TYPE  
		where CD_PERMEABLE_BSN__TYPE = :old.TYPE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDPERMEABLEBSN" after delete
on BSN.CD_PERMEABLE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.DSC_BSN"
	delete BSN.DSC_BSN
	where CD_PERMEABLE_BSN__TYPE = :old.TYPE;
	
	--  Suppression des enfants dans "BSN.DSC_TEMP_BSN"
	delete BSN.DSC_TEMP_BSN
	where CD_PERMEABLE_BSN__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_PHOTOINSPBSN" before insert
on BSN.PHOTO_INSP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.INSP_BSN"
	cursor c1_photo_insp_bsn(Vcamp_bsn__id_camp varchar,
	Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.INSP_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_BSN__NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	
	--  Le parent "BSN.INSP_BSN" doit exister à la création d'un enfant dans "BSN.PHOTO_INSP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and 
	:new.DSC_BSN__NUM_BSN is not null then 
		open c1_photo_insp_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_BSN__NUM_BSN);
		fetch c1_photo_insp_bsn into dummy;
		found := c1_photo_insp_bsn%FOUND;
		close c1_photo_insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.INSP_BSN". Impossible de créer un enfant dans "BSN.PHOTO_INSP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_PHOTOINSPBSN" before update
on BSN.PHOTO_INSP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.INSP_BSN"
	cursor c1_photo_insp_bsn (Vcamp_bsn__id_camp varchar,
	Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.INSP_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_BSN__NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.INSP_BSN" doit exister à la création d'un enfant dans "BSN.PHOTO_INSP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and seq = 0 and 
	:new.DSC_BSN__NUM_BSN is not null and seq = 0 then 
		open c1_photo_insp_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_BSN__NUM_BSN);
		fetch c1_photo_insp_bsn into dummy;
		found := c1_photo_insp_bsn%FOUND;
		close c1_photo_insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.INSP_BSN". Impossible de modifier un enfant dans "BSN.PHOTO_INSP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TIB_PHOTOINSPTMPBSN" before insert
on BSN.PHOTO_INSP_TMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.INSP_TMP_BSN"
	cursor c1_photo_insp_tmp_bsn(Vcamp_bsn__id_camp varchar,
	Vdsc_temp_bsn__num_bsn varchar) is
		select 1 
		from BSN.INSP_TMP_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_TEMP_BSN__NUM_BSN = Vdsc_temp_bsn__num_bsn and Vdsc_temp_bsn__num_bsn is not null;
begin

	
	--  Le parent "BSN.INSP_TMP_BSN" doit exister à la création d'un enfant dans "BSN.PHOTO_INSP_TMP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and 
	:new.DSC_TEMP_BSN__NUM_BSN is not null then 
		open c1_photo_insp_tmp_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_TEMP_BSN__NUM_BSN);
		fetch c1_photo_insp_tmp_bsn into dummy;
		found := c1_photo_insp_tmp_bsn%FOUND;
		close c1_photo_insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.INSP_TMP_BSN". Impossible de créer un enfant dans "BSN.PHOTO_INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_PHOTOINSPTMPBSN" before update
on BSN.PHOTO_INSP_TMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.INSP_TMP_BSN"
	cursor c1_photo_insp_tmp_bsn (Vcamp_bsn__id_camp varchar,
	Vdsc_temp_bsn__num_bsn varchar) is
		select 1 
		from BSN.INSP_TMP_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_TEMP_BSN__NUM_BSN = Vdsc_temp_bsn__num_bsn and Vdsc_temp_bsn__num_bsn is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.INSP_TMP_BSN" doit exister à la création d'un enfant dans "BSN.PHOTO_INSP_TMP_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and seq = 0 and 
	:new.DSC_TEMP_BSN__NUM_BSN is not null and seq = 0 then 
		open c1_photo_insp_tmp_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_TEMP_BSN__NUM_BSN);
		fetch c1_photo_insp_tmp_bsn into dummy;
		found := c1_photo_insp_tmp_bsn%FOUND;
		close c1_photo_insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.INSP_TMP_BSN". Impossible de modifier un enfant dans "BSN.PHOTO_INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TIB_PHOTOELTINSPBSN" before insert
on BSN.PHOTO_ELT_INSP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.ELT_INSP_BSN"
	cursor c1_photo_elt_insp_bsn(Vgrp_bsn__id_grp number,
	Vprt_bsn__id_prt number,
	Vsprt_bsn__id_sprt number,
	Vcamp_bsn__id_camp varchar,
	Velt_bsn__id_elem number,
	Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.ELT_INSP_BSN 
		where 
		GRP_BSN__ID_GRP = Vgrp_bsn__id_grp and Vgrp_bsn__id_grp is not null and 
		PRT_BSN__ID_PRT = Vprt_bsn__id_prt and Vprt_bsn__id_prt is not null and 
		SPRT_BSN__ID_SPRT = Vsprt_bsn__id_sprt and Vsprt_bsn__id_sprt is not null and 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		ELT_BSN__ID_ELEM = Velt_bsn__id_elem and Velt_bsn__id_elem is not null and 
		DSC_BSN__NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	
	--  Le parent "BSN.ELT_INSP_BSN" doit exister à la création d'un enfant dans "BSN.PHOTO_ELT_INSP_BSN"
	if :new.GRP_BSN__ID_GRP is not null and 
	:new.PRT_BSN__ID_PRT is not null and 
	:new.SPRT_BSN__ID_SPRT is not null and 
	:new.CAMP_BSN__ID_CAMP is not null and 
	:new.ELT_BSN__ID_ELEM is not null and 
	:new.DSC_BSN__NUM_BSN is not null then 
		open c1_photo_elt_insp_bsn ( :new.GRP_BSN__ID_GRP,
		:new.PRT_BSN__ID_PRT,
		:new.SPRT_BSN__ID_SPRT,
		:new.CAMP_BSN__ID_CAMP,
		:new.ELT_BSN__ID_ELEM,
		:new.DSC_BSN__NUM_BSN);
		fetch c1_photo_elt_insp_bsn into dummy;
		found := c1_photo_elt_insp_bsn%FOUND;
		close c1_photo_elt_insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.ELT_INSP_BSN". Impossible de créer un enfant dans "BSN.PHOTO_ELT_INSP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_PHOTOELTINSPBSN" before update
on BSN.PHOTO_ELT_INSP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.ELT_INSP_BSN"
	cursor c1_photo_elt_insp_bsn (Vgrp_bsn__id_grp number,
	Vprt_bsn__id_prt number,
	Vsprt_bsn__id_sprt number,
	Vcamp_bsn__id_camp varchar,
	Velt_bsn__id_elem number,
	Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.ELT_INSP_BSN 
		where 
		GRP_BSN__ID_GRP = Vgrp_bsn__id_grp and Vgrp_bsn__id_grp is not null and 
		PRT_BSN__ID_PRT = Vprt_bsn__id_prt and Vprt_bsn__id_prt is not null and 
		SPRT_BSN__ID_SPRT = Vsprt_bsn__id_sprt and Vsprt_bsn__id_sprt is not null and 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		ELT_BSN__ID_ELEM = Velt_bsn__id_elem and Velt_bsn__id_elem is not null and 
		DSC_BSN__NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.ELT_INSP_BSN" doit exister à la création d'un enfant dans "BSN.PHOTO_ELT_INSP_BSN"
	if :new.GRP_BSN__ID_GRP is not null and seq = 0 and 
	:new.PRT_BSN__ID_PRT is not null and seq = 0 and 
	:new.SPRT_BSN__ID_SPRT is not null and seq = 0 and 
	:new.CAMP_BSN__ID_CAMP is not null and seq = 0 and 
	:new.ELT_BSN__ID_ELEM is not null and seq = 0 and 
	:new.DSC_BSN__NUM_BSN is not null and seq = 0 then 
		open c1_photo_elt_insp_bsn ( :new.GRP_BSN__ID_GRP,
		:new.PRT_BSN__ID_PRT,
		:new.SPRT_BSN__ID_SPRT,
		:new.CAMP_BSN__ID_CAMP,
		:new.ELT_BSN__ID_ELEM,
		:new.DSC_BSN__NUM_BSN);
		fetch c1_photo_elt_insp_bsn into dummy;
		found := c1_photo_elt_insp_bsn%FOUND;
		close c1_photo_elt_insp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.ELT_INSP_BSN". Impossible de modifier un enfant dans "BSN.PHOTO_ELT_INSP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TIB_PHOTOELTINSPTMPBSN" before insert
on BSN.PHOTO_ELT_INSP_TMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.ELT_INSP_TMP_BSN"
	cursor c1_photo_elt_insp_tmp_bsn(Vgrp_bsn__id_grp number,
	Vprt_bsn__id_prt number,
	Vsprt_bsn__id_sprt number,
	Vcamp_bsn__id_camp varchar,
	Vdsc_temp_bsn__num_bsn varchar,
	Velt_bsn__id_elem number) is
		select 1 
		from BSN.ELT_INSP_TMP_BSN 
		where 
		GRP_BSN__ID_GRP = Vgrp_bsn__id_grp and Vgrp_bsn__id_grp is not null and 
		PRT_BSN__ID_PRT = Vprt_bsn__id_prt and Vprt_bsn__id_prt is not null and 
		SPRT_BSN__ID_SPRT = Vsprt_bsn__id_sprt and Vsprt_bsn__id_sprt is not null and 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_TEMP_BSN__NUM_BSN = Vdsc_temp_bsn__num_bsn and Vdsc_temp_bsn__num_bsn is not null and 
		ELT_BSN__ID_ELEM = Velt_bsn__id_elem and Velt_bsn__id_elem is not null;
begin

	
	--  Le parent "BSN.ELT_INSP_TMP_BSN" doit exister à la création d'un enfant dans "BSN.PHOTO_ELT_INSP_TMP_BSN"
	if :new.GRP_BSN__ID_GRP is not null and 
	:new.PRT_BSN__ID_PRT is not null and 
	:new.SPRT_BSN__ID_SPRT is not null and 
	:new.CAMP_BSN__ID_CAMP is not null and 
	:new.DSC_TEMP_BSN__NUM_BSN is not null and 
	:new.ELT_BSN__ID_ELEM is not null then 
		open c1_photo_elt_insp_tmp_bsn ( :new.GRP_BSN__ID_GRP,
		:new.PRT_BSN__ID_PRT,
		:new.SPRT_BSN__ID_SPRT,
		:new.CAMP_BSN__ID_CAMP,
		:new.DSC_TEMP_BSN__NUM_BSN,
		:new.ELT_BSN__ID_ELEM);
		fetch c1_photo_elt_insp_tmp_bsn into dummy;
		found := c1_photo_elt_insp_tmp_bsn%FOUND;
		close c1_photo_elt_insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.ELT_INSP_TMP_BSN". Impossible de créer un enfant dans "BSN.PHOTO_ELT_INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_PHOTOELTINSPTMPBSN" before update
on BSN.PHOTO_ELT_INSP_TMP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.ELT_INSP_TMP_BSN"
	cursor c1_photo_elt_insp_tmp_bsn (Vgrp_bsn__id_grp number,
	Vprt_bsn__id_prt number,
	Vsprt_bsn__id_sprt number,
	Vcamp_bsn__id_camp varchar,
	Vdsc_temp_bsn__num_bsn varchar,
	Velt_bsn__id_elem number) is
		select 1 
		from BSN.ELT_INSP_TMP_BSN 
		where 
		GRP_BSN__ID_GRP = Vgrp_bsn__id_grp and Vgrp_bsn__id_grp is not null and 
		PRT_BSN__ID_PRT = Vprt_bsn__id_prt and Vprt_bsn__id_prt is not null and 
		SPRT_BSN__ID_SPRT = Vsprt_bsn__id_sprt and Vsprt_bsn__id_sprt is not null and 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_TEMP_BSN__NUM_BSN = Vdsc_temp_bsn__num_bsn and Vdsc_temp_bsn__num_bsn is not null and 
		ELT_BSN__ID_ELEM = Velt_bsn__id_elem and Velt_bsn__id_elem is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.ELT_INSP_TMP_BSN" doit exister à la création d'un enfant dans "BSN.PHOTO_ELT_INSP_TMP_BSN"
	if :new.GRP_BSN__ID_GRP is not null and seq = 0 and 
	:new.PRT_BSN__ID_PRT is not null and seq = 0 and 
	:new.SPRT_BSN__ID_SPRT is not null and seq = 0 and 
	:new.CAMP_BSN__ID_CAMP is not null and seq = 0 and 
	:new.DSC_TEMP_BSN__NUM_BSN is not null and seq = 0 and 
	:new.ELT_BSN__ID_ELEM is not null and seq = 0 then 
		open c1_photo_elt_insp_tmp_bsn ( :new.GRP_BSN__ID_GRP,
		:new.PRT_BSN__ID_PRT,
		:new.SPRT_BSN__ID_SPRT,
		:new.CAMP_BSN__ID_CAMP,
		:new.DSC_TEMP_BSN__NUM_BSN,
		:new.ELT_BSN__ID_ELEM);
		fetch c1_photo_elt_insp_tmp_bsn into dummy;
		found := c1_photo_elt_insp_tmp_bsn%FOUND;
		close c1_photo_elt_insp_tmp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.ELT_INSP_TMP_BSN". Impossible de modifier un enfant dans "BSN.PHOTO_ELT_INSP_TMP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TIB_PHOTOSPRTVSTBSN" before insert
on BSN.PHOTO_SPRT_VST_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.SPRT_VST_BSN"
	cursor c1_photo_sprt_vst_bsn(Vcamp_bsn__id_camp varchar,
	Vdsc_bsn__num_bsn varchar,
	Vcd_chapitre_bsn__id_chap number,
	Vcd_ligne_bsn__id_ligne number) is
		select 1 
		from BSN.SPRT_VST_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_BSN__NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null and 
		CD_CHAPITRE_BSN__ID_CHAP = Vcd_chapitre_bsn__id_chap and Vcd_chapitre_bsn__id_chap is not null and 
		CD_LIGNE_BSN__ID_LIGNE = Vcd_ligne_bsn__id_ligne and Vcd_ligne_bsn__id_ligne is not null;
begin

	
	--  Le parent "BSN.SPRT_VST_BSN" doit exister à la création d'un enfant dans "BSN.PHOTO_SPRT_VST_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and 
	:new.DSC_BSN__NUM_BSN is not null and 
	:new.CD_CHAPITRE_BSN__ID_CHAP is not null and 
	:new.CD_LIGNE_BSN__ID_LIGNE is not null then 
		open c1_photo_sprt_vst_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_BSN__NUM_BSN,
		:new.CD_CHAPITRE_BSN__ID_CHAP,
		:new.CD_LIGNE_BSN__ID_LIGNE);
		fetch c1_photo_sprt_vst_bsn into dummy;
		found := c1_photo_sprt_vst_bsn%FOUND;
		close c1_photo_sprt_vst_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.SPRT_VST_BSN". Impossible de créer un enfant dans "BSN.PHOTO_SPRT_VST_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_PHOTOSPRTVSTBSN" before update
on BSN.PHOTO_SPRT_VST_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.SPRT_VST_BSN"
	cursor c1_photo_sprt_vst_bsn (Vcamp_bsn__id_camp varchar,
	Vdsc_bsn__num_bsn varchar,
	Vcd_chapitre_bsn__id_chap number,
	Vcd_ligne_bsn__id_ligne number) is
		select 1 
		from BSN.SPRT_VST_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_BSN__NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null and 
		CD_CHAPITRE_BSN__ID_CHAP = Vcd_chapitre_bsn__id_chap and Vcd_chapitre_bsn__id_chap is not null and 
		CD_LIGNE_BSN__ID_LIGNE = Vcd_ligne_bsn__id_ligne and Vcd_ligne_bsn__id_ligne is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.SPRT_VST_BSN" doit exister à la création d'un enfant dans "BSN.PHOTO_SPRT_VST_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and seq = 0 and 
	:new.DSC_BSN__NUM_BSN is not null and seq = 0 and 
	:new.CD_CHAPITRE_BSN__ID_CHAP is not null and seq = 0 and 
	:new.CD_LIGNE_BSN__ID_LIGNE is not null and seq = 0 then 
		open c1_photo_sprt_vst_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_BSN__NUM_BSN,
		:new.CD_CHAPITRE_BSN__ID_CHAP,
		:new.CD_LIGNE_BSN__ID_LIGNE);
		fetch c1_photo_sprt_vst_bsn into dummy;
		found := c1_photo_sprt_vst_bsn%FOUND;
		close c1_photo_sprt_vst_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.SPRT_VST_BSN". Impossible de modifier un enfant dans "BSN.PHOTO_SPRT_VST_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TIB_PHOTOVSTBSN" before insert
on BSN.PHOTO_VST_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.VST_BSN"
	cursor c1_photo_vst_bsn(Vcamp_bsn__id_camp varchar,
	Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.VST_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_BSN__NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	
	--  Le parent "BSN.VST_BSN" doit exister à la création d'un enfant dans "BSN.PHOTO_VST_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and 
	:new.DSC_BSN__NUM_BSN is not null then 
		open c1_photo_vst_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_BSN__NUM_BSN);
		fetch c1_photo_vst_bsn into dummy;
		found := c1_photo_vst_bsn%FOUND;
		close c1_photo_vst_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.VST_BSN". Impossible de créer un enfant dans "BSN.PHOTO_VST_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_PHOTOVSTBSN" before update
on BSN.PHOTO_VST_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.VST_BSN"
	cursor c1_photo_vst_bsn (Vcamp_bsn__id_camp varchar,
	Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.VST_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_BSN__NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.VST_BSN" doit exister à la création d'un enfant dans "BSN.PHOTO_VST_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and seq = 0 and 
	:new.DSC_BSN__NUM_BSN is not null and seq = 0 then 
		open c1_photo_vst_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_BSN__NUM_BSN);
		fetch c1_photo_vst_bsn into dummy;
		found := c1_photo_vst_bsn%FOUND;
		close c1_photo_vst_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.VST_BSN". Impossible de modifier un enfant dans "BSN.PHOTO_VST_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TIB_CDPRECOSPRTVSTBSN" before insert
on BSN.CD_PRECO__SPRT_VST_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.BPU_BSN"
	cursor c1_cd_preco__sprt_vst_bsn(Vbpu_bsn__id_bpu number) is
		select 1 
		from BSN.BPU_BSN 
		where 
		ID_BPU = Vbpu_bsn__id_bpu and Vbpu_bsn__id_bpu is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.SPRT_VST_BSN"
	cursor c2_cd_preco__sprt_vst_bsn(Vcamp_bsn__id_camp varchar,
	Vdsc_bsn__num_bsn varchar,
	Vcd_chapitre_bsn__id_chap number,
	Vcd_ligne_bsn__id_ligne number) is
		select 1 
		from BSN.SPRT_VST_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_BSN__NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null and 
		CD_CHAPITRE_BSN__ID_CHAP = Vcd_chapitre_bsn__id_chap and Vcd_chapitre_bsn__id_chap is not null and 
		CD_LIGNE_BSN__ID_LIGNE = Vcd_ligne_bsn__id_ligne and Vcd_ligne_bsn__id_ligne is not null;
begin

	
	--  Le parent "BSN.BPU_BSN" doit exister à la création d'un enfant dans "BSN.CD_PRECO__SPRT_VST_BSN"
	if :new.BPU_BSN__ID_BPU is not null then 
		open c1_cd_preco__sprt_vst_bsn ( :new.BPU_BSN__ID_BPU);
		fetch c1_cd_preco__sprt_vst_bsn into dummy;
		found := c1_cd_preco__sprt_vst_bsn%FOUND;
		close c1_cd_preco__sprt_vst_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.BPU_BSN". Impossible de créer un enfant dans "BSN.CD_PRECO__SPRT_VST_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.SPRT_VST_BSN" doit exister à la création d'un enfant dans "BSN.CD_PRECO__SPRT_VST_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and 
	:new.DSC_BSN__NUM_BSN is not null and 
	:new.CD_CHAPITRE_BSN__ID_CHAP is not null and 
	:new.CD_LIGNE_BSN__ID_LIGNE is not null then 
		open c2_cd_preco__sprt_vst_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_BSN__NUM_BSN,
		:new.CD_CHAPITRE_BSN__ID_CHAP,
		:new.CD_LIGNE_BSN__ID_LIGNE);
		fetch c2_cd_preco__sprt_vst_bsn into dummy;
		found := c2_cd_preco__sprt_vst_bsn%FOUND;
		close c2_cd_preco__sprt_vst_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.SPRT_VST_BSN". Impossible de créer un enfant dans "BSN.CD_PRECO__SPRT_VST_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_CDPRECOSPRTVSTBSN" before update
on BSN.CD_PRECO__SPRT_VST_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.BPU_BSN"
	cursor c1_cd_preco__sprt_vst_bsn (Vbpu_bsn__id_bpu number) is
		select 1 
		from BSN.BPU_BSN 
		where 
		ID_BPU = Vbpu_bsn__id_bpu and Vbpu_bsn__id_bpu is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.SPRT_VST_BSN"
	cursor c2_cd_preco__sprt_vst_bsn (Vcamp_bsn__id_camp varchar,
	Vdsc_bsn__num_bsn varchar,
	Vcd_chapitre_bsn__id_chap number,
	Vcd_ligne_bsn__id_ligne number) is
		select 1 
		from BSN.SPRT_VST_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_BSN__NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null and 
		CD_CHAPITRE_BSN__ID_CHAP = Vcd_chapitre_bsn__id_chap and Vcd_chapitre_bsn__id_chap is not null and 
		CD_LIGNE_BSN__ID_LIGNE = Vcd_ligne_bsn__id_ligne and Vcd_ligne_bsn__id_ligne is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.BPU_BSN" doit exister à la création d'un enfant dans "BSN.CD_PRECO__SPRT_VST_BSN"
	if :new.BPU_BSN__ID_BPU is not null and seq = 0 then 
		open c1_cd_preco__sprt_vst_bsn ( :new.BPU_BSN__ID_BPU);
		fetch c1_cd_preco__sprt_vst_bsn into dummy;
		found := c1_cd_preco__sprt_vst_bsn%FOUND;
		close c1_cd_preco__sprt_vst_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.BPU_BSN". Impossible de modifier un enfant dans "BSN.CD_PRECO__SPRT_VST_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.SPRT_VST_BSN" doit exister à la création d'un enfant dans "BSN.CD_PRECO__SPRT_VST_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and seq = 0 and 
	:new.DSC_BSN__NUM_BSN is not null and seq = 0 and 
	:new.CD_CHAPITRE_BSN__ID_CHAP is not null and seq = 0 and 
	:new.CD_LIGNE_BSN__ID_LIGNE is not null and seq = 0 then 
		open c2_cd_preco__sprt_vst_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_BSN__NUM_BSN,
		:new.CD_CHAPITRE_BSN__ID_CHAP,
		:new.CD_LIGNE_BSN__ID_LIGNE);
		fetch c2_cd_preco__sprt_vst_bsn into dummy;
		found := c2_cd_preco__sprt_vst_bsn%FOUND;
		close c2_cd_preco__sprt_vst_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.SPRT_VST_BSN". Impossible de modifier un enfant dans "BSN.CD_PRECO__SPRT_VST_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_CDPRESTABSN" after update
of PRESTATAIRE
on BSN.CD_PRESTA_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_PRESTA_BSN" dans les enfants "BSN.CAMP_BSN"
	if ((updating('PRESTATAIRE') and :old.PRESTATAIRE != :new.PRESTATAIRE)) then 
		update BSN.CAMP_BSN
		set CD_PRESTA_BSN__PRESTATAIRE = :new.PRESTATAIRE  
		where CD_PRESTA_BSN__PRESTATAIRE = :old.PRESTATAIRE;
	end if;
	--  Modification du code du parent "BSN.CD_PRESTA_BSN" dans les enfants "BSN.INSPECTEUR_BSN"
	if ((updating('PRESTATAIRE') and :old.PRESTATAIRE != :new.PRESTATAIRE)) then 
		update BSN.INSPECTEUR_BSN
		set CD_PRESTA_BSN__PRESTATAIRE = :new.PRESTATAIRE  
		where CD_PRESTA_BSN__PRESTATAIRE = :old.PRESTATAIRE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDPRESTABSN" after delete
on BSN.CD_PRESTA_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.CAMP_BSN"
	delete BSN.CAMP_BSN
	where CD_PRESTA_BSN__PRESTATAIRE = :old.PRESTATAIRE;
	
	--  Suppression des enfants dans "BSN.INSPECTEUR_BSN"
	delete BSN.INSPECTEUR_BSN
	where CD_PRESTA_BSN__PRESTATAIRE = :old.PRESTATAIRE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_PREVISIONBSN" before insert
on BSN.PREVISION_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c1_prevision_bsn(Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.BPU_BSN"
	cursor c2_prevision_bsn(Vbpu_bsn__id_bpu number) is
		select 1 
		from BSN.BPU_BSN 
		where 
		ID_BPU = Vbpu_bsn__id_bpu and Vbpu_bsn__id_bpu is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_CONTRAINTE_BSN"
	cursor c3_prevision_bsn(Vcd_contrainte_bsn__type varchar) is
		select 1 
		from BSN.CD_CONTRAINTE_BSN 
		where 
		TYPE = Vcd_contrainte_bsn__type and Vcd_contrainte_bsn__type is not null;
begin

	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.PREVISION_BSN"
	if :new.DSC_BSN__NUM_BSN is not null then 
		open c1_prevision_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c1_prevision_bsn into dummy;
		found := c1_prevision_bsn%FOUND;
		close c1_prevision_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de créer un enfant dans "BSN.PREVISION_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.BPU_BSN" doit exister à la création d'un enfant dans "BSN.PREVISION_BSN"
	if :new.BPU_BSN__ID_BPU is not null then 
		open c2_prevision_bsn ( :new.BPU_BSN__ID_BPU);
		fetch c2_prevision_bsn into dummy;
		found := c2_prevision_bsn%FOUND;
		close c2_prevision_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.BPU_BSN". Impossible de créer un enfant dans "BSN.PREVISION_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_CONTRAINTE_BSN" doit exister à la création d'un enfant dans "BSN.PREVISION_BSN"
	if :new.CD_CONTRAINTE_BSN__TYPE is not null then 
		open c3_prevision_bsn ( :new.CD_CONTRAINTE_BSN__TYPE);
		fetch c3_prevision_bsn into dummy;
		found := c3_prevision_bsn%FOUND;
		close c3_prevision_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_CONTRAINTE_BSN". Impossible de créer un enfant dans "BSN.PREVISION_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_PREVISIONBSN" before update
on BSN.PREVISION_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c1_prevision_bsn (Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.BPU_BSN"
	cursor c2_prevision_bsn (Vbpu_bsn__id_bpu number) is
		select 1 
		from BSN.BPU_BSN 
		where 
		ID_BPU = Vbpu_bsn__id_bpu and Vbpu_bsn__id_bpu is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_CONTRAINTE_BSN"
	cursor c3_prevision_bsn (Vcd_contrainte_bsn__type varchar) is
		select 1 
		from BSN.CD_CONTRAINTE_BSN 
		where 
		TYPE = Vcd_contrainte_bsn__type and Vcd_contrainte_bsn__type is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.PREVISION_BSN"
	if :new.DSC_BSN__NUM_BSN is not null and seq = 0 then 
		open c1_prevision_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c1_prevision_bsn into dummy;
		found := c1_prevision_bsn%FOUND;
		close c1_prevision_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de modifier un enfant dans "BSN.PREVISION_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.BPU_BSN" doit exister à la création d'un enfant dans "BSN.PREVISION_BSN"
	if :new.BPU_BSN__ID_BPU is not null and seq = 0 then 
		open c2_prevision_bsn ( :new.BPU_BSN__ID_BPU);
		fetch c2_prevision_bsn into dummy;
		found := c2_prevision_bsn%FOUND;
		close c2_prevision_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.BPU_BSN". Impossible de modifier un enfant dans "BSN.PREVISION_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_CONTRAINTE_BSN" doit exister à la création d'un enfant dans "BSN.PREVISION_BSN"
	if :new.CD_CONTRAINTE_BSN__TYPE is not null and seq = 0 then 
		open c3_prevision_bsn ( :new.CD_CONTRAINTE_BSN__TYPE);
		fetch c3_prevision_bsn into dummy;
		found := c3_prevision_bsn%FOUND;
		close c3_prevision_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_CONTRAINTE_BSN". Impossible de modifier un enfant dans "BSN.PREVISION_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_CDROLEBSN" after update
of ROLE
on BSN.CD_ROLE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_ROLE_BSN" dans les enfants "BSN.CD_ROLE__DSC_BSN"
	if ((updating('ROLE') and :old.ROLE != :new.ROLE)) then 
		update BSN.CD_ROLE__DSC_BSN
		set CD_ROLE_BSN__ROLE = :new.ROLE  
		where CD_ROLE_BSN__ROLE = :old.ROLE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDROLEBSN" after delete
on BSN.CD_ROLE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.CD_ROLE__DSC_BSN"
	delete BSN.CD_ROLE__DSC_BSN
	where CD_ROLE_BSN__ROLE = :old.ROLE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_CDROLEDSCBSN" before insert
on BSN.CD_ROLE__DSC_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c1_cd_role__dsc_bsn(Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_ROLE_BSN"
	cursor c2_cd_role__dsc_bsn(Vcd_role_bsn__role varchar) is
		select 1 
		from BSN.CD_ROLE_BSN 
		where 
		ROLE = Vcd_role_bsn__role and Vcd_role_bsn__role is not null;
begin

	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.CD_ROLE__DSC_BSN"
	if :new.DSC_BSN__NUM_BSN is not null then 
		open c1_cd_role__dsc_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c1_cd_role__dsc_bsn into dummy;
		found := c1_cd_role__dsc_bsn%FOUND;
		close c1_cd_role__dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de créer un enfant dans "BSN.CD_ROLE__DSC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_ROLE_BSN" doit exister à la création d'un enfant dans "BSN.CD_ROLE__DSC_BSN"
	if :new.CD_ROLE_BSN__ROLE is not null then 
		open c2_cd_role__dsc_bsn ( :new.CD_ROLE_BSN__ROLE);
		fetch c2_cd_role__dsc_bsn into dummy;
		found := c2_cd_role__dsc_bsn%FOUND;
		close c2_cd_role__dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ROLE_BSN". Impossible de créer un enfant dans "BSN.CD_ROLE__DSC_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_CDROLEDSCBSN" before update
on BSN.CD_ROLE__DSC_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c1_cd_role__dsc_bsn (Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_ROLE_BSN"
	cursor c2_cd_role__dsc_bsn (Vcd_role_bsn__role varchar) is
		select 1 
		from BSN.CD_ROLE_BSN 
		where 
		ROLE = Vcd_role_bsn__role and Vcd_role_bsn__role is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.CD_ROLE__DSC_BSN"
	if :new.DSC_BSN__NUM_BSN is not null and seq = 0 then 
		open c1_cd_role__dsc_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c1_cd_role__dsc_bsn into dummy;
		found := c1_cd_role__dsc_bsn%FOUND;
		close c1_cd_role__dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de modifier un enfant dans "BSN.CD_ROLE__DSC_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_ROLE_BSN" doit exister à la création d'un enfant dans "BSN.CD_ROLE__DSC_BSN"
	if :new.CD_ROLE_BSN__ROLE is not null and seq = 0 then 
		open c2_cd_role__dsc_bsn ( :new.CD_ROLE_BSN__ROLE);
		fetch c2_cd_role__dsc_bsn into dummy;
		found := c2_cd_role__dsc_bsn%FOUND;
		close c2_cd_role__dsc_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ROLE_BSN". Impossible de modifier un enfant dans "BSN.CD_ROLE__DSC_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TIB_ENTETEBSN" before insert
on BSN.ENTETE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_ENTETE_BSN"
	cursor c1_entete_bsn(Vcd_entete_bsn__id_entete number) is
		select 1 
		from BSN.CD_ENTETE_BSN 
		where 
		ID_ENTETE = Vcd_entete_bsn__id_entete and Vcd_entete_bsn__id_entete is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.VST_BSN"
	cursor c2_entete_bsn(Vcamp_bsn__id_camp varchar,
	Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.VST_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_BSN__NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	
	--  Le parent "BSN.CD_ENTETE_BSN" doit exister à la création d'un enfant dans "BSN.ENTETE_BSN"
	if :new.CD_ENTETE_BSN__ID_ENTETE is not null then 
		open c1_entete_bsn ( :new.CD_ENTETE_BSN__ID_ENTETE);
		fetch c1_entete_bsn into dummy;
		found := c1_entete_bsn%FOUND;
		close c1_entete_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ENTETE_BSN". Impossible de créer un enfant dans "BSN.ENTETE_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.VST_BSN" doit exister à la création d'un enfant dans "BSN.ENTETE_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and 
	:new.DSC_BSN__NUM_BSN is not null then 
		open c2_entete_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_BSN__NUM_BSN);
		fetch c2_entete_bsn into dummy;
		found := c2_entete_bsn%FOUND;
		close c2_entete_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.VST_BSN". Impossible de créer un enfant dans "BSN.ENTETE_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_ENTETEBSN" before update
on BSN.ENTETE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_ENTETE_BSN"
	cursor c1_entete_bsn (Vcd_entete_bsn__id_entete number) is
		select 1 
		from BSN.CD_ENTETE_BSN 
		where 
		ID_ENTETE = Vcd_entete_bsn__id_entete and Vcd_entete_bsn__id_entete is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.VST_BSN"
	cursor c2_entete_bsn (Vcamp_bsn__id_camp varchar,
	Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.VST_BSN 
		where 
		CAMP_BSN__ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null and 
		DSC_BSN__NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.CD_ENTETE_BSN" doit exister à la création d'un enfant dans "BSN.ENTETE_BSN"
	if :new.CD_ENTETE_BSN__ID_ENTETE is not null and seq = 0 then 
		open c1_entete_bsn ( :new.CD_ENTETE_BSN__ID_ENTETE);
		fetch c1_entete_bsn into dummy;
		found := c1_entete_bsn%FOUND;
		close c1_entete_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ENTETE_BSN". Impossible de modifier un enfant dans "BSN.ENTETE_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.VST_BSN" doit exister à la création d'un enfant dans "BSN.ENTETE_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and seq = 0 and 
	:new.DSC_BSN__NUM_BSN is not null and seq = 0 then 
		open c2_entete_bsn ( :new.CAMP_BSN__ID_CAMP,
		:new.DSC_BSN__NUM_BSN);
		fetch c2_entete_bsn into dummy;
		found := c2_entete_bsn%FOUND;
		close c2_entete_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.VST_BSN". Impossible de modifier un enfant dans "BSN.ENTETE_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_CDTYPEBSN" after update
of TYPE
on BSN.CD_TYPE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_TYPE_BSN" dans les enfants "BSN.DSC_BSN"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update BSN.DSC_BSN
		set CD_TYPE_BSN__TYPE = :new.TYPE  
		where CD_TYPE_BSN__TYPE = :old.TYPE;
	end if;
	--  Modification du code du parent "BSN.CD_TYPE_BSN" dans les enfants "BSN.DSC_TEMP_BSN"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update BSN.DSC_TEMP_BSN
		set CD_TYPE_BSN__TYPE = :new.TYPE  
		where CD_TYPE_BSN__TYPE = :old.TYPE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDTYPEBSN" after delete
on BSN.CD_TYPE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.DSC_BSN"
	delete BSN.DSC_BSN
	where CD_TYPE_BSN__TYPE = :old.TYPE;
	
	--  Suppression des enfants dans "BSN.DSC_TEMP_BSN"
	delete BSN.DSC_TEMP_BSN
	where CD_TYPE_BSN__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_SEUILQUALITEBSN" before insert
on BSN.SEUIL_QUALITE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_QUALITE_BSN"
	cursor c1_seuil_qualite_bsn(Vcd_qualite_bsn__qualite varchar) is
		select 1 
		from BSN.CD_QUALITE_BSN 
		where 
		QUALITE = Vcd_qualite_bsn__qualite and Vcd_qualite_bsn__qualite is not null;
begin

	
	--  Le parent "BSN.CD_QUALITE_BSN" doit exister à la création d'un enfant dans "BSN.SEUIL_QUALITE_BSN"
	if :new.CD_QUALITE_BSN__QUALITE is not null then 
		open c1_seuil_qualite_bsn ( :new.CD_QUALITE_BSN__QUALITE);
		fetch c1_seuil_qualite_bsn into dummy;
		found := c1_seuil_qualite_bsn%FOUND;
		close c1_seuil_qualite_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_QUALITE_BSN". Impossible de créer un enfant dans "BSN.SEUIL_QUALITE_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_SEUILQUALITEBSN" before update
on BSN.SEUIL_QUALITE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_QUALITE_BSN"
	cursor c1_seuil_qualite_bsn (Vcd_qualite_bsn__qualite varchar) is
		select 1 
		from BSN.CD_QUALITE_BSN 
		where 
		QUALITE = Vcd_qualite_bsn__qualite and Vcd_qualite_bsn__qualite is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.CD_QUALITE_BSN" doit exister à la création d'un enfant dans "BSN.SEUIL_QUALITE_BSN"
	if :new.CD_QUALITE_BSN__QUALITE is not null and seq = 0 then 
		open c1_seuil_qualite_bsn ( :new.CD_QUALITE_BSN__QUALITE);
		fetch c1_seuil_qualite_bsn into dummy;
		found := c1_seuil_qualite_bsn%FOUND;
		close c1_seuil_qualite_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_QUALITE_BSN". Impossible de modifier un enfant dans "BSN.SEUIL_QUALITE_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TIB_SPRTBSN" before insert
on BSN.SPRT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.PRT_BSN"
	cursor c1_sprt_bsn(Vgrp_bsn__id_grp number,
	Vprt_bsn__id_prt number) is
		select 1 
		from BSN.PRT_BSN 
		where 
		GRP_BSN__ID_GRP = Vgrp_bsn__id_grp and Vgrp_bsn__id_grp is not null and 
		ID_PRT = Vprt_bsn__id_prt and Vprt_bsn__id_prt is not null;
begin

	
	--  Le parent "BSN.PRT_BSN" doit exister à la création d'un enfant dans "BSN.SPRT_BSN"
	if :new.GRP_BSN__ID_GRP is not null and 
	:new.PRT_BSN__ID_PRT is not null then 
		open c1_sprt_bsn ( :new.GRP_BSN__ID_GRP,
		:new.PRT_BSN__ID_PRT);
		fetch c1_sprt_bsn into dummy;
		found := c1_sprt_bsn%FOUND;
		close c1_sprt_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.PRT_BSN". Impossible de créer un enfant dans "BSN.SPRT_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_SPRTBSN" before update
on BSN.SPRT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.PRT_BSN"
	cursor c1_sprt_bsn (Vgrp_bsn__id_grp number,
	Vprt_bsn__id_prt number) is
		select 1 
		from BSN.PRT_BSN 
		where 
		GRP_BSN__ID_GRP = Vgrp_bsn__id_grp and Vgrp_bsn__id_grp is not null and 
		ID_PRT = Vprt_bsn__id_prt and Vprt_bsn__id_prt is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.PRT_BSN" doit exister à la création d'un enfant dans "BSN.SPRT_BSN"
	if :new.GRP_BSN__ID_GRP is not null and seq = 0 and 
	:new.PRT_BSN__ID_PRT is not null and seq = 0 then 
		open c1_sprt_bsn ( :new.GRP_BSN__ID_GRP,
		:new.PRT_BSN__ID_PRT);
		fetch c1_sprt_bsn into dummy;
		found := c1_sprt_bsn%FOUND;
		close c1_sprt_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.PRT_BSN". Impossible de modifier un enfant dans "BSN.SPRT_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_SPRTBSN" after update
of GRP_BSN__ID_GRP,PRT_BSN__ID_PRT,ID_SPRT
on BSN.SPRT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.SPRT_BSN" dans les enfants "BSN.ELT_BSN"
	if ((updating('GRP_BSN__ID_GRP') and :old.GRP_BSN__ID_GRP != :new.GRP_BSN__ID_GRP) or 
	(updating('PRT_BSN__ID_PRT') and :old.PRT_BSN__ID_PRT != :new.PRT_BSN__ID_PRT) or 
	(updating('ID_SPRT') and :old.ID_SPRT != :new.ID_SPRT)) then 
		update BSN.ELT_BSN
		set GRP_BSN__ID_GRP = :new.GRP_BSN__ID_GRP,
		PRT_BSN__ID_PRT = :new.PRT_BSN__ID_PRT,
		SPRT_BSN__ID_SPRT = :new.ID_SPRT  
		where GRP_BSN__ID_GRP = :old.GRP_BSN__ID_GRP and 
		PRT_BSN__ID_PRT = :old.PRT_BSN__ID_PRT and 
		SPRT_BSN__ID_SPRT = :old.ID_SPRT;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_SPRTBSN" after delete
on BSN.SPRT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.ELT_BSN"
	delete BSN.ELT_BSN
	where GRP_BSN__ID_GRP = :old.GRP_BSN__ID_GRP and 
	PRT_BSN__ID_PRT = :old.PRT_BSN__ID_PRT and 
	SPRT_BSN__ID_SPRT = :old.ID_SPRT;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_TRAVAUXBSN" before insert
on BSN.TRAVAUX_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c1_travaux_bsn(Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.NATURE_TRAV_BSN"
	cursor c2_travaux_bsn(Vcd_travaux_bsn__code varchar,
	Vnature_trav_bsn__nature varchar) is
		select 1 
		from BSN.NATURE_TRAV_BSN 
		where 
		CD_TRAVAUX_BSN__CODE = Vcd_travaux_bsn__code and Vcd_travaux_bsn__code is not null and 
		NATURE = Vnature_trav_bsn__nature and Vnature_trav_bsn__nature is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_ENTP_BSN"
	cursor c3_travaux_bsn(Vcd_entp_bsn__entreprise varchar) is
		select 1 
		from BSN.CD_ENTP_BSN 
		where 
		ENTREPRISE = Vcd_entp_bsn__entreprise and Vcd_entp_bsn__entreprise is not null;
begin

	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.TRAVAUX_BSN"
	if :new.DSC_BSN__NUM_BSN is not null then 
		open c1_travaux_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c1_travaux_bsn into dummy;
		found := c1_travaux_bsn%FOUND;
		close c1_travaux_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de créer un enfant dans "BSN.TRAVAUX_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.NATURE_TRAV_BSN" doit exister à la création d'un enfant dans "BSN.TRAVAUX_BSN"
	if :new.CD_TRAVAUX_BSN__CODE is not null and 
	:new.NATURE_TRAV_BSN__NATURE is not null then 
		open c2_travaux_bsn ( :new.CD_TRAVAUX_BSN__CODE,
		:new.NATURE_TRAV_BSN__NATURE);
		fetch c2_travaux_bsn into dummy;
		found := c2_travaux_bsn%FOUND;
		close c2_travaux_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.NATURE_TRAV_BSN". Impossible de créer un enfant dans "BSN.TRAVAUX_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_ENTP_BSN" doit exister à la création d'un enfant dans "BSN.TRAVAUX_BSN"
	if :new.CD_ENTP_BSN__ENTREPRISE is not null then 
		open c3_travaux_bsn ( :new.CD_ENTP_BSN__ENTREPRISE);
		fetch c3_travaux_bsn into dummy;
		found := c3_travaux_bsn%FOUND;
		close c3_travaux_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ENTP_BSN". Impossible de créer un enfant dans "BSN.TRAVAUX_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_TRAVAUXBSN" before update
on BSN.TRAVAUX_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c1_travaux_bsn (Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.NATURE_TRAV_BSN"
	cursor c2_travaux_bsn (Vcd_travaux_bsn__code varchar,
	Vnature_trav_bsn__nature varchar) is
		select 1 
		from BSN.NATURE_TRAV_BSN 
		where 
		CD_TRAVAUX_BSN__CODE = Vcd_travaux_bsn__code and Vcd_travaux_bsn__code is not null and 
		NATURE = Vnature_trav_bsn__nature and Vnature_trav_bsn__nature is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_ENTP_BSN"
	cursor c3_travaux_bsn (Vcd_entp_bsn__entreprise varchar) is
		select 1 
		from BSN.CD_ENTP_BSN 
		where 
		ENTREPRISE = Vcd_entp_bsn__entreprise and Vcd_entp_bsn__entreprise is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.TRAVAUX_BSN"
	if :new.DSC_BSN__NUM_BSN is not null and seq = 0 then 
		open c1_travaux_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c1_travaux_bsn into dummy;
		found := c1_travaux_bsn%FOUND;
		close c1_travaux_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de modifier un enfant dans "BSN.TRAVAUX_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.NATURE_TRAV_BSN" doit exister à la création d'un enfant dans "BSN.TRAVAUX_BSN"
	if :new.CD_TRAVAUX_BSN__CODE is not null and seq = 0 and 
	:new.NATURE_TRAV_BSN__NATURE is not null and seq = 0 then 
		open c2_travaux_bsn ( :new.CD_TRAVAUX_BSN__CODE,
		:new.NATURE_TRAV_BSN__NATURE);
		fetch c2_travaux_bsn into dummy;
		found := c2_travaux_bsn%FOUND;
		close c2_travaux_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.NATURE_TRAV_BSN". Impossible de modifier un enfant dans "BSN.TRAVAUX_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.CD_ENTP_BSN" doit exister à la création d'un enfant dans "BSN.TRAVAUX_BSN"
	if :new.CD_ENTP_BSN__ENTREPRISE is not null and seq = 0 then 
		open c3_travaux_bsn ( :new.CD_ENTP_BSN__ENTREPRISE);
		fetch c3_travaux_bsn into dummy;
		found := c3_travaux_bsn%FOUND;
		close c3_travaux_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_ENTP_BSN". Impossible de modifier un enfant dans "BSN.TRAVAUX_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_CDACCESBSN" after update
of VACCES
on BSN.CD_ACCES_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_ACCES_BSN" dans les enfants "BSN.DSC_BSN"
	if ((updating('VACCES') and :old.VACCES != :new.VACCES)) then 
		update BSN.DSC_BSN
		set CD_ACCES_BSN__VACCES = :new.VACCES  
		where CD_ACCES_BSN__VACCES = :old.VACCES;
	end if;
	--  Modification du code du parent "BSN.CD_ACCES_BSN" dans les enfants "BSN.DSC_TEMP_BSN"
	if ((updating('VACCES') and :old.VACCES != :new.VACCES)) then 
		update BSN.DSC_TEMP_BSN
		set CD_ACCES_BSN__VACCES = :new.VACCES  
		where CD_ACCES_BSN__VACCES = :old.VACCES;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDACCESBSN" after delete
on BSN.CD_ACCES_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.DSC_BSN"
	delete BSN.DSC_BSN
	where CD_ACCES_BSN__VACCES = :old.VACCES;
	
	--  Suppression des enfants dans "BSN.DSC_TEMP_BSN"
	delete BSN.DSC_TEMP_BSN
	where CD_ACCES_BSN__VACCES = :old.VACCES;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TUA_CDCOMPOSANTBSN" after update
of TYPE_COMP
on BSN.CD_COMPOSANT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_COMPOSANT_BSN" dans les enfants "BSN.CD_ENTETE_BSN"
	if ((updating('TYPE_COMP') and :old.TYPE_COMP != :new.TYPE_COMP)) then 
		update BSN.CD_ENTETE_BSN
		set CD_COMPOSANT_BSN__TYPE_COMP = :new.TYPE_COMP  
		where CD_COMPOSANT_BSN__TYPE_COMP = :old.TYPE_COMP;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDCOMPOSANTBSN" after delete
on BSN.CD_COMPOSANT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.CD_ENTETE_BSN"
	delete BSN.CD_ENTETE_BSN
	where CD_COMPOSANT_BSN__TYPE_COMP = :old.TYPE_COMP;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TUA_CDDOCBSN" after update
of CODE
on BSN.CD_DOC_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_DOC_BSN" dans les enfants "BSN.DOC_BSN"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update BSN.DOC_BSN
		set CD_DOC__CODE = :new.CODE  
		where CD_DOC__CODE = :old.CODE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDDOCBSN" after delete
on BSN.CD_DOC_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.DOC_BSN"
	delete BSN.DOC_BSN
	where CD_DOC__CODE = :old.CODE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TUA_CDEVTBSN" after update
of TYPE
on BSN.CD_EVT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_EVT_BSN" dans les enfants "BSN.EVT_BSN"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update BSN.EVT_BSN
		set CD_EVT_BSN__TYPE = :new.TYPE  
		where CD_EVT_BSN__TYPE = :old.TYPE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDEVTBSN" after delete
on BSN.CD_EVT_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.EVT_BSN"
	delete BSN.EVT_BSN
	where CD_EVT_BSN__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_CDTYPEQPBSN" before insert
on BSN.CD_TYPEQP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CD_FAMEQP_BSN"
	cursor c1_cd_typeqp_bsn(Vcd_fameqp_bsn__fam varchar) is
		select 1 
		from BSN.CD_FAMEQP_BSN 
		where 
		FAM = Vcd_fameqp_bsn__fam and Vcd_fameqp_bsn__fam is not null;
begin

	
	--  Le parent "BSN.CD_FAMEQP_BSN" doit exister à la création d'un enfant dans "BSN.CD_TYPEQP_BSN"
	if :new.CD_FAMEQP_BSN__FAM is not null then 
		open c1_cd_typeqp_bsn ( :new.CD_FAMEQP_BSN__FAM);
		fetch c1_cd_typeqp_bsn into dummy;
		found := c1_cd_typeqp_bsn%FOUND;
		close c1_cd_typeqp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_FAMEQP_BSN". Impossible de créer un enfant dans "BSN.CD_TYPEQP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_CDTYPEQPBSN" before update
on BSN.CD_TYPEQP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CD_FAMEQP_BSN"
	cursor c1_cd_typeqp_bsn (Vcd_fameqp_bsn__fam varchar) is
		select 1 
		from BSN.CD_FAMEQP_BSN 
		where 
		FAM = Vcd_fameqp_bsn__fam and Vcd_fameqp_bsn__fam is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.CD_FAMEQP_BSN" doit exister à la création d'un enfant dans "BSN.CD_TYPEQP_BSN"
	if :new.CD_FAMEQP_BSN__FAM is not null and seq = 0 then 
		open c1_cd_typeqp_bsn ( :new.CD_FAMEQP_BSN__FAM);
		fetch c1_cd_typeqp_bsn into dummy;
		found := c1_cd_typeqp_bsn%FOUND;
		close c1_cd_typeqp_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CD_FAMEQP_BSN". Impossible de modifier un enfant dans "BSN.CD_TYPEQP_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_CDTYPEQPBSN" after update
of CD_FAMEQP_BSN__FAM,TYPE
on BSN.CD_TYPEQP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_TYPEQP_BSN" dans les enfants "BSN.EQUIPEMENT_BSN"
	if ((updating('CD_FAMEQP_BSN__FAM') and :old.CD_FAMEQP_BSN__FAM != :new.CD_FAMEQP_BSN__FAM) or 
	(updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update BSN.EQUIPEMENT_BSN
		set CD_FAMEQP_BSN__FAM = :new.CD_FAMEQP_BSN__FAM,
		CD_TYPEQP_BSN__TYPE = :new.TYPE  
		where CD_FAMEQP_BSN__FAM = :old.CD_FAMEQP_BSN__FAM and 
		CD_TYPEQP_BSN__TYPE = :old.TYPE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDTYPEQPBSN" after delete
on BSN.CD_TYPEQP_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.EQUIPEMENT_BSN"
	delete BSN.EQUIPEMENT_BSN
	where CD_FAMEQP_BSN__FAM = :old.CD_FAMEQP_BSN__FAM and 
	CD_TYPEQP_BSN__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TUA_CDTYPEPVBSN" after update
of CODE
on BSN.CD_TYPE_PV_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_TYPE_PV_BSN" dans les enfants "BSN.CAMP_BSN"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update BSN.CAMP_BSN
		set CD_TYPE_PV_BSN__CODE = :new.CODE  
		where CD_TYPE_PV_BSN__CODE = :old.CODE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDTYPEPVBSN" after delete
on BSN.CD_TYPE_PV_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.CAMP_BSN"
	delete BSN.CAMP_BSN
	where CD_TYPE_PV_BSN__CODE = :old.CODE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TUA_CDTRAVAUXBSN" after update
of CODE
on BSN.CD_TRAVAUX_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_TRAVAUX_BSN" dans les enfants "BSN.NATURE_TRAV_BSN"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update BSN.NATURE_TRAV_BSN
		set CD_TRAVAUX_BSN__CODE = :new.CODE  
		where CD_TRAVAUX_BSN__CODE = :old.CODE;
	end if;
	--  Modification du code du parent "BSN.CD_TRAVAUX_BSN" dans les enfants "BSN.BPU_BSN"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update BSN.BPU_BSN
		set CD_TRAVAUX_BSN__CODE = :new.CODE  
		where CD_TRAVAUX_BSN__CODE = :old.CODE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDTRAVAUXBSN" after delete
on BSN.CD_TRAVAUX_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.NATURE_TRAV_BSN"
	delete BSN.NATURE_TRAV_BSN
	where CD_TRAVAUX_BSN__CODE = :old.CODE;
	
	--  Suppression des enfants dans "BSN.BPU_BSN"
	delete BSN.BPU_BSN
	where CD_TRAVAUX_BSN__CODE = :old.CODE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TUA_CDUNITEBSN" after update
of UNITE
on BSN.CD_UNITE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.CD_UNITE_BSN" dans les enfants "BSN.BPU_BSN"
	if ((updating('UNITE') and :old.UNITE != :new.UNITE)) then 
		update BSN.BPU_BSN
		set CD_UNITE_BSN__UNITE = :new.UNITE  
		where CD_UNITE_BSN__UNITE = :old.UNITE;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_CDUNITEBSN" after delete
on BSN.CD_UNITE_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.BPU_BSN"
	delete BSN.BPU_BSN
	where CD_UNITE_BSN__UNITE = :old.UNITE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TIB_VSTBSN" before insert
on BSN.VST_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.CAMP_BSN"
	cursor c1_vst_bsn(Vcamp_bsn__id_camp varchar) is
		select 1 
		from BSN.CAMP_BSN 
		where 
		ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c2_vst_bsn(Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "BSN.INSPECTEUR_BSN"
	cursor c3_vst_bsn(Vinspecteur_bsn__nom varchar) is
		select 1 
		from BSN.INSPECTEUR_BSN 
		where 
		NOM = Vinspecteur_bsn__nom and Vinspecteur_bsn__nom is not null;
begin

	
	--  Le parent "BSN.CAMP_BSN" doit exister à la création d'un enfant dans "BSN.VST_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null then 
		open c1_vst_bsn ( :new.CAMP_BSN__ID_CAMP);
		fetch c1_vst_bsn into dummy;
		found := c1_vst_bsn%FOUND;
		close c1_vst_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CAMP_BSN". Impossible de créer un enfant dans "BSN.VST_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.VST_BSN"
	if :new.DSC_BSN__NUM_BSN is not null then 
		open c2_vst_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c2_vst_bsn into dummy;
		found := c2_vst_bsn%FOUND;
		close c2_vst_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de créer un enfant dans "BSN.VST_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.INSPECTEUR_BSN" doit exister à la création d'un enfant dans "BSN.VST_BSN"
	if :new.INSPECTEUR_BSN__NOM is not null then 
		open c3_vst_bsn ( :new.INSPECTEUR_BSN__NOM);
		fetch c3_vst_bsn into dummy;
		found := c3_vst_bsn%FOUND;
		close c3_vst_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.INSPECTEUR_BSN". Impossible de créer un enfant dans "BSN.VST_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUB_VSTBSN" before update
on BSN.VST_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.CAMP_BSN"
	cursor c1_vst_bsn (Vcamp_bsn__id_camp varchar) is
		select 1 
		from BSN.CAMP_BSN 
		where 
		ID_CAMP = Vcamp_bsn__id_camp and Vcamp_bsn__id_camp is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.DSC_BSN"
	cursor c2_vst_bsn (Vdsc_bsn__num_bsn varchar) is
		select 1 
		from BSN.DSC_BSN 
		where 
		NUM_BSN = Vdsc_bsn__num_bsn and Vdsc_bsn__num_bsn is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "BSN.INSPECTEUR_BSN"
	cursor c3_vst_bsn (Vinspecteur_bsn__nom varchar) is
		select 1 
		from BSN.INSPECTEUR_BSN 
		where 
		NOM = Vinspecteur_bsn__nom and Vinspecteur_bsn__nom is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "BSN.CAMP_BSN" doit exister à la création d'un enfant dans "BSN.VST_BSN"
	if :new.CAMP_BSN__ID_CAMP is not null and seq = 0 then 
		open c1_vst_bsn ( :new.CAMP_BSN__ID_CAMP);
		fetch c1_vst_bsn into dummy;
		found := c1_vst_bsn%FOUND;
		close c1_vst_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.CAMP_BSN". Impossible de modifier un enfant dans "BSN.VST_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.DSC_BSN" doit exister à la création d'un enfant dans "BSN.VST_BSN"
	if :new.DSC_BSN__NUM_BSN is not null and seq = 0 then 
		open c2_vst_bsn ( :new.DSC_BSN__NUM_BSN);
		fetch c2_vst_bsn into dummy;
		found := c2_vst_bsn%FOUND;
		close c2_vst_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.DSC_BSN". Impossible de modifier un enfant dans "BSN.VST_BSN".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "BSN.INSPECTEUR_BSN" doit exister à la création d'un enfant dans "BSN.VST_BSN"
	if :new.INSPECTEUR_BSN__NOM is not null and seq = 0 then 
		open c3_vst_bsn ( :new.INSPECTEUR_BSN__NOM);
		fetch c3_vst_bsn into dummy;
		found := c3_vst_bsn%FOUND;
		close c3_vst_bsn;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "BSN.INSPECTEUR_BSN". Impossible de modifier un enfant dans "BSN.VST_BSN".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "BSN"."TUA_VSTBSN" after update
of CAMP_BSN__ID_CAMP,DSC_BSN__NUM_BSN
on BSN.VST_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "BSN.VST_BSN" dans les enfants "BSN.SPRT_VST_BSN"
	if ((updating('CAMP_BSN__ID_CAMP') and :old.CAMP_BSN__ID_CAMP != :new.CAMP_BSN__ID_CAMP) or 
	(updating('DSC_BSN__NUM_BSN') and :old.DSC_BSN__NUM_BSN != :new.DSC_BSN__NUM_BSN)) then 
		update BSN.SPRT_VST_BSN
		set CAMP_BSN__ID_CAMP = :new.CAMP_BSN__ID_CAMP,
		DSC_BSN__NUM_BSN = :new.DSC_BSN__NUM_BSN  
		where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
		DSC_BSN__NUM_BSN = :old.DSC_BSN__NUM_BSN;
	end if;
	--  Modification du code du parent "BSN.VST_BSN" dans les enfants "BSN.PHOTO_VST_BSN"
	if ((updating('CAMP_BSN__ID_CAMP') and :old.CAMP_BSN__ID_CAMP != :new.CAMP_BSN__ID_CAMP) or 
	(updating('DSC_BSN__NUM_BSN') and :old.DSC_BSN__NUM_BSN != :new.DSC_BSN__NUM_BSN)) then 
		update BSN.PHOTO_VST_BSN
		set CAMP_BSN__ID_CAMP = :new.CAMP_BSN__ID_CAMP,
		DSC_BSN__NUM_BSN = :new.DSC_BSN__NUM_BSN  
		where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
		DSC_BSN__NUM_BSN = :old.DSC_BSN__NUM_BSN;
	end if;
	--  Modification du code du parent "BSN.VST_BSN" dans les enfants "BSN.ENTETE_BSN"
	if ((updating('CAMP_BSN__ID_CAMP') and :old.CAMP_BSN__ID_CAMP != :new.CAMP_BSN__ID_CAMP) or 
	(updating('DSC_BSN__NUM_BSN') and :old.DSC_BSN__NUM_BSN != :new.DSC_BSN__NUM_BSN)) then 
		update BSN.ENTETE_BSN
		set CAMP_BSN__ID_CAMP = :new.CAMP_BSN__ID_CAMP,
		DSC_BSN__NUM_BSN = :new.DSC_BSN__NUM_BSN  
		where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
		DSC_BSN__NUM_BSN = :old.DSC_BSN__NUM_BSN;
	end if;
	IntegrityPackage.PreviousNestLevel;
--  Traitement d'erreurs
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "BSN"."TDA_VSTBSN" after delete
on BSN.VST_BSN for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "BSN.SPRT_VST_BSN"
	delete BSN.SPRT_VST_BSN
	where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
	DSC_BSN__NUM_BSN = :old.DSC_BSN__NUM_BSN;
	
	--  Suppression des enfants dans "BSN.PHOTO_VST_BSN"
	delete BSN.PHOTO_VST_BSN
	where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
	DSC_BSN__NUM_BSN = :old.DSC_BSN__NUM_BSN;
	
	--  Suppression des enfants dans "BSN.ENTETE_BSN"
	delete BSN.ENTETE_BSN
	where CAMP_BSN__ID_CAMP = :old.CAMP_BSN__ID_CAMP and 
	DSC_BSN__NUM_BSN = :old.DSC_BSN__NUM_BSN;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


