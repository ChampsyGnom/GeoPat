/*################################################################################################*/
/* Script     : OH_Triggers.sql                                                                   */
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


create or replace TRIGGER "OH"."TIB_BPUOH" before insert
on OH.BPU_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_TRAVAUX_OH"
	cursor c1_bpu_oh(Vcd_travaux_oh__code varchar) is
		select 1 
		from OH.CD_TRAVAUX_OH 
		where 
		CODE = Vcd_travaux_oh__code and Vcd_travaux_oh__code is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_UNITE_OH"
	cursor c2_bpu_oh(Vcd_unite_oh__unite varchar) is
		select 1 
		from OH.CD_UNITE_OH 
		where 
		UNITE = Vcd_unite_oh__unite and Vcd_unite_oh__unite is not null;
begin

	
	--  Le parent "OH.CD_TRAVAUX_OH" doit exister à la création d'un enfant dans "OH.BPU_OH"
	if :new.CD_TRAVAUX_OH__CODE is not null then 
		open c1_bpu_oh ( :new.CD_TRAVAUX_OH__CODE);
		fetch c1_bpu_oh into dummy;
		found := c1_bpu_oh%FOUND;
		close c1_bpu_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_TRAVAUX_OH". Impossible de créer un enfant dans "OH.BPU_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_UNITE_OH" doit exister à la création d'un enfant dans "OH.BPU_OH"
	if :new.CD_UNITE_OH__UNITE is not null then 
		open c2_bpu_oh ( :new.CD_UNITE_OH__UNITE);
		fetch c2_bpu_oh into dummy;
		found := c2_bpu_oh%FOUND;
		close c2_bpu_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_UNITE_OH". Impossible de créer un enfant dans "OH.BPU_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_BPUOH" before update
on OH.BPU_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_TRAVAUX_OH"
	cursor c1_bpu_oh (Vcd_travaux_oh__code varchar) is
		select 1 
		from OH.CD_TRAVAUX_OH 
		where 
		CODE = Vcd_travaux_oh__code and Vcd_travaux_oh__code is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_UNITE_OH"
	cursor c2_bpu_oh (Vcd_unite_oh__unite varchar) is
		select 1 
		from OH.CD_UNITE_OH 
		where 
		UNITE = Vcd_unite_oh__unite and Vcd_unite_oh__unite is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.CD_TRAVAUX_OH" doit exister à la création d'un enfant dans "OH.BPU_OH"
	if :new.CD_TRAVAUX_OH__CODE is not null and seq = 0 then 
		open c1_bpu_oh ( :new.CD_TRAVAUX_OH__CODE);
		fetch c1_bpu_oh into dummy;
		found := c1_bpu_oh%FOUND;
		close c1_bpu_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_TRAVAUX_OH". Impossible de modifier un enfant dans "OH.BPU_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_UNITE_OH" doit exister à la création d'un enfant dans "OH.BPU_OH"
	if :new.CD_UNITE_OH__UNITE is not null and seq = 0 then 
		open c2_bpu_oh ( :new.CD_UNITE_OH__UNITE);
		fetch c2_bpu_oh into dummy;
		found := c2_bpu_oh%FOUND;
		close c2_bpu_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_UNITE_OH". Impossible de modifier un enfant dans "OH.BPU_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_BPUOH" after update
of ID_BPU
on OH.BPU_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.BPU_OH" dans les enfants "OH.PREVISION_OH"
	if ((updating('ID_BPU') and :old.ID_BPU != :new.ID_BPU)) then 
		update OH.PREVISION_OH
		set BPU_OH__ID_BPU = :new.ID_BPU  
		where BPU_OH__ID_BPU = :old.ID_BPU;
	end if;
	--  Modification du code du parent "OH.BPU_OH" dans les enfants "OH.CD_PRECO__SPRT_VST_OH"
	if ((updating('ID_BPU') and :old.ID_BPU != :new.ID_BPU)) then 
		update OH.CD_PRECO__SPRT_VST_OH
		set BPU_OH__ID_BPU = :new.ID_BPU  
		where BPU_OH__ID_BPU = :old.ID_BPU;
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


create or replace TRIGGER "OH"."TDA_BPUOH" after delete
on OH.BPU_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.PREVISION_OH"
	delete OH.PREVISION_OH
	where BPU_OH__ID_BPU = :old.ID_BPU;
	
	--  Suppression des enfants dans "OH.CD_PRECO__SPRT_VST_OH"
	delete OH.CD_PRECO__SPRT_VST_OH
	where BPU_OH__ID_BPU = :old.ID_BPU;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_CAMPOH" before insert
on OH.CAMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_PRESTA_OH"
	cursor c1_camp_oh(Vcd_presta_oh__prestataire varchar) is
		select 1 
		from OH.CD_PRESTA_OH 
		where 
		PRESTATAIRE = Vcd_presta_oh__prestataire and Vcd_presta_oh__prestataire is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_TYPE_PV_OH"
	cursor c2_camp_oh(Vcd_type_pv_oh__code varchar) is
		select 1 
		from OH.CD_TYPE_PV_OH 
		where 
		CODE = Vcd_type_pv_oh__code and Vcd_type_pv_oh__code is not null;
begin

	
	--  Le parent "OH.CD_PRESTA_OH" doit exister à la création d'un enfant dans "OH.CAMP_OH"
	if :new.CD_PRESTA_OH__PRESTATAIRE is not null then 
		open c1_camp_oh ( :new.CD_PRESTA_OH__PRESTATAIRE);
		fetch c1_camp_oh into dummy;
		found := c1_camp_oh%FOUND;
		close c1_camp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_PRESTA_OH". Impossible de créer un enfant dans "OH.CAMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_TYPE_PV_OH" doit exister à la création d'un enfant dans "OH.CAMP_OH"
	if :new.CD_TYPE_PV_OH__CODE is not null then 
		open c2_camp_oh ( :new.CD_TYPE_PV_OH__CODE);
		fetch c2_camp_oh into dummy;
		found := c2_camp_oh%FOUND;
		close c2_camp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_TYPE_PV_OH". Impossible de créer un enfant dans "OH.CAMP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_CAMPOH" before update
on OH.CAMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_PRESTA_OH"
	cursor c1_camp_oh (Vcd_presta_oh__prestataire varchar) is
		select 1 
		from OH.CD_PRESTA_OH 
		where 
		PRESTATAIRE = Vcd_presta_oh__prestataire and Vcd_presta_oh__prestataire is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_TYPE_PV_OH"
	cursor c2_camp_oh (Vcd_type_pv_oh__code varchar) is
		select 1 
		from OH.CD_TYPE_PV_OH 
		where 
		CODE = Vcd_type_pv_oh__code and Vcd_type_pv_oh__code is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.CD_PRESTA_OH" doit exister à la création d'un enfant dans "OH.CAMP_OH"
	if :new.CD_PRESTA_OH__PRESTATAIRE is not null and seq = 0 then 
		open c1_camp_oh ( :new.CD_PRESTA_OH__PRESTATAIRE);
		fetch c1_camp_oh into dummy;
		found := c1_camp_oh%FOUND;
		close c1_camp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_PRESTA_OH". Impossible de modifier un enfant dans "OH.CAMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_TYPE_PV_OH" doit exister à la création d'un enfant dans "OH.CAMP_OH"
	if :new.CD_TYPE_PV_OH__CODE is not null and seq = 0 then 
		open c2_camp_oh ( :new.CD_TYPE_PV_OH__CODE);
		fetch c2_camp_oh into dummy;
		found := c2_camp_oh%FOUND;
		close c2_camp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_TYPE_PV_OH". Impossible de modifier un enfant dans "OH.CAMP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_CAMPOH" after update
of ID_CAMP
on OH.CAMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CAMP_OH" dans les enfants "OH.INSP_OH"
	if ((updating('ID_CAMP') and :old.ID_CAMP != :new.ID_CAMP)) then 
		update OH.INSP_OH
		set CAMP_OH__ID_CAMP = :new.ID_CAMP  
		where CAMP_OH__ID_CAMP = :old.ID_CAMP;
	end if;
	--  Modification du code du parent "OH.CAMP_OH" dans les enfants "OH.VST_OH"
	if ((updating('ID_CAMP') and :old.ID_CAMP != :new.ID_CAMP)) then 
		update OH.VST_OH
		set CAMP_OH__ID_CAMP = :new.ID_CAMP  
		where CAMP_OH__ID_CAMP = :old.ID_CAMP;
	end if;
	--  Modification du code du parent "OH.CAMP_OH" dans les enfants "OH.DSC_TEMP_OH"
	if ((updating('ID_CAMP') and :old.ID_CAMP != :new.ID_CAMP)) then 
		update OH.DSC_TEMP_OH
		set CAMP_OH__ID_CAMP = :new.ID_CAMP  
		where CAMP_OH__ID_CAMP = :old.ID_CAMP;
	end if;
	--  Modification du code du parent "OH.CAMP_OH" dans les enfants "OH.DSC_CAMP_OH"
	if ((updating('ID_CAMP') and :old.ID_CAMP != :new.ID_CAMP)) then 
		update OH.DSC_CAMP_OH
		set CAMP_OH__ID_CAMP = :new.ID_CAMP  
		where CAMP_OH__ID_CAMP = :old.ID_CAMP;
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


create or replace TRIGGER "OH"."TDA_CAMPOH" after delete
on OH.CAMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.INSP_OH"
	delete OH.INSP_OH
	where CAMP_OH__ID_CAMP = :old.ID_CAMP;
	
	--  Suppression des enfants dans "OH.VST_OH"
	delete OH.VST_OH
	where CAMP_OH__ID_CAMP = :old.ID_CAMP;
	
	--  Suppression des enfants dans "OH.DSC_TEMP_OH"
	delete OH.DSC_TEMP_OH
	where CAMP_OH__ID_CAMP = :old.ID_CAMP;
	
	--  Suppression des enfants dans "OH.DSC_CAMP_OH"
	delete OH.DSC_CAMP_OH
	where CAMP_OH__ID_CAMP = :old.ID_CAMP;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDCHAPITREOH" after update
of ID_CHAP
on OH.CD_CHAPITRE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_CHAPITRE_OH" dans les enfants "OH.CD_LIGNE_OH"
	if ((updating('ID_CHAP') and :old.ID_CHAP != :new.ID_CHAP)) then 
		update OH.CD_LIGNE_OH
		set CD_CHAPITRE_OH__ID_CHAP = :new.ID_CHAP  
		where CD_CHAPITRE_OH__ID_CHAP = :old.ID_CHAP;
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


create or replace TRIGGER "OH"."TDA_CDCHAPITREOH" after delete
on OH.CD_CHAPITRE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.CD_LIGNE_OH"
	delete OH.CD_LIGNE_OH
	where CD_CHAPITRE_OH__ID_CHAP = :old.ID_CHAP;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CLSOH" after update
of ID
on OH.CLS_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CLS_OH" dans les enfants "OH.CLS_DOC_OH"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update OH.CLS_DOC_OH
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


create or replace TRIGGER "OH"."TDA_CLSOH" after delete
on OH.CLS_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.CLS_DOC_OH"
	delete OH.CLS_DOC_OH
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


create or replace TRIGGER "OH"."TUA_CDCONCLUSIONOH" after update
of ID_CONC
on OH.CD_CONCLUSION_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_CONCLUSION_OH" dans les enfants "OH.CD_CONCLUSION__INSP_OH"
	if ((updating('ID_CONC') and :old.ID_CONC != :new.ID_CONC)) then 
		update OH.CD_CONCLUSION__INSP_OH
		set CD_CONCLUSION_OH__ID_CONC = :new.ID_CONC  
		where CD_CONCLUSION_OH__ID_CONC = :old.ID_CONC;
	end if;
	--  Modification du code du parent "OH.CD_CONCLUSION_OH" dans les enfants "OH.CD_CONCLUSION__INSP_TMP_OH"
	if ((updating('ID_CONC') and :old.ID_CONC != :new.ID_CONC)) then 
		update OH.CD_CONCLUSION__INSP_TMP_OH
		set CD_CONCLUSION_OH__ID_CONC = :new.ID_CONC  
		where CD_CONCLUSION_OH__ID_CONC = :old.ID_CONC;
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


create or replace TRIGGER "OH"."TDA_CDCONCLUSIONOH" after delete
on OH.CD_CONCLUSION_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.CD_CONCLUSION__INSP_OH"
	delete OH.CD_CONCLUSION__INSP_OH
	where CD_CONCLUSION_OH__ID_CONC = :old.ID_CONC;
	
	--  Suppression des enfants dans "OH.CD_CONCLUSION__INSP_TMP_OH"
	delete OH.CD_CONCLUSION__INSP_TMP_OH
	where CD_CONCLUSION_OH__ID_CONC = :old.ID_CONC;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDQUALITEOH" after update
of QUALITE
on OH.CD_QUALITE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_QUALITE_OH" dans les enfants "OH.SEUIL_QUALITE_OH"
	if ((updating('QUALITE') and :old.QUALITE != :new.QUALITE)) then 
		update OH.SEUIL_QUALITE_OH
		set CD_QUALITE_OH__QUALITE = :new.QUALITE  
		where CD_QUALITE_OH__QUALITE = :old.QUALITE;
	end if;
	--  Modification du code du parent "OH.CD_QUALITE_OH" dans les enfants "OH.DSC_OH"
	if ((updating('QUALITE') and :old.QUALITE != :new.QUALITE)) then 
		update OH.DSC_OH
		set CD_QUALITE_OH__QUALITE = :new.QUALITE  
		where CD_QUALITE_OH__QUALITE = :old.QUALITE;
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


create or replace TRIGGER "OH"."TDA_CDQUALITEOH" after delete
on OH.CD_QUALITE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.SEUIL_QUALITE_OH"
	delete OH.SEUIL_QUALITE_OH
	where CD_QUALITE_OH__QUALITE = :old.QUALITE;
	
	--  Suppression des enfants dans "OH.DSC_OH"
	delete OH.DSC_OH
	where CD_QUALITE_OH__QUALITE = :old.QUALITE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_CDCONCLUSIONINSPOH" before insert
on OH.CD_CONCLUSION__INSP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.INSP_OH"
	cursor c1_cd_conclusion__insp_oh(Vcamp_oh__id_camp varchar,
	Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.INSP_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_OH__NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_CONCLUSION_OH"
	cursor c2_cd_conclusion__insp_oh(Vcd_conclusion_oh__id_conc number) is
		select 1 
		from OH.CD_CONCLUSION_OH 
		where 
		ID_CONC = Vcd_conclusion_oh__id_conc and Vcd_conclusion_oh__id_conc is not null;
begin

	
	--  Le parent "OH.INSP_OH" doit exister à la création d'un enfant dans "OH.CD_CONCLUSION__INSP_OH"
	if :new.CAMP_OH__ID_CAMP is not null and 
	:new.DSC_OH__NUM_OH is not null then 
		open c1_cd_conclusion__insp_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_OH__NUM_OH);
		fetch c1_cd_conclusion__insp_oh into dummy;
		found := c1_cd_conclusion__insp_oh%FOUND;
		close c1_cd_conclusion__insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.INSP_OH". Impossible de créer un enfant dans "OH.CD_CONCLUSION__INSP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_CONCLUSION_OH" doit exister à la création d'un enfant dans "OH.CD_CONCLUSION__INSP_OH"
	if :new.CD_CONCLUSION_OH__ID_CONC is not null then 
		open c2_cd_conclusion__insp_oh ( :new.CD_CONCLUSION_OH__ID_CONC);
		fetch c2_cd_conclusion__insp_oh into dummy;
		found := c2_cd_conclusion__insp_oh%FOUND;
		close c2_cd_conclusion__insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_CONCLUSION_OH". Impossible de créer un enfant dans "OH.CD_CONCLUSION__INSP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_CDCONCLUSIONINSPOH" before update
on OH.CD_CONCLUSION__INSP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.INSP_OH"
	cursor c1_cd_conclusion__insp_oh (Vcamp_oh__id_camp varchar,
	Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.INSP_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_OH__NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_CONCLUSION_OH"
	cursor c2_cd_conclusion__insp_oh (Vcd_conclusion_oh__id_conc number) is
		select 1 
		from OH.CD_CONCLUSION_OH 
		where 
		ID_CONC = Vcd_conclusion_oh__id_conc and Vcd_conclusion_oh__id_conc is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.INSP_OH" doit exister à la création d'un enfant dans "OH.CD_CONCLUSION__INSP_OH"
	if :new.CAMP_OH__ID_CAMP is not null and seq = 0 and 
	:new.DSC_OH__NUM_OH is not null and seq = 0 then 
		open c1_cd_conclusion__insp_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_OH__NUM_OH);
		fetch c1_cd_conclusion__insp_oh into dummy;
		found := c1_cd_conclusion__insp_oh%FOUND;
		close c1_cd_conclusion__insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.INSP_OH". Impossible de modifier un enfant dans "OH.CD_CONCLUSION__INSP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_CONCLUSION_OH" doit exister à la création d'un enfant dans "OH.CD_CONCLUSION__INSP_OH"
	if :new.CD_CONCLUSION_OH__ID_CONC is not null and seq = 0 then 
		open c2_cd_conclusion__insp_oh ( :new.CD_CONCLUSION_OH__ID_CONC);
		fetch c2_cd_conclusion__insp_oh into dummy;
		found := c2_cd_conclusion__insp_oh%FOUND;
		close c2_cd_conclusion__insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_CONCLUSION_OH". Impossible de modifier un enfant dans "OH.CD_CONCLUSION__INSP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TIB_CDCONCLUSIONINSPTMPOH" before insert
on OH.CD_CONCLUSION__INSP_TMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_CONCLUSION_OH"
	cursor c1_cd_conclusion__insp_tmp_oh(Vcd_conclusion_oh__id_conc number) is
		select 1 
		from OH.CD_CONCLUSION_OH 
		where 
		ID_CONC = Vcd_conclusion_oh__id_conc and Vcd_conclusion_oh__id_conc is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.INSP_TMP_OH"
	cursor c2_cd_conclusion__insp_tmp_oh(Vcamp_oh__id_camp varchar,
	Vdsc_temp_oh__num_oh varchar) is
		select 1 
		from OH.INSP_TMP_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_TEMP_OH__NUM_OH = Vdsc_temp_oh__num_oh and Vdsc_temp_oh__num_oh is not null;
begin

	
	--  Le parent "OH.CD_CONCLUSION_OH" doit exister à la création d'un enfant dans "OH.CD_CONCLUSION__INSP_TMP_OH"
	if :new.CD_CONCLUSION_OH__ID_CONC is not null then 
		open c1_cd_conclusion__insp_tmp_oh ( :new.CD_CONCLUSION_OH__ID_CONC);
		fetch c1_cd_conclusion__insp_tmp_oh into dummy;
		found := c1_cd_conclusion__insp_tmp_oh%FOUND;
		close c1_cd_conclusion__insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_CONCLUSION_OH". Impossible de créer un enfant dans "OH.CD_CONCLUSION__INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.INSP_TMP_OH" doit exister à la création d'un enfant dans "OH.CD_CONCLUSION__INSP_TMP_OH"
	if :new.CAMP_OH__ID_CAMP is not null and 
	:new.DSC_TEMP_OH__NUM_OH is not null then 
		open c2_cd_conclusion__insp_tmp_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_TEMP_OH__NUM_OH);
		fetch c2_cd_conclusion__insp_tmp_oh into dummy;
		found := c2_cd_conclusion__insp_tmp_oh%FOUND;
		close c2_cd_conclusion__insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.INSP_TMP_OH". Impossible de créer un enfant dans "OH.CD_CONCLUSION__INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_CDCONCLUSIONINSPTMPOH" before update
on OH.CD_CONCLUSION__INSP_TMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_CONCLUSION_OH"
	cursor c1_cd_conclusion__insp_tmp_oh (Vcd_conclusion_oh__id_conc number) is
		select 1 
		from OH.CD_CONCLUSION_OH 
		where 
		ID_CONC = Vcd_conclusion_oh__id_conc and Vcd_conclusion_oh__id_conc is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.INSP_TMP_OH"
	cursor c2_cd_conclusion__insp_tmp_oh (Vcamp_oh__id_camp varchar,
	Vdsc_temp_oh__num_oh varchar) is
		select 1 
		from OH.INSP_TMP_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_TEMP_OH__NUM_OH = Vdsc_temp_oh__num_oh and Vdsc_temp_oh__num_oh is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.CD_CONCLUSION_OH" doit exister à la création d'un enfant dans "OH.CD_CONCLUSION__INSP_TMP_OH"
	if :new.CD_CONCLUSION_OH__ID_CONC is not null and seq = 0 then 
		open c1_cd_conclusion__insp_tmp_oh ( :new.CD_CONCLUSION_OH__ID_CONC);
		fetch c1_cd_conclusion__insp_tmp_oh into dummy;
		found := c1_cd_conclusion__insp_tmp_oh%FOUND;
		close c1_cd_conclusion__insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_CONCLUSION_OH". Impossible de modifier un enfant dans "OH.CD_CONCLUSION__INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.INSP_TMP_OH" doit exister à la création d'un enfant dans "OH.CD_CONCLUSION__INSP_TMP_OH"
	if :new.CAMP_OH__ID_CAMP is not null and seq = 0 and 
	:new.DSC_TEMP_OH__NUM_OH is not null and seq = 0 then 
		open c2_cd_conclusion__insp_tmp_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_TEMP_OH__NUM_OH);
		fetch c2_cd_conclusion__insp_tmp_oh into dummy;
		found := c2_cd_conclusion__insp_tmp_oh%FOUND;
		close c2_cd_conclusion__insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.INSP_TMP_OH". Impossible de modifier un enfant dans "OH.CD_CONCLUSION__INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TIB_CONTACTOH" before insert
on OH.CONTACT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.DOC_OH"
	cursor c1_contact_oh(Vdoc__id number) is
		select 1 
		from OH.DOC_OH 
		where 
		ID = Vdoc__id and Vdoc__id is not null;
begin

	
	--  Le parent "OH.DOC_OH" doit exister à la création d'un enfant dans "OH.CONTACT_OH"
	if :new.DOC__ID is not null then 
		open c1_contact_oh ( :new.DOC__ID);
		fetch c1_contact_oh into dummy;
		found := c1_contact_oh%FOUND;
		close c1_contact_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DOC_OH". Impossible de créer un enfant dans "OH.CONTACT_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_CONTACTOH" before update
on OH.CONTACT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.DOC_OH"
	cursor c1_contact_oh (Vdoc__id number) is
		select 1 
		from OH.DOC_OH 
		where 
		ID = Vdoc__id and Vdoc__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.DOC_OH" doit exister à la création d'un enfant dans "OH.CONTACT_OH"
	if :new.DOC__ID is not null and seq = 0 then 
		open c1_contact_oh ( :new.DOC__ID);
		fetch c1_contact_oh into dummy;
		found := c1_contact_oh%FOUND;
		close c1_contact_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DOC_OH". Impossible de modifier un enfant dans "OH.CONTACT_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TIB_CLSDOCOH" before insert
on OH.CLS_DOC_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CLS_OH"
	cursor c1_cls_doc_oh(Vcls__id number) is
		select 1 
		from OH.CLS_OH 
		where 
		ID = Vcls__id and Vcls__id is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.DOC_OH"
	cursor c2_cls_doc_oh(Vdoc__id number) is
		select 1 
		from OH.DOC_OH 
		where 
		ID = Vdoc__id and Vdoc__id is not null;
begin

	
	--  Le parent "OH.CLS_OH" doit exister à la création d'un enfant dans "OH.CLS_DOC_OH"
	if :new.CLS__ID is not null then 
		open c1_cls_doc_oh ( :new.CLS__ID);
		fetch c1_cls_doc_oh into dummy;
		found := c1_cls_doc_oh%FOUND;
		close c1_cls_doc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CLS_OH". Impossible de créer un enfant dans "OH.CLS_DOC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.DOC_OH" doit exister à la création d'un enfant dans "OH.CLS_DOC_OH"
	if :new.DOC__ID is not null then 
		open c2_cls_doc_oh ( :new.DOC__ID);
		fetch c2_cls_doc_oh into dummy;
		found := c2_cls_doc_oh%FOUND;
		close c2_cls_doc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DOC_OH". Impossible de créer un enfant dans "OH.CLS_DOC_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_CLSDOCOH" before update
on OH.CLS_DOC_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CLS_OH"
	cursor c1_cls_doc_oh (Vcls__id number) is
		select 1 
		from OH.CLS_OH 
		where 
		ID = Vcls__id and Vcls__id is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.DOC_OH"
	cursor c2_cls_doc_oh (Vdoc__id number) is
		select 1 
		from OH.DOC_OH 
		where 
		ID = Vdoc__id and Vdoc__id is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.CLS_OH" doit exister à la création d'un enfant dans "OH.CLS_DOC_OH"
	if :new.CLS__ID is not null and seq = 0 then 
		open c1_cls_doc_oh ( :new.CLS__ID);
		fetch c1_cls_doc_oh into dummy;
		found := c1_cls_doc_oh%FOUND;
		close c1_cls_doc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CLS_OH". Impossible de modifier un enfant dans "OH.CLS_DOC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.DOC_OH" doit exister à la création d'un enfant dans "OH.CLS_DOC_OH"
	if :new.DOC__ID is not null and seq = 0 then 
		open c2_cls_doc_oh ( :new.DOC__ID);
		fetch c2_cls_doc_oh into dummy;
		found := c2_cls_doc_oh%FOUND;
		close c2_cls_doc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DOC_OH". Impossible de modifier un enfant dans "OH.CLS_DOC_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_CDCONTRAINTEOH" after update
of TYPE
on OH.CD_CONTRAINTE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_CONTRAINTE_OH" dans les enfants "OH.PREVISION_OH"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update OH.PREVISION_OH
		set CD_CONTRAINTE_OH__TYPE = :new.TYPE  
		where CD_CONTRAINTE_OH__TYPE = :old.TYPE;
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


create or replace TRIGGER "OH"."TDA_CDCONTRAINTEOH" after delete
on OH.CD_CONTRAINTE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.PREVISION_OH"
	delete OH.PREVISION_OH
	where CD_CONTRAINTE_OH__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_ELTINSPOH" before insert
on OH.ELT_INSP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.ELT_OH"
	cursor c1_elt_insp_oh(Vgrp_oh__id_grp number,
	Vprt_oh__id_prt number,
	Vsprt_oh__id_sprt number,
	Velt_oh__id_elem number) is
		select 1 
		from OH.ELT_OH 
		where 
		GRP_OH__ID_GRP = Vgrp_oh__id_grp and Vgrp_oh__id_grp is not null and 
		PRT_OH__ID_PRT = Vprt_oh__id_prt and Vprt_oh__id_prt is not null and 
		SPRT_OH__ID_SPRT = Vsprt_oh__id_sprt and Vsprt_oh__id_sprt is not null and 
		ID_ELEM = Velt_oh__id_elem and Velt_oh__id_elem is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.INSP_OH"
	cursor c2_elt_insp_oh(Vcamp_oh__id_camp varchar,
	Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.INSP_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_OH__NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
begin

	
	--  Le parent "OH.ELT_OH" doit exister à la création d'un enfant dans "OH.ELT_INSP_OH"
	if :new.GRP_OH__ID_GRP is not null and 
	:new.PRT_OH__ID_PRT is not null and 
	:new.SPRT_OH__ID_SPRT is not null and 
	:new.ELT_OH__ID_ELEM is not null then 
		open c1_elt_insp_oh ( :new.GRP_OH__ID_GRP,
		:new.PRT_OH__ID_PRT,
		:new.SPRT_OH__ID_SPRT,
		:new.ELT_OH__ID_ELEM);
		fetch c1_elt_insp_oh into dummy;
		found := c1_elt_insp_oh%FOUND;
		close c1_elt_insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.ELT_OH". Impossible de créer un enfant dans "OH.ELT_INSP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.INSP_OH" doit exister à la création d'un enfant dans "OH.ELT_INSP_OH"
	if :new.CAMP_OH__ID_CAMP is not null and 
	:new.DSC_OH__NUM_OH is not null then 
		open c2_elt_insp_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_OH__NUM_OH);
		fetch c2_elt_insp_oh into dummy;
		found := c2_elt_insp_oh%FOUND;
		close c2_elt_insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.INSP_OH". Impossible de créer un enfant dans "OH.ELT_INSP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_ELTINSPOH" before update
on OH.ELT_INSP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.ELT_OH"
	cursor c1_elt_insp_oh (Vgrp_oh__id_grp number,
	Vprt_oh__id_prt number,
	Vsprt_oh__id_sprt number,
	Velt_oh__id_elem number) is
		select 1 
		from OH.ELT_OH 
		where 
		GRP_OH__ID_GRP = Vgrp_oh__id_grp and Vgrp_oh__id_grp is not null and 
		PRT_OH__ID_PRT = Vprt_oh__id_prt and Vprt_oh__id_prt is not null and 
		SPRT_OH__ID_SPRT = Vsprt_oh__id_sprt and Vsprt_oh__id_sprt is not null and 
		ID_ELEM = Velt_oh__id_elem and Velt_oh__id_elem is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.INSP_OH"
	cursor c2_elt_insp_oh (Vcamp_oh__id_camp varchar,
	Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.INSP_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_OH__NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.ELT_OH" doit exister à la création d'un enfant dans "OH.ELT_INSP_OH"
	if :new.GRP_OH__ID_GRP is not null and seq = 0 and 
	:new.PRT_OH__ID_PRT is not null and seq = 0 and 
	:new.SPRT_OH__ID_SPRT is not null and seq = 0 and 
	:new.ELT_OH__ID_ELEM is not null and seq = 0 then 
		open c1_elt_insp_oh ( :new.GRP_OH__ID_GRP,
		:new.PRT_OH__ID_PRT,
		:new.SPRT_OH__ID_SPRT,
		:new.ELT_OH__ID_ELEM);
		fetch c1_elt_insp_oh into dummy;
		found := c1_elt_insp_oh%FOUND;
		close c1_elt_insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.ELT_OH". Impossible de modifier un enfant dans "OH.ELT_INSP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.INSP_OH" doit exister à la création d'un enfant dans "OH.ELT_INSP_OH"
	if :new.CAMP_OH__ID_CAMP is not null and seq = 0 and 
	:new.DSC_OH__NUM_OH is not null and seq = 0 then 
		open c2_elt_insp_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_OH__NUM_OH);
		fetch c2_elt_insp_oh into dummy;
		found := c2_elt_insp_oh%FOUND;
		close c2_elt_insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.INSP_OH". Impossible de modifier un enfant dans "OH.ELT_INSP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_ELTINSPOH" after update
of GRP_OH__ID_GRP,PRT_OH__ID_PRT,SPRT_OH__ID_SPRT,CAMP_OH__ID_CAMP,ELT_OH__ID_ELEM,DSC_OH__NUM_OH
on OH.ELT_INSP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.ELT_INSP_OH" dans les enfants "OH.PHOTO_ELT_INSP_OH"
	if ((updating('GRP_OH__ID_GRP') and :old.GRP_OH__ID_GRP != :new.GRP_OH__ID_GRP) or 
	(updating('PRT_OH__ID_PRT') and :old.PRT_OH__ID_PRT != :new.PRT_OH__ID_PRT) or 
	(updating('SPRT_OH__ID_SPRT') and :old.SPRT_OH__ID_SPRT != :new.SPRT_OH__ID_SPRT) or 
	(updating('CAMP_OH__ID_CAMP') and :old.CAMP_OH__ID_CAMP != :new.CAMP_OH__ID_CAMP) or 
	(updating('ELT_OH__ID_ELEM') and :old.ELT_OH__ID_ELEM != :new.ELT_OH__ID_ELEM) or 
	(updating('DSC_OH__NUM_OH') and :old.DSC_OH__NUM_OH != :new.DSC_OH__NUM_OH)) then 
		update OH.PHOTO_ELT_INSP_OH
		set GRP_OH__ID_GRP = :new.GRP_OH__ID_GRP,
		PRT_OH__ID_PRT = :new.PRT_OH__ID_PRT,
		SPRT_OH__ID_SPRT = :new.SPRT_OH__ID_SPRT,
		CAMP_OH__ID_CAMP = :new.CAMP_OH__ID_CAMP,
		ELT_OH__ID_ELEM = :new.ELT_OH__ID_ELEM,
		DSC_OH__NUM_OH = :new.DSC_OH__NUM_OH  
		where GRP_OH__ID_GRP = :old.GRP_OH__ID_GRP and 
		PRT_OH__ID_PRT = :old.PRT_OH__ID_PRT and 
		SPRT_OH__ID_SPRT = :old.SPRT_OH__ID_SPRT and 
		CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
		ELT_OH__ID_ELEM = :old.ELT_OH__ID_ELEM and 
		DSC_OH__NUM_OH = :old.DSC_OH__NUM_OH;
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


create or replace TRIGGER "OH"."TDA_ELTINSPOH" after delete
on OH.ELT_INSP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.PHOTO_ELT_INSP_OH"
	delete OH.PHOTO_ELT_INSP_OH
	where GRP_OH__ID_GRP = :old.GRP_OH__ID_GRP and 
	PRT_OH__ID_PRT = :old.PRT_OH__ID_PRT and 
	SPRT_OH__ID_SPRT = :old.SPRT_OH__ID_SPRT and 
	CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
	ELT_OH__ID_ELEM = :old.ELT_OH__ID_ELEM and 
	DSC_OH__NUM_OH = :old.DSC_OH__NUM_OH;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_ELTINSPTMPOH" before insert
on OH.ELT_INSP_TMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.INSP_TMP_OH"
	cursor c1_elt_insp_tmp_oh(Vcamp_oh__id_camp varchar,
	Vdsc_temp_oh__num_oh varchar) is
		select 1 
		from OH.INSP_TMP_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_TEMP_OH__NUM_OH = Vdsc_temp_oh__num_oh and Vdsc_temp_oh__num_oh is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.ELT_OH"
	cursor c2_elt_insp_tmp_oh(Vgrp_oh__id_grp number,
	Vprt_oh__id_prt number,
	Vsprt_oh__id_sprt number,
	Velt_oh__id_elem number) is
		select 1 
		from OH.ELT_OH 
		where 
		GRP_OH__ID_GRP = Vgrp_oh__id_grp and Vgrp_oh__id_grp is not null and 
		PRT_OH__ID_PRT = Vprt_oh__id_prt and Vprt_oh__id_prt is not null and 
		SPRT_OH__ID_SPRT = Vsprt_oh__id_sprt and Vsprt_oh__id_sprt is not null and 
		ID_ELEM = Velt_oh__id_elem and Velt_oh__id_elem is not null;
begin

	
	--  Le parent "OH.INSP_TMP_OH" doit exister à la création d'un enfant dans "OH.ELT_INSP_TMP_OH"
	if :new.CAMP_OH__ID_CAMP is not null and 
	:new.DSC_TEMP_OH__NUM_OH is not null then 
		open c1_elt_insp_tmp_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_TEMP_OH__NUM_OH);
		fetch c1_elt_insp_tmp_oh into dummy;
		found := c1_elt_insp_tmp_oh%FOUND;
		close c1_elt_insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.INSP_TMP_OH". Impossible de créer un enfant dans "OH.ELT_INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.ELT_OH" doit exister à la création d'un enfant dans "OH.ELT_INSP_TMP_OH"
	if :new.GRP_OH__ID_GRP is not null and 
	:new.PRT_OH__ID_PRT is not null and 
	:new.SPRT_OH__ID_SPRT is not null and 
	:new.ELT_OH__ID_ELEM is not null then 
		open c2_elt_insp_tmp_oh ( :new.GRP_OH__ID_GRP,
		:new.PRT_OH__ID_PRT,
		:new.SPRT_OH__ID_SPRT,
		:new.ELT_OH__ID_ELEM);
		fetch c2_elt_insp_tmp_oh into dummy;
		found := c2_elt_insp_tmp_oh%FOUND;
		close c2_elt_insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.ELT_OH". Impossible de créer un enfant dans "OH.ELT_INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_ELTINSPTMPOH" before update
on OH.ELT_INSP_TMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.INSP_TMP_OH"
	cursor c1_elt_insp_tmp_oh (Vcamp_oh__id_camp varchar,
	Vdsc_temp_oh__num_oh varchar) is
		select 1 
		from OH.INSP_TMP_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_TEMP_OH__NUM_OH = Vdsc_temp_oh__num_oh and Vdsc_temp_oh__num_oh is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.ELT_OH"
	cursor c2_elt_insp_tmp_oh (Vgrp_oh__id_grp number,
	Vprt_oh__id_prt number,
	Vsprt_oh__id_sprt number,
	Velt_oh__id_elem number) is
		select 1 
		from OH.ELT_OH 
		where 
		GRP_OH__ID_GRP = Vgrp_oh__id_grp and Vgrp_oh__id_grp is not null and 
		PRT_OH__ID_PRT = Vprt_oh__id_prt and Vprt_oh__id_prt is not null and 
		SPRT_OH__ID_SPRT = Vsprt_oh__id_sprt and Vsprt_oh__id_sprt is not null and 
		ID_ELEM = Velt_oh__id_elem and Velt_oh__id_elem is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.INSP_TMP_OH" doit exister à la création d'un enfant dans "OH.ELT_INSP_TMP_OH"
	if :new.CAMP_OH__ID_CAMP is not null and seq = 0 and 
	:new.DSC_TEMP_OH__NUM_OH is not null and seq = 0 then 
		open c1_elt_insp_tmp_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_TEMP_OH__NUM_OH);
		fetch c1_elt_insp_tmp_oh into dummy;
		found := c1_elt_insp_tmp_oh%FOUND;
		close c1_elt_insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.INSP_TMP_OH". Impossible de modifier un enfant dans "OH.ELT_INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.ELT_OH" doit exister à la création d'un enfant dans "OH.ELT_INSP_TMP_OH"
	if :new.GRP_OH__ID_GRP is not null and seq = 0 and 
	:new.PRT_OH__ID_PRT is not null and seq = 0 and 
	:new.SPRT_OH__ID_SPRT is not null and seq = 0 and 
	:new.ELT_OH__ID_ELEM is not null and seq = 0 then 
		open c2_elt_insp_tmp_oh ( :new.GRP_OH__ID_GRP,
		:new.PRT_OH__ID_PRT,
		:new.SPRT_OH__ID_SPRT,
		:new.ELT_OH__ID_ELEM);
		fetch c2_elt_insp_tmp_oh into dummy;
		found := c2_elt_insp_tmp_oh%FOUND;
		close c2_elt_insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.ELT_OH". Impossible de modifier un enfant dans "OH.ELT_INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_ELTINSPTMPOH" after update
of GRP_OH__ID_GRP,PRT_OH__ID_PRT,SPRT_OH__ID_SPRT,CAMP_OH__ID_CAMP,DSC_TEMP_OH__NUM_OH,ELT_OH__ID_ELEM
on OH.ELT_INSP_TMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.ELT_INSP_TMP_OH" dans les enfants "OH.PHOTO_ELT_INSP_TMP_OH"
	if ((updating('GRP_OH__ID_GRP') and :old.GRP_OH__ID_GRP != :new.GRP_OH__ID_GRP) or 
	(updating('PRT_OH__ID_PRT') and :old.PRT_OH__ID_PRT != :new.PRT_OH__ID_PRT) or 
	(updating('SPRT_OH__ID_SPRT') and :old.SPRT_OH__ID_SPRT != :new.SPRT_OH__ID_SPRT) or 
	(updating('CAMP_OH__ID_CAMP') and :old.CAMP_OH__ID_CAMP != :new.CAMP_OH__ID_CAMP) or 
	(updating('DSC_TEMP_OH__NUM_OH') and :old.DSC_TEMP_OH__NUM_OH != :new.DSC_TEMP_OH__NUM_OH) or 
	(updating('ELT_OH__ID_ELEM') and :old.ELT_OH__ID_ELEM != :new.ELT_OH__ID_ELEM)) then 
		update OH.PHOTO_ELT_INSP_TMP_OH
		set GRP_OH__ID_GRP = :new.GRP_OH__ID_GRP,
		PRT_OH__ID_PRT = :new.PRT_OH__ID_PRT,
		SPRT_OH__ID_SPRT = :new.SPRT_OH__ID_SPRT,
		CAMP_OH__ID_CAMP = :new.CAMP_OH__ID_CAMP,
		DSC_TEMP_OH__NUM_OH = :new.DSC_TEMP_OH__NUM_OH,
		ELT_OH__ID_ELEM = :new.ELT_OH__ID_ELEM  
		where GRP_OH__ID_GRP = :old.GRP_OH__ID_GRP and 
		PRT_OH__ID_PRT = :old.PRT_OH__ID_PRT and 
		SPRT_OH__ID_SPRT = :old.SPRT_OH__ID_SPRT and 
		CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
		DSC_TEMP_OH__NUM_OH = :old.DSC_TEMP_OH__NUM_OH and 
		ELT_OH__ID_ELEM = :old.ELT_OH__ID_ELEM;
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


create or replace TRIGGER "OH"."TDA_ELTINSPTMPOH" after delete
on OH.ELT_INSP_TMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.PHOTO_ELT_INSP_TMP_OH"
	delete OH.PHOTO_ELT_INSP_TMP_OH
	where GRP_OH__ID_GRP = :old.GRP_OH__ID_GRP and 
	PRT_OH__ID_PRT = :old.PRT_OH__ID_PRT and 
	SPRT_OH__ID_SPRT = :old.SPRT_OH__ID_SPRT and 
	CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
	DSC_TEMP_OH__NUM_OH = :old.DSC_TEMP_OH__NUM_OH and 
	ELT_OH__ID_ELEM = :old.ELT_OH__ID_ELEM;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_SPRTVSTOH" before insert
on OH.SPRT_VST_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.VST_OH"
	cursor c1_sprt_vst_oh(Vcamp_oh__id_camp varchar,
	Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.VST_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_OH__NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_LIGNE_OH"
	cursor c2_sprt_vst_oh(Vcd_chapitre_oh__id_chap number,
	Vcd_ligne_oh__id_ligne number) is
		select 1 
		from OH.CD_LIGNE_OH 
		where 
		CD_CHAPITRE_OH__ID_CHAP = Vcd_chapitre_oh__id_chap and Vcd_chapitre_oh__id_chap is not null and 
		ID_LIGNE = Vcd_ligne_oh__id_ligne and Vcd_ligne_oh__id_ligne is not null;
begin

	
	--  Le parent "OH.VST_OH" doit exister à la création d'un enfant dans "OH.SPRT_VST_OH"
	if :new.CAMP_OH__ID_CAMP is not null and 
	:new.DSC_OH__NUM_OH is not null then 
		open c1_sprt_vst_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_OH__NUM_OH);
		fetch c1_sprt_vst_oh into dummy;
		found := c1_sprt_vst_oh%FOUND;
		close c1_sprt_vst_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.VST_OH". Impossible de créer un enfant dans "OH.SPRT_VST_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_LIGNE_OH" doit exister à la création d'un enfant dans "OH.SPRT_VST_OH"
	if :new.CD_CHAPITRE_OH__ID_CHAP is not null and 
	:new.CD_LIGNE_OH__ID_LIGNE is not null then 
		open c2_sprt_vst_oh ( :new.CD_CHAPITRE_OH__ID_CHAP,
		:new.CD_LIGNE_OH__ID_LIGNE);
		fetch c2_sprt_vst_oh into dummy;
		found := c2_sprt_vst_oh%FOUND;
		close c2_sprt_vst_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_LIGNE_OH". Impossible de créer un enfant dans "OH.SPRT_VST_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_SPRTVSTOH" before update
on OH.SPRT_VST_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.VST_OH"
	cursor c1_sprt_vst_oh (Vcamp_oh__id_camp varchar,
	Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.VST_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_OH__NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_LIGNE_OH"
	cursor c2_sprt_vst_oh (Vcd_chapitre_oh__id_chap number,
	Vcd_ligne_oh__id_ligne number) is
		select 1 
		from OH.CD_LIGNE_OH 
		where 
		CD_CHAPITRE_OH__ID_CHAP = Vcd_chapitre_oh__id_chap and Vcd_chapitre_oh__id_chap is not null and 
		ID_LIGNE = Vcd_ligne_oh__id_ligne and Vcd_ligne_oh__id_ligne is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.VST_OH" doit exister à la création d'un enfant dans "OH.SPRT_VST_OH"
	if :new.CAMP_OH__ID_CAMP is not null and seq = 0 and 
	:new.DSC_OH__NUM_OH is not null and seq = 0 then 
		open c1_sprt_vst_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_OH__NUM_OH);
		fetch c1_sprt_vst_oh into dummy;
		found := c1_sprt_vst_oh%FOUND;
		close c1_sprt_vst_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.VST_OH". Impossible de modifier un enfant dans "OH.SPRT_VST_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_LIGNE_OH" doit exister à la création d'un enfant dans "OH.SPRT_VST_OH"
	if :new.CD_CHAPITRE_OH__ID_CHAP is not null and seq = 0 and 
	:new.CD_LIGNE_OH__ID_LIGNE is not null and seq = 0 then 
		open c2_sprt_vst_oh ( :new.CD_CHAPITRE_OH__ID_CHAP,
		:new.CD_LIGNE_OH__ID_LIGNE);
		fetch c2_sprt_vst_oh into dummy;
		found := c2_sprt_vst_oh%FOUND;
		close c2_sprt_vst_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_LIGNE_OH". Impossible de modifier un enfant dans "OH.SPRT_VST_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_SPRTVSTOH" after update
of CAMP_OH__ID_CAMP,DSC_OH__NUM_OH,CD_CHAPITRE_OH__ID_CHAP,CD_LIGNE_OH__ID_LIGNE
on OH.SPRT_VST_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.SPRT_VST_OH" dans les enfants "OH.PHOTO_SPRT_VST_OH"
	if ((updating('CAMP_OH__ID_CAMP') and :old.CAMP_OH__ID_CAMP != :new.CAMP_OH__ID_CAMP) or 
	(updating('DSC_OH__NUM_OH') and :old.DSC_OH__NUM_OH != :new.DSC_OH__NUM_OH) or 
	(updating('CD_CHAPITRE_OH__ID_CHAP') and :old.CD_CHAPITRE_OH__ID_CHAP != :new.CD_CHAPITRE_OH__ID_CHAP) or 
	(updating('CD_LIGNE_OH__ID_LIGNE') and :old.CD_LIGNE_OH__ID_LIGNE != :new.CD_LIGNE_OH__ID_LIGNE)) then 
		update OH.PHOTO_SPRT_VST_OH
		set CAMP_OH__ID_CAMP = :new.CAMP_OH__ID_CAMP,
		DSC_OH__NUM_OH = :new.DSC_OH__NUM_OH,
		CD_CHAPITRE_OH__ID_CHAP = :new.CD_CHAPITRE_OH__ID_CHAP,
		CD_LIGNE_OH__ID_LIGNE = :new.CD_LIGNE_OH__ID_LIGNE  
		where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
		DSC_OH__NUM_OH = :old.DSC_OH__NUM_OH and 
		CD_CHAPITRE_OH__ID_CHAP = :old.CD_CHAPITRE_OH__ID_CHAP and 
		CD_LIGNE_OH__ID_LIGNE = :old.CD_LIGNE_OH__ID_LIGNE;
	end if;
	--  Modification du code du parent "OH.SPRT_VST_OH" dans les enfants "OH.CD_PRECO__SPRT_VST_OH"
	if ((updating('CAMP_OH__ID_CAMP') and :old.CAMP_OH__ID_CAMP != :new.CAMP_OH__ID_CAMP) or 
	(updating('DSC_OH__NUM_OH') and :old.DSC_OH__NUM_OH != :new.DSC_OH__NUM_OH) or 
	(updating('CD_CHAPITRE_OH__ID_CHAP') and :old.CD_CHAPITRE_OH__ID_CHAP != :new.CD_CHAPITRE_OH__ID_CHAP) or 
	(updating('CD_LIGNE_OH__ID_LIGNE') and :old.CD_LIGNE_OH__ID_LIGNE != :new.CD_LIGNE_OH__ID_LIGNE)) then 
		update OH.CD_PRECO__SPRT_VST_OH
		set CAMP_OH__ID_CAMP = :new.CAMP_OH__ID_CAMP,
		DSC_OH__NUM_OH = :new.DSC_OH__NUM_OH,
		CD_CHAPITRE_OH__ID_CHAP = :new.CD_CHAPITRE_OH__ID_CHAP,
		CD_LIGNE_OH__ID_LIGNE = :new.CD_LIGNE_OH__ID_LIGNE  
		where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
		DSC_OH__NUM_OH = :old.DSC_OH__NUM_OH and 
		CD_CHAPITRE_OH__ID_CHAP = :old.CD_CHAPITRE_OH__ID_CHAP and 
		CD_LIGNE_OH__ID_LIGNE = :old.CD_LIGNE_OH__ID_LIGNE;
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


create or replace TRIGGER "OH"."TDA_SPRTVSTOH" after delete
on OH.SPRT_VST_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.PHOTO_SPRT_VST_OH"
	delete OH.PHOTO_SPRT_VST_OH
	where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
	DSC_OH__NUM_OH = :old.DSC_OH__NUM_OH and 
	CD_CHAPITRE_OH__ID_CHAP = :old.CD_CHAPITRE_OH__ID_CHAP and 
	CD_LIGNE_OH__ID_LIGNE = :old.CD_LIGNE_OH__ID_LIGNE;
	
	--  Suppression des enfants dans "OH.CD_PRECO__SPRT_VST_OH"
	delete OH.CD_PRECO__SPRT_VST_OH
	where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
	DSC_OH__NUM_OH = :old.DSC_OH__NUM_OH and 
	CD_CHAPITRE_OH__ID_CHAP = :old.CD_CHAPITRE_OH__ID_CHAP and 
	CD_LIGNE_OH__ID_LIGNE = :old.CD_LIGNE_OH__ID_LIGNE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_DOCOH" before insert
on OH.DOC_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_DOC_OH"
	cursor c1_doc_oh(Vcd_doc__code varchar) is
		select 1 
		from OH.CD_DOC_OH 
		where 
		CODE = Vcd_doc__code and Vcd_doc__code is not null;
begin

	
	--  Le parent "OH.CD_DOC_OH" doit exister à la création d'un enfant dans "OH.DOC_OH"
	if :new.CD_DOC__CODE is not null then 
		open c1_doc_oh ( :new.CD_DOC__CODE);
		fetch c1_doc_oh into dummy;
		found := c1_doc_oh%FOUND;
		close c1_doc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_DOC_OH". Impossible de créer un enfant dans "OH.DOC_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_DOCOH" before update
on OH.DOC_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_DOC_OH"
	cursor c1_doc_oh (Vcd_doc__code varchar) is
		select 1 
		from OH.CD_DOC_OH 
		where 
		CODE = Vcd_doc__code and Vcd_doc__code is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.CD_DOC_OH" doit exister à la création d'un enfant dans "OH.DOC_OH"
	if :new.CD_DOC__CODE is not null and seq = 0 then 
		open c1_doc_oh ( :new.CD_DOC__CODE);
		fetch c1_doc_oh into dummy;
		found := c1_doc_oh%FOUND;
		close c1_doc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_DOC_OH". Impossible de modifier un enfant dans "OH.DOC_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_DOCOH" after update
of ID
on OH.DOC_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.DOC_OH" dans les enfants "OH.CONTACT_OH"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update OH.CONTACT_OH
		set DOC__ID = :new.ID  
		where DOC__ID = :old.ID;
	end if;
	--  Modification du code du parent "OH.DOC_OH" dans les enfants "OH.CLS_DOC_OH"
	if ((updating('ID') and :old.ID != :new.ID)) then 
		update OH.CLS_DOC_OH
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


create or replace TRIGGER "OH"."TDA_DOCOH" after delete
on OH.DOC_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.CONTACT_OH"
	delete OH.CONTACT_OH
	where DOC__ID = :old.ID;
	
	--  Suppression des enfants dans "OH.CLS_DOC_OH"
	delete OH.CLS_DOC_OH
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


create or replace TRIGGER "OH"."TUA_CDEAUOH" after update
of EAU
on OH.CD_EAU_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_EAU_OH" dans les enfants "OH.DSC_OH"
	if ((updating('EAU') and :old.EAU != :new.EAU)) then 
		update OH.DSC_OH
		set CD_EAU_OH__EAU = :new.EAU  
		where CD_EAU_OH__EAU = :old.EAU;
	end if;
	--  Modification du code du parent "OH.CD_EAU_OH" dans les enfants "OH.DSC_TEMP_OH"
	if ((updating('EAU') and :old.EAU != :new.EAU)) then 
		update OH.DSC_TEMP_OH
		set CD_EAU_OH__EAU = :new.EAU  
		where CD_EAU_OH__EAU = :old.EAU;
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


create or replace TRIGGER "OH"."TDA_CDEAUOH" after delete
on OH.CD_EAU_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.DSC_OH"
	delete OH.DSC_OH
	where CD_EAU_OH__EAU = :old.EAU;
	
	--  Suppression des enfants dans "OH.DSC_TEMP_OH"
	delete OH.DSC_TEMP_OH
	where CD_EAU_OH__EAU = :old.EAU;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDECOULOH" after update
of ECOUL
on OH.CD_ECOUL_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_ECOUL_OH" dans les enfants "OH.DSC_OH"
	if ((updating('ECOUL') and :old.ECOUL != :new.ECOUL)) then 
		update OH.DSC_OH
		set CD_ECOUL_OH__ECOUL = :new.ECOUL  
		where CD_ECOUL_OH__ECOUL = :old.ECOUL;
	end if;
	--  Modification du code du parent "OH.CD_ECOUL_OH" dans les enfants "OH.DSC_TEMP_OH"
	if ((updating('ECOUL') and :old.ECOUL != :new.ECOUL)) then 
		update OH.DSC_TEMP_OH
		set CD_ECOUL_OH__ECOUL = :new.ECOUL  
		where CD_ECOUL_OH__ECOUL = :old.ECOUL;
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


create or replace TRIGGER "OH"."TDA_CDECOULOH" after delete
on OH.CD_ECOUL_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.DSC_OH"
	delete OH.DSC_OH
	where CD_ECOUL_OH__ECOUL = :old.ECOUL;
	
	--  Suppression des enfants dans "OH.DSC_TEMP_OH"
	delete OH.DSC_TEMP_OH
	where CD_ECOUL_OH__ECOUL = :old.ECOUL;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_ELTOH" before insert
on OH.ELT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.SPRT_OH"
	cursor c1_elt_oh(Vgrp_oh__id_grp number,
	Vprt_oh__id_prt number,
	Vsprt_oh__id_sprt number) is
		select 1 
		from OH.SPRT_OH 
		where 
		GRP_OH__ID_GRP = Vgrp_oh__id_grp and Vgrp_oh__id_grp is not null and 
		PRT_OH__ID_PRT = Vprt_oh__id_prt and Vprt_oh__id_prt is not null and 
		ID_SPRT = Vsprt_oh__id_sprt and Vsprt_oh__id_sprt is not null;
begin

	
	--  Le parent "OH.SPRT_OH" doit exister à la création d'un enfant dans "OH.ELT_OH"
	if :new.GRP_OH__ID_GRP is not null and 
	:new.PRT_OH__ID_PRT is not null and 
	:new.SPRT_OH__ID_SPRT is not null then 
		open c1_elt_oh ( :new.GRP_OH__ID_GRP,
		:new.PRT_OH__ID_PRT,
		:new.SPRT_OH__ID_SPRT);
		fetch c1_elt_oh into dummy;
		found := c1_elt_oh%FOUND;
		close c1_elt_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.SPRT_OH". Impossible de créer un enfant dans "OH.ELT_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_ELTOH" before update
on OH.ELT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.SPRT_OH"
	cursor c1_elt_oh (Vgrp_oh__id_grp number,
	Vprt_oh__id_prt number,
	Vsprt_oh__id_sprt number) is
		select 1 
		from OH.SPRT_OH 
		where 
		GRP_OH__ID_GRP = Vgrp_oh__id_grp and Vgrp_oh__id_grp is not null and 
		PRT_OH__ID_PRT = Vprt_oh__id_prt and Vprt_oh__id_prt is not null and 
		ID_SPRT = Vsprt_oh__id_sprt and Vsprt_oh__id_sprt is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.SPRT_OH" doit exister à la création d'un enfant dans "OH.ELT_OH"
	if :new.GRP_OH__ID_GRP is not null and seq = 0 and 
	:new.PRT_OH__ID_PRT is not null and seq = 0 and 
	:new.SPRT_OH__ID_SPRT is not null and seq = 0 then 
		open c1_elt_oh ( :new.GRP_OH__ID_GRP,
		:new.PRT_OH__ID_PRT,
		:new.SPRT_OH__ID_SPRT);
		fetch c1_elt_oh into dummy;
		found := c1_elt_oh%FOUND;
		close c1_elt_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.SPRT_OH". Impossible de modifier un enfant dans "OH.ELT_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_ELTOH" after update
of GRP_OH__ID_GRP,PRT_OH__ID_PRT,SPRT_OH__ID_SPRT,ID_ELEM
on OH.ELT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.ELT_OH" dans les enfants "OH.ELT_INSP_OH"
	if ((updating('GRP_OH__ID_GRP') and :old.GRP_OH__ID_GRP != :new.GRP_OH__ID_GRP) or 
	(updating('PRT_OH__ID_PRT') and :old.PRT_OH__ID_PRT != :new.PRT_OH__ID_PRT) or 
	(updating('SPRT_OH__ID_SPRT') and :old.SPRT_OH__ID_SPRT != :new.SPRT_OH__ID_SPRT) or 
	(updating('ID_ELEM') and :old.ID_ELEM != :new.ID_ELEM)) then 
		update OH.ELT_INSP_OH
		set GRP_OH__ID_GRP = :new.GRP_OH__ID_GRP,
		PRT_OH__ID_PRT = :new.PRT_OH__ID_PRT,
		SPRT_OH__ID_SPRT = :new.SPRT_OH__ID_SPRT,
		ELT_OH__ID_ELEM = :new.ID_ELEM  
		where GRP_OH__ID_GRP = :old.GRP_OH__ID_GRP and 
		PRT_OH__ID_PRT = :old.PRT_OH__ID_PRT and 
		SPRT_OH__ID_SPRT = :old.SPRT_OH__ID_SPRT and 
		ELT_OH__ID_ELEM = :old.ID_ELEM;
	end if;
	--  Modification du code du parent "OH.ELT_OH" dans les enfants "OH.ELT_INSP_TMP_OH"
	if ((updating('GRP_OH__ID_GRP') and :old.GRP_OH__ID_GRP != :new.GRP_OH__ID_GRP) or 
	(updating('PRT_OH__ID_PRT') and :old.PRT_OH__ID_PRT != :new.PRT_OH__ID_PRT) or 
	(updating('SPRT_OH__ID_SPRT') and :old.SPRT_OH__ID_SPRT != :new.SPRT_OH__ID_SPRT) or 
	(updating('ID_ELEM') and :old.ID_ELEM != :new.ID_ELEM)) then 
		update OH.ELT_INSP_TMP_OH
		set GRP_OH__ID_GRP = :new.GRP_OH__ID_GRP,
		PRT_OH__ID_PRT = :new.PRT_OH__ID_PRT,
		SPRT_OH__ID_SPRT = :new.SPRT_OH__ID_SPRT,
		ELT_OH__ID_ELEM = :new.ID_ELEM  
		where GRP_OH__ID_GRP = :old.GRP_OH__ID_GRP and 
		PRT_OH__ID_PRT = :old.PRT_OH__ID_PRT and 
		SPRT_OH__ID_SPRT = :old.SPRT_OH__ID_SPRT and 
		ELT_OH__ID_ELEM = :old.ID_ELEM;
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


create or replace TRIGGER "OH"."TDA_ELTOH" after delete
on OH.ELT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.ELT_INSP_OH"
	delete OH.ELT_INSP_OH
	where GRP_OH__ID_GRP = :old.GRP_OH__ID_GRP and 
	PRT_OH__ID_PRT = :old.PRT_OH__ID_PRT and 
	SPRT_OH__ID_SPRT = :old.SPRT_OH__ID_SPRT and 
	ELT_OH__ID_ELEM = :old.ID_ELEM;
	
	--  Suppression des enfants dans "OH.ELT_INSP_TMP_OH"
	delete OH.ELT_INSP_TMP_OH
	where GRP_OH__ID_GRP = :old.GRP_OH__ID_GRP and 
	PRT_OH__ID_PRT = :old.PRT_OH__ID_PRT and 
	SPRT_OH__ID_SPRT = :old.SPRT_OH__ID_SPRT and 
	ELT_OH__ID_ELEM = :old.ID_ELEM;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_CDENTETEOH" before insert
on OH.CD_ENTETE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_COMPOSANT_OH"
	cursor c1_cd_entete_oh(Vcd_composant_oh__type_comp varchar) is
		select 1 
		from OH.CD_COMPOSANT_OH 
		where 
		TYPE_COMP = Vcd_composant_oh__type_comp and Vcd_composant_oh__type_comp is not null;
begin

	
	--  Le parent "OH.CD_COMPOSANT_OH" doit exister à la création d'un enfant dans "OH.CD_ENTETE_OH"
	if :new.CD_COMPOSANT_OH__TYPE_COMP is not null then 
		open c1_cd_entete_oh ( :new.CD_COMPOSANT_OH__TYPE_COMP);
		fetch c1_cd_entete_oh into dummy;
		found := c1_cd_entete_oh%FOUND;
		close c1_cd_entete_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_COMPOSANT_OH". Impossible de créer un enfant dans "OH.CD_ENTETE_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_CDENTETEOH" before update
on OH.CD_ENTETE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_COMPOSANT_OH"
	cursor c1_cd_entete_oh (Vcd_composant_oh__type_comp varchar) is
		select 1 
		from OH.CD_COMPOSANT_OH 
		where 
		TYPE_COMP = Vcd_composant_oh__type_comp and Vcd_composant_oh__type_comp is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.CD_COMPOSANT_OH" doit exister à la création d'un enfant dans "OH.CD_ENTETE_OH"
	if :new.CD_COMPOSANT_OH__TYPE_COMP is not null and seq = 0 then 
		open c1_cd_entete_oh ( :new.CD_COMPOSANT_OH__TYPE_COMP);
		fetch c1_cd_entete_oh into dummy;
		found := c1_cd_entete_oh%FOUND;
		close c1_cd_entete_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_COMPOSANT_OH". Impossible de modifier un enfant dans "OH.CD_ENTETE_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_CDENTETEOH" after update
of ID_ENTETE
on OH.CD_ENTETE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_ENTETE_OH" dans les enfants "OH.ENTETE_OH"
	if ((updating('ID_ENTETE') and :old.ID_ENTETE != :new.ID_ENTETE)) then 
		update OH.ENTETE_OH
		set CD_ENTETE_OH__ID_ENTETE = :new.ID_ENTETE  
		where CD_ENTETE_OH__ID_ENTETE = :old.ID_ENTETE;
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


create or replace TRIGGER "OH"."TDA_CDENTETEOH" after delete
on OH.CD_ENTETE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.ENTETE_OH"
	delete OH.ENTETE_OH
	where CD_ENTETE_OH__ID_ENTETE = :old.ID_ENTETE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDENTPOH" after update
of ENTREPRISE
on OH.CD_ENTP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_ENTP_OH" dans les enfants "OH.DSC_OH"
	if ((updating('ENTREPRISE') and :old.ENTREPRISE != :new.ENTREPRISE)) then 
		update OH.DSC_OH
		set CD_ENTP_OH__ENTREPRISE = :new.ENTREPRISE  
		where CD_ENTP_OH__ENTREPRISE = :old.ENTREPRISE;
	end if;
	--  Modification du code du parent "OH.CD_ENTP_OH" dans les enfants "OH.TRAVAUX_OH"
	if ((updating('ENTREPRISE') and :old.ENTREPRISE != :new.ENTREPRISE)) then 
		update OH.TRAVAUX_OH
		set CD_ENTP_OH__ENTREPRISE = :new.ENTREPRISE  
		where CD_ENTP_OH__ENTREPRISE = :old.ENTREPRISE;
	end if;
	--  Modification du code du parent "OH.CD_ENTP_OH" dans les enfants "OH.DSC_TEMP_OH"
	if ((updating('ENTREPRISE') and :old.ENTREPRISE != :new.ENTREPRISE)) then 
		update OH.DSC_TEMP_OH
		set CD_ENTP_OH__ENTREPRISE = :new.ENTREPRISE  
		where CD_ENTP_OH__ENTREPRISE = :old.ENTREPRISE;
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


create or replace TRIGGER "OH"."TDA_CDENTPOH" after delete
on OH.CD_ENTP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.DSC_OH"
	delete OH.DSC_OH
	where CD_ENTP_OH__ENTREPRISE = :old.ENTREPRISE;
	
	--  Suppression des enfants dans "OH.TRAVAUX_OH"
	delete OH.TRAVAUX_OH
	where CD_ENTP_OH__ENTREPRISE = :old.ENTREPRISE;
	
	--  Suppression des enfants dans "OH.DSC_TEMP_OH"
	delete OH.DSC_TEMP_OH
	where CD_ENTP_OH__ENTREPRISE = :old.ENTREPRISE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDETUDEOH" after update
of ETUDE
on OH.CD_ETUDE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_ETUDE_OH" dans les enfants "OH.INSP_OH"
	if ((updating('ETUDE') and :old.ETUDE != :new.ETUDE)) then 
		update OH.INSP_OH
		set CD_ETUDE_OH__ETUDE = :new.ETUDE  
		where CD_ETUDE_OH__ETUDE = :old.ETUDE;
	end if;
	--  Modification du code du parent "OH.CD_ETUDE_OH" dans les enfants "OH.INSP_TMP_OH"
	if ((updating('ETUDE') and :old.ETUDE != :new.ETUDE)) then 
		update OH.INSP_TMP_OH
		set CD_ETUDE_OH__ETUDE = :new.ETUDE  
		where CD_ETUDE_OH__ETUDE = :old.ETUDE;
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


create or replace TRIGGER "OH"."TDA_CDETUDEOH" after delete
on OH.CD_ETUDE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.INSP_OH"
	delete OH.INSP_OH
	where CD_ETUDE_OH__ETUDE = :old.ETUDE;
	
	--  Suppression des enfants dans "OH.INSP_TMP_OH"
	delete OH.INSP_TMP_OH
	where CD_ETUDE_OH__ETUDE = :old.ETUDE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_EVTOH" before insert
on OH.EVT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_EVT_OH"
	cursor c1_evt_oh(Vcd_evt_oh__type varchar) is
		select 1 
		from OH.CD_EVT_OH 
		where 
		TYPE = Vcd_evt_oh__type and Vcd_evt_oh__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.DSC_OH"
	cursor c2_evt_oh(Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.DSC_OH 
		where 
		NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
begin

	
	--  Le parent "OH.CD_EVT_OH" doit exister à la création d'un enfant dans "OH.EVT_OH"
	if :new.CD_EVT_OH__TYPE is not null then 
		open c1_evt_oh ( :new.CD_EVT_OH__TYPE);
		fetch c1_evt_oh into dummy;
		found := c1_evt_oh%FOUND;
		close c1_evt_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_EVT_OH". Impossible de créer un enfant dans "OH.EVT_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.DSC_OH" doit exister à la création d'un enfant dans "OH.EVT_OH"
	if :new.DSC_OH__NUM_OH is not null then 
		open c2_evt_oh ( :new.DSC_OH__NUM_OH);
		fetch c2_evt_oh into dummy;
		found := c2_evt_oh%FOUND;
		close c2_evt_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DSC_OH". Impossible de créer un enfant dans "OH.EVT_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_EVTOH" before update
on OH.EVT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_EVT_OH"
	cursor c1_evt_oh (Vcd_evt_oh__type varchar) is
		select 1 
		from OH.CD_EVT_OH 
		where 
		TYPE = Vcd_evt_oh__type and Vcd_evt_oh__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.DSC_OH"
	cursor c2_evt_oh (Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.DSC_OH 
		where 
		NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.CD_EVT_OH" doit exister à la création d'un enfant dans "OH.EVT_OH"
	if :new.CD_EVT_OH__TYPE is not null and seq = 0 then 
		open c1_evt_oh ( :new.CD_EVT_OH__TYPE);
		fetch c1_evt_oh into dummy;
		found := c1_evt_oh%FOUND;
		close c1_evt_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_EVT_OH". Impossible de modifier un enfant dans "OH.EVT_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.DSC_OH" doit exister à la création d'un enfant dans "OH.EVT_OH"
	if :new.DSC_OH__NUM_OH is not null and seq = 0 then 
		open c2_evt_oh ( :new.DSC_OH__NUM_OH);
		fetch c2_evt_oh into dummy;
		found := c2_evt_oh%FOUND;
		close c2_evt_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DSC_OH". Impossible de modifier un enfant dans "OH.EVT_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_CDFAMOH" after update
of FAMILLE
on OH.CD_FAM_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_FAM_OH" dans les enfants "OH.DSC_OH"
	if ((updating('FAMILLE') and :old.FAMILLE != :new.FAMILLE)) then 
		update OH.DSC_OH
		set CD_FAM_OH__FAMILLE = :new.FAMILLE  
		where CD_FAM_OH__FAMILLE = :old.FAMILLE;
	end if;
	--  Modification du code du parent "OH.CD_FAM_OH" dans les enfants "OH.DSC_TEMP_OH"
	if ((updating('FAMILLE') and :old.FAMILLE != :new.FAMILLE)) then 
		update OH.DSC_TEMP_OH
		set CD_FAM_OH__FAMILLE = :new.FAMILLE  
		where CD_FAM_OH__FAMILLE = :old.FAMILLE;
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


create or replace TRIGGER "OH"."TDA_CDFAMOH" after delete
on OH.CD_FAM_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.DSC_OH"
	delete OH.DSC_OH
	where CD_FAM_OH__FAMILLE = :old.FAMILLE;
	
	--  Suppression des enfants dans "OH.DSC_TEMP_OH"
	delete OH.DSC_TEMP_OH
	where CD_FAM_OH__FAMILLE = :old.FAMILLE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_GRPOH" after update
of ID_GRP
on OH.GRP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.GRP_OH" dans les enfants "OH.PRT_OH"
	if ((updating('ID_GRP') and :old.ID_GRP != :new.ID_GRP)) then 
		update OH.PRT_OH
		set GRP_OH__ID_GRP = :new.ID_GRP  
		where GRP_OH__ID_GRP = :old.ID_GRP;
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


create or replace TRIGGER "OH"."TDA_GRPOH" after delete
on OH.GRP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.PRT_OH"
	delete OH.PRT_OH
	where GRP_OH__ID_GRP = :old.ID_GRP;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_HISTONOTEOH" before insert
on OH.HISTO_NOTE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.DSC_OH"
	cursor c1_histo_note_oh(Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.DSC_OH 
		where 
		NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_ORIGIN_OH"
	cursor c2_histo_note_oh(Vcd_origin_oh__origine varchar) is
		select 1 
		from OH.CD_ORIGIN_OH 
		where 
		ORIGINE = Vcd_origin_oh__origine and Vcd_origin_oh__origine is not null;
begin

	
	--  Le parent "OH.DSC_OH" doit exister à la création d'un enfant dans "OH.HISTO_NOTE_OH"
	if :new.DSC_OH__NUM_OH is not null then 
		open c1_histo_note_oh ( :new.DSC_OH__NUM_OH);
		fetch c1_histo_note_oh into dummy;
		found := c1_histo_note_oh%FOUND;
		close c1_histo_note_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DSC_OH". Impossible de créer un enfant dans "OH.HISTO_NOTE_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_ORIGIN_OH" doit exister à la création d'un enfant dans "OH.HISTO_NOTE_OH"
	if :new.CD_ORIGIN_OH__ORIGINE is not null then 
		open c2_histo_note_oh ( :new.CD_ORIGIN_OH__ORIGINE);
		fetch c2_histo_note_oh into dummy;
		found := c2_histo_note_oh%FOUND;
		close c2_histo_note_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_ORIGIN_OH". Impossible de créer un enfant dans "OH.HISTO_NOTE_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_HISTONOTEOH" before update
on OH.HISTO_NOTE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.DSC_OH"
	cursor c1_histo_note_oh (Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.DSC_OH 
		where 
		NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_ORIGIN_OH"
	cursor c2_histo_note_oh (Vcd_origin_oh__origine varchar) is
		select 1 
		from OH.CD_ORIGIN_OH 
		where 
		ORIGINE = Vcd_origin_oh__origine and Vcd_origin_oh__origine is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.DSC_OH" doit exister à la création d'un enfant dans "OH.HISTO_NOTE_OH"
	if :new.DSC_OH__NUM_OH is not null and seq = 0 then 
		open c1_histo_note_oh ( :new.DSC_OH__NUM_OH);
		fetch c1_histo_note_oh into dummy;
		found := c1_histo_note_oh%FOUND;
		close c1_histo_note_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DSC_OH". Impossible de modifier un enfant dans "OH.HISTO_NOTE_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_ORIGIN_OH" doit exister à la création d'un enfant dans "OH.HISTO_NOTE_OH"
	if :new.CD_ORIGIN_OH__ORIGINE is not null and seq = 0 then 
		open c2_histo_note_oh ( :new.CD_ORIGIN_OH__ORIGINE);
		fetch c2_histo_note_oh into dummy;
		found := c2_histo_note_oh%FOUND;
		close c2_histo_note_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_ORIGIN_OH". Impossible de modifier un enfant dans "OH.HISTO_NOTE_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TIB_DSCCAMPOH" before insert
on OH.DSC_CAMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.DSC_OH"
	cursor c1_dsc_camp_oh(Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.DSC_OH 
		where 
		NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CAMP_OH"
	cursor c2_dsc_camp_oh(Vcamp_oh__id_camp varchar) is
		select 1 
		from OH.CAMP_OH 
		where 
		ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null;
begin

	
	--  Le parent "OH.DSC_OH" doit exister à la création d'un enfant dans "OH.DSC_CAMP_OH"
	if :new.DSC_OH__NUM_OH is not null then 
		open c1_dsc_camp_oh ( :new.DSC_OH__NUM_OH);
		fetch c1_dsc_camp_oh into dummy;
		found := c1_dsc_camp_oh%FOUND;
		close c1_dsc_camp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DSC_OH". Impossible de créer un enfant dans "OH.DSC_CAMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CAMP_OH" doit exister à la création d'un enfant dans "OH.DSC_CAMP_OH"
	if :new.CAMP_OH__ID_CAMP is not null then 
		open c2_dsc_camp_oh ( :new.CAMP_OH__ID_CAMP);
		fetch c2_dsc_camp_oh into dummy;
		found := c2_dsc_camp_oh%FOUND;
		close c2_dsc_camp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CAMP_OH". Impossible de créer un enfant dans "OH.DSC_CAMP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_DSCCAMPOH" before update
on OH.DSC_CAMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.DSC_OH"
	cursor c1_dsc_camp_oh (Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.DSC_OH 
		where 
		NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CAMP_OH"
	cursor c2_dsc_camp_oh (Vcamp_oh__id_camp varchar) is
		select 1 
		from OH.CAMP_OH 
		where 
		ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.DSC_OH" doit exister à la création d'un enfant dans "OH.DSC_CAMP_OH"
	if :new.DSC_OH__NUM_OH is not null and seq = 0 then 
		open c1_dsc_camp_oh ( :new.DSC_OH__NUM_OH);
		fetch c1_dsc_camp_oh into dummy;
		found := c1_dsc_camp_oh%FOUND;
		close c1_dsc_camp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DSC_OH". Impossible de modifier un enfant dans "OH.DSC_CAMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CAMP_OH" doit exister à la création d'un enfant dans "OH.DSC_CAMP_OH"
	if :new.CAMP_OH__ID_CAMP is not null and seq = 0 then 
		open c2_dsc_camp_oh ( :new.CAMP_OH__ID_CAMP);
		fetch c2_dsc_camp_oh into dummy;
		found := c2_dsc_camp_oh%FOUND;
		close c2_dsc_camp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CAMP_OH". Impossible de modifier un enfant dans "OH.DSC_CAMP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TIB_INSPECTEUROH" before insert
on OH.INSPECTEUR_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_PRESTA_OH"
	cursor c1_inspecteur_oh(Vcd_presta_oh__prestataire varchar) is
		select 1 
		from OH.CD_PRESTA_OH 
		where 
		PRESTATAIRE = Vcd_presta_oh__prestataire and Vcd_presta_oh__prestataire is not null;
begin

	
	--  Le parent "OH.CD_PRESTA_OH" doit exister à la création d'un enfant dans "OH.INSPECTEUR_OH"
	if :new.CD_PRESTA_OH__PRESTATAIRE is not null then 
		open c1_inspecteur_oh ( :new.CD_PRESTA_OH__PRESTATAIRE);
		fetch c1_inspecteur_oh into dummy;
		found := c1_inspecteur_oh%FOUND;
		close c1_inspecteur_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_PRESTA_OH". Impossible de créer un enfant dans "OH.INSPECTEUR_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_INSPECTEUROH" before update
on OH.INSPECTEUR_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_PRESTA_OH"
	cursor c1_inspecteur_oh (Vcd_presta_oh__prestataire varchar) is
		select 1 
		from OH.CD_PRESTA_OH 
		where 
		PRESTATAIRE = Vcd_presta_oh__prestataire and Vcd_presta_oh__prestataire is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.CD_PRESTA_OH" doit exister à la création d'un enfant dans "OH.INSPECTEUR_OH"
	if :new.CD_PRESTA_OH__PRESTATAIRE is not null and seq = 0 then 
		open c1_inspecteur_oh ( :new.CD_PRESTA_OH__PRESTATAIRE);
		fetch c1_inspecteur_oh into dummy;
		found := c1_inspecteur_oh%FOUND;
		close c1_inspecteur_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_PRESTA_OH". Impossible de modifier un enfant dans "OH.INSPECTEUR_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_INSPECTEUROH" after update
of NOM
on OH.INSPECTEUR_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.INSPECTEUR_OH" dans les enfants "OH.INSP_OH"
	if ((updating('NOM') and :old.NOM != :new.NOM)) then 
		update OH.INSP_OH
		set INSPECTEUR_OH__NOM = :new.NOM  
		where INSPECTEUR_OH__NOM = :old.NOM;
	end if;
	--  Modification du code du parent "OH.INSPECTEUR_OH" dans les enfants "OH.VST_OH"
	if ((updating('NOM') and :old.NOM != :new.NOM)) then 
		update OH.VST_OH
		set INSPECTEUR_OH__NOM = :new.NOM  
		where INSPECTEUR_OH__NOM = :old.NOM;
	end if;
	--  Modification du code du parent "OH.INSPECTEUR_OH" dans les enfants "OH.INSP_TMP_OH"
	if ((updating('NOM') and :old.NOM != :new.NOM)) then 
		update OH.INSP_TMP_OH
		set INSPECTEUR_OH__NOM = :new.NOM  
		where INSPECTEUR_OH__NOM = :old.NOM;
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


create or replace TRIGGER "OH"."TDA_INSPECTEUROH" after delete
on OH.INSPECTEUR_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.INSP_OH"
	delete OH.INSP_OH
	where INSPECTEUR_OH__NOM = :old.NOM;
	
	--  Suppression des enfants dans "OH.VST_OH"
	delete OH.VST_OH
	where INSPECTEUR_OH__NOM = :old.NOM;
	
	--  Suppression des enfants dans "OH.INSP_TMP_OH"
	delete OH.INSP_TMP_OH
	where INSPECTEUR_OH__NOM = :old.NOM;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_INSPOH" before insert
on OH.INSP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CAMP_OH"
	cursor c1_insp_oh(Vcamp_oh__id_camp varchar) is
		select 1 
		from OH.CAMP_OH 
		where 
		ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_ETUDE_OH"
	cursor c2_insp_oh(Vcd_etude_oh__etude varchar) is
		select 1 
		from OH.CD_ETUDE_OH 
		where 
		ETUDE = Vcd_etude_oh__etude and Vcd_etude_oh__etude is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_METEO_OH"
	cursor c3_insp_oh(Vcd_meteo_oh__meteo varchar) is
		select 1 
		from OH.CD_METEO_OH 
		where 
		METEO = Vcd_meteo_oh__meteo and Vcd_meteo_oh__meteo is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.DSC_OH"
	cursor c4_insp_oh(Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.DSC_OH 
		where 
		NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.INSPECTEUR_OH"
	cursor c5_insp_oh(Vinspecteur_oh__nom varchar) is
		select 1 
		from OH.INSPECTEUR_OH 
		where 
		NOM = Vinspecteur_oh__nom and Vinspecteur_oh__nom is not null;
begin

	
	--  Le parent "OH.CAMP_OH" doit exister à la création d'un enfant dans "OH.INSP_OH"
	if :new.CAMP_OH__ID_CAMP is not null then 
		open c1_insp_oh ( :new.CAMP_OH__ID_CAMP);
		fetch c1_insp_oh into dummy;
		found := c1_insp_oh%FOUND;
		close c1_insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CAMP_OH". Impossible de créer un enfant dans "OH.INSP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_ETUDE_OH" doit exister à la création d'un enfant dans "OH.INSP_OH"
	if :new.CD_ETUDE_OH__ETUDE is not null then 
		open c2_insp_oh ( :new.CD_ETUDE_OH__ETUDE);
		fetch c2_insp_oh into dummy;
		found := c2_insp_oh%FOUND;
		close c2_insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_ETUDE_OH". Impossible de créer un enfant dans "OH.INSP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_METEO_OH" doit exister à la création d'un enfant dans "OH.INSP_OH"
	if :new.CD_METEO_OH__METEO is not null then 
		open c3_insp_oh ( :new.CD_METEO_OH__METEO);
		fetch c3_insp_oh into dummy;
		found := c3_insp_oh%FOUND;
		close c3_insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_METEO_OH". Impossible de créer un enfant dans "OH.INSP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.DSC_OH" doit exister à la création d'un enfant dans "OH.INSP_OH"
	if :new.DSC_OH__NUM_OH is not null then 
		open c4_insp_oh ( :new.DSC_OH__NUM_OH);
		fetch c4_insp_oh into dummy;
		found := c4_insp_oh%FOUND;
		close c4_insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DSC_OH". Impossible de créer un enfant dans "OH.INSP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.INSPECTEUR_OH" doit exister à la création d'un enfant dans "OH.INSP_OH"
	if :new.INSPECTEUR_OH__NOM is not null then 
		open c5_insp_oh ( :new.INSPECTEUR_OH__NOM);
		fetch c5_insp_oh into dummy;
		found := c5_insp_oh%FOUND;
		close c5_insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.INSPECTEUR_OH". Impossible de créer un enfant dans "OH.INSP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_INSPOH" before update
on OH.INSP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CAMP_OH"
	cursor c1_insp_oh (Vcamp_oh__id_camp varchar) is
		select 1 
		from OH.CAMP_OH 
		where 
		ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_ETUDE_OH"
	cursor c2_insp_oh (Vcd_etude_oh__etude varchar) is
		select 1 
		from OH.CD_ETUDE_OH 
		where 
		ETUDE = Vcd_etude_oh__etude and Vcd_etude_oh__etude is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_METEO_OH"
	cursor c3_insp_oh (Vcd_meteo_oh__meteo varchar) is
		select 1 
		from OH.CD_METEO_OH 
		where 
		METEO = Vcd_meteo_oh__meteo and Vcd_meteo_oh__meteo is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.DSC_OH"
	cursor c4_insp_oh (Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.DSC_OH 
		where 
		NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.INSPECTEUR_OH"
	cursor c5_insp_oh (Vinspecteur_oh__nom varchar) is
		select 1 
		from OH.INSPECTEUR_OH 
		where 
		NOM = Vinspecteur_oh__nom and Vinspecteur_oh__nom is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.CAMP_OH" doit exister à la création d'un enfant dans "OH.INSP_OH"
	if :new.CAMP_OH__ID_CAMP is not null and seq = 0 then 
		open c1_insp_oh ( :new.CAMP_OH__ID_CAMP);
		fetch c1_insp_oh into dummy;
		found := c1_insp_oh%FOUND;
		close c1_insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CAMP_OH". Impossible de modifier un enfant dans "OH.INSP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_ETUDE_OH" doit exister à la création d'un enfant dans "OH.INSP_OH"
	if :new.CD_ETUDE_OH__ETUDE is not null and seq = 0 then 
		open c2_insp_oh ( :new.CD_ETUDE_OH__ETUDE);
		fetch c2_insp_oh into dummy;
		found := c2_insp_oh%FOUND;
		close c2_insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_ETUDE_OH". Impossible de modifier un enfant dans "OH.INSP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_METEO_OH" doit exister à la création d'un enfant dans "OH.INSP_OH"
	if :new.CD_METEO_OH__METEO is not null and seq = 0 then 
		open c3_insp_oh ( :new.CD_METEO_OH__METEO);
		fetch c3_insp_oh into dummy;
		found := c3_insp_oh%FOUND;
		close c3_insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_METEO_OH". Impossible de modifier un enfant dans "OH.INSP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.DSC_OH" doit exister à la création d'un enfant dans "OH.INSP_OH"
	if :new.DSC_OH__NUM_OH is not null and seq = 0 then 
		open c4_insp_oh ( :new.DSC_OH__NUM_OH);
		fetch c4_insp_oh into dummy;
		found := c4_insp_oh%FOUND;
		close c4_insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DSC_OH". Impossible de modifier un enfant dans "OH.INSP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.INSPECTEUR_OH" doit exister à la création d'un enfant dans "OH.INSP_OH"
	if :new.INSPECTEUR_OH__NOM is not null and seq = 0 then 
		open c5_insp_oh ( :new.INSPECTEUR_OH__NOM);
		fetch c5_insp_oh into dummy;
		found := c5_insp_oh%FOUND;
		close c5_insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.INSPECTEUR_OH". Impossible de modifier un enfant dans "OH.INSP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_INSPOH" after update
of CAMP_OH__ID_CAMP,DSC_OH__NUM_OH
on OH.INSP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.INSP_OH" dans les enfants "OH.ELT_INSP_OH"
	if ((updating('CAMP_OH__ID_CAMP') and :old.CAMP_OH__ID_CAMP != :new.CAMP_OH__ID_CAMP) or 
	(updating('DSC_OH__NUM_OH') and :old.DSC_OH__NUM_OH != :new.DSC_OH__NUM_OH)) then 
		update OH.ELT_INSP_OH
		set CAMP_OH__ID_CAMP = :new.CAMP_OH__ID_CAMP,
		DSC_OH__NUM_OH = :new.DSC_OH__NUM_OH  
		where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
		DSC_OH__NUM_OH = :old.DSC_OH__NUM_OH;
	end if;
	--  Modification du code du parent "OH.INSP_OH" dans les enfants "OH.PHOTO_INSP_OH"
	if ((updating('CAMP_OH__ID_CAMP') and :old.CAMP_OH__ID_CAMP != :new.CAMP_OH__ID_CAMP) or 
	(updating('DSC_OH__NUM_OH') and :old.DSC_OH__NUM_OH != :new.DSC_OH__NUM_OH)) then 
		update OH.PHOTO_INSP_OH
		set CAMP_OH__ID_CAMP = :new.CAMP_OH__ID_CAMP,
		DSC_OH__NUM_OH = :new.DSC_OH__NUM_OH  
		where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
		DSC_OH__NUM_OH = :old.DSC_OH__NUM_OH;
	end if;
	--  Modification du code du parent "OH.INSP_OH" dans les enfants "OH.CD_CONCLUSION__INSP_OH"
	if ((updating('CAMP_OH__ID_CAMP') and :old.CAMP_OH__ID_CAMP != :new.CAMP_OH__ID_CAMP) or 
	(updating('DSC_OH__NUM_OH') and :old.DSC_OH__NUM_OH != :new.DSC_OH__NUM_OH)) then 
		update OH.CD_CONCLUSION__INSP_OH
		set CAMP_OH__ID_CAMP = :new.CAMP_OH__ID_CAMP,
		DSC_OH__NUM_OH = :new.DSC_OH__NUM_OH  
		where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
		DSC_OH__NUM_OH = :old.DSC_OH__NUM_OH;
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


create or replace TRIGGER "OH"."TDA_INSPOH" after delete
on OH.INSP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.ELT_INSP_OH"
	delete OH.ELT_INSP_OH
	where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
	DSC_OH__NUM_OH = :old.DSC_OH__NUM_OH;
	
	--  Suppression des enfants dans "OH.PHOTO_INSP_OH"
	delete OH.PHOTO_INSP_OH
	where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
	DSC_OH__NUM_OH = :old.DSC_OH__NUM_OH;
	
	--  Suppression des enfants dans "OH.CD_CONCLUSION__INSP_OH"
	delete OH.CD_CONCLUSION__INSP_OH
	where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
	DSC_OH__NUM_OH = :old.DSC_OH__NUM_OH;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_INSPTMPOH" before insert
on OH.INSP_TMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_METEO_OH"
	cursor c1_insp_tmp_oh(Vcd_meteo_oh__meteo varchar) is
		select 1 
		from OH.CD_METEO_OH 
		where 
		METEO = Vcd_meteo_oh__meteo and Vcd_meteo_oh__meteo is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_ETUDE_OH"
	cursor c2_insp_tmp_oh(Vcd_etude_oh__etude varchar) is
		select 1 
		from OH.CD_ETUDE_OH 
		where 
		ETUDE = Vcd_etude_oh__etude and Vcd_etude_oh__etude is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.DSC_TEMP_OH"
	cursor c3_insp_tmp_oh(Vcamp_oh__id_camp varchar,
	Vdsc_temp_oh__num_oh varchar) is
		select 1 
		from OH.DSC_TEMP_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		NUM_OH = Vdsc_temp_oh__num_oh and Vdsc_temp_oh__num_oh is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.INSPECTEUR_OH"
	cursor c4_insp_tmp_oh(Vinspecteur_oh__nom varchar) is
		select 1 
		from OH.INSPECTEUR_OH 
		where 
		NOM = Vinspecteur_oh__nom and Vinspecteur_oh__nom is not null;
begin

	
	--  Le parent "OH.CD_METEO_OH" doit exister à la création d'un enfant dans "OH.INSP_TMP_OH"
	if :new.CD_METEO_OH__METEO is not null then 
		open c1_insp_tmp_oh ( :new.CD_METEO_OH__METEO);
		fetch c1_insp_tmp_oh into dummy;
		found := c1_insp_tmp_oh%FOUND;
		close c1_insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_METEO_OH". Impossible de créer un enfant dans "OH.INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_ETUDE_OH" doit exister à la création d'un enfant dans "OH.INSP_TMP_OH"
	if :new.CD_ETUDE_OH__ETUDE is not null then 
		open c2_insp_tmp_oh ( :new.CD_ETUDE_OH__ETUDE);
		fetch c2_insp_tmp_oh into dummy;
		found := c2_insp_tmp_oh%FOUND;
		close c2_insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_ETUDE_OH". Impossible de créer un enfant dans "OH.INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.DSC_TEMP_OH" doit exister à la création d'un enfant dans "OH.INSP_TMP_OH"
	if :new.CAMP_OH__ID_CAMP is not null and 
	:new.DSC_TEMP_OH__NUM_OH is not null then 
		open c3_insp_tmp_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_TEMP_OH__NUM_OH);
		fetch c3_insp_tmp_oh into dummy;
		found := c3_insp_tmp_oh%FOUND;
		close c3_insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DSC_TEMP_OH". Impossible de créer un enfant dans "OH.INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.INSPECTEUR_OH" doit exister à la création d'un enfant dans "OH.INSP_TMP_OH"
	if :new.INSPECTEUR_OH__NOM is not null then 
		open c4_insp_tmp_oh ( :new.INSPECTEUR_OH__NOM);
		fetch c4_insp_tmp_oh into dummy;
		found := c4_insp_tmp_oh%FOUND;
		close c4_insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.INSPECTEUR_OH". Impossible de créer un enfant dans "OH.INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_INSPTMPOH" before update
on OH.INSP_TMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_METEO_OH"
	cursor c1_insp_tmp_oh (Vcd_meteo_oh__meteo varchar) is
		select 1 
		from OH.CD_METEO_OH 
		where 
		METEO = Vcd_meteo_oh__meteo and Vcd_meteo_oh__meteo is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_ETUDE_OH"
	cursor c2_insp_tmp_oh (Vcd_etude_oh__etude varchar) is
		select 1 
		from OH.CD_ETUDE_OH 
		where 
		ETUDE = Vcd_etude_oh__etude and Vcd_etude_oh__etude is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.DSC_TEMP_OH"
	cursor c3_insp_tmp_oh (Vcamp_oh__id_camp varchar,
	Vdsc_temp_oh__num_oh varchar) is
		select 1 
		from OH.DSC_TEMP_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		NUM_OH = Vdsc_temp_oh__num_oh and Vdsc_temp_oh__num_oh is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.INSPECTEUR_OH"
	cursor c4_insp_tmp_oh (Vinspecteur_oh__nom varchar) is
		select 1 
		from OH.INSPECTEUR_OH 
		where 
		NOM = Vinspecteur_oh__nom and Vinspecteur_oh__nom is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.CD_METEO_OH" doit exister à la création d'un enfant dans "OH.INSP_TMP_OH"
	if :new.CD_METEO_OH__METEO is not null and seq = 0 then 
		open c1_insp_tmp_oh ( :new.CD_METEO_OH__METEO);
		fetch c1_insp_tmp_oh into dummy;
		found := c1_insp_tmp_oh%FOUND;
		close c1_insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_METEO_OH". Impossible de modifier un enfant dans "OH.INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_ETUDE_OH" doit exister à la création d'un enfant dans "OH.INSP_TMP_OH"
	if :new.CD_ETUDE_OH__ETUDE is not null and seq = 0 then 
		open c2_insp_tmp_oh ( :new.CD_ETUDE_OH__ETUDE);
		fetch c2_insp_tmp_oh into dummy;
		found := c2_insp_tmp_oh%FOUND;
		close c2_insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_ETUDE_OH". Impossible de modifier un enfant dans "OH.INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.DSC_TEMP_OH" doit exister à la création d'un enfant dans "OH.INSP_TMP_OH"
	if :new.CAMP_OH__ID_CAMP is not null and seq = 0 and 
	:new.DSC_TEMP_OH__NUM_OH is not null and seq = 0 then 
		open c3_insp_tmp_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_TEMP_OH__NUM_OH);
		fetch c3_insp_tmp_oh into dummy;
		found := c3_insp_tmp_oh%FOUND;
		close c3_insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DSC_TEMP_OH". Impossible de modifier un enfant dans "OH.INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.INSPECTEUR_OH" doit exister à la création d'un enfant dans "OH.INSP_TMP_OH"
	if :new.INSPECTEUR_OH__NOM is not null and seq = 0 then 
		open c4_insp_tmp_oh ( :new.INSPECTEUR_OH__NOM);
		fetch c4_insp_tmp_oh into dummy;
		found := c4_insp_tmp_oh%FOUND;
		close c4_insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.INSPECTEUR_OH". Impossible de modifier un enfant dans "OH.INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_INSPTMPOH" after update
of CAMP_OH__ID_CAMP,DSC_TEMP_OH__NUM_OH
on OH.INSP_TMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.INSP_TMP_OH" dans les enfants "OH.ELT_INSP_TMP_OH"
	if ((updating('CAMP_OH__ID_CAMP') and :old.CAMP_OH__ID_CAMP != :new.CAMP_OH__ID_CAMP) or 
	(updating('DSC_TEMP_OH__NUM_OH') and :old.DSC_TEMP_OH__NUM_OH != :new.DSC_TEMP_OH__NUM_OH)) then 
		update OH.ELT_INSP_TMP_OH
		set CAMP_OH__ID_CAMP = :new.CAMP_OH__ID_CAMP,
		DSC_TEMP_OH__NUM_OH = :new.DSC_TEMP_OH__NUM_OH  
		where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
		DSC_TEMP_OH__NUM_OH = :old.DSC_TEMP_OH__NUM_OH;
	end if;
	--  Modification du code du parent "OH.INSP_TMP_OH" dans les enfants "OH.PHOTO_INSP_TMP_OH"
	if ((updating('CAMP_OH__ID_CAMP') and :old.CAMP_OH__ID_CAMP != :new.CAMP_OH__ID_CAMP) or 
	(updating('DSC_TEMP_OH__NUM_OH') and :old.DSC_TEMP_OH__NUM_OH != :new.DSC_TEMP_OH__NUM_OH)) then 
		update OH.PHOTO_INSP_TMP_OH
		set CAMP_OH__ID_CAMP = :new.CAMP_OH__ID_CAMP,
		DSC_TEMP_OH__NUM_OH = :new.DSC_TEMP_OH__NUM_OH  
		where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
		DSC_TEMP_OH__NUM_OH = :old.DSC_TEMP_OH__NUM_OH;
	end if;
	--  Modification du code du parent "OH.INSP_TMP_OH" dans les enfants "OH.CD_CONCLUSION__INSP_TMP_OH"
	if ((updating('CAMP_OH__ID_CAMP') and :old.CAMP_OH__ID_CAMP != :new.CAMP_OH__ID_CAMP) or 
	(updating('DSC_TEMP_OH__NUM_OH') and :old.DSC_TEMP_OH__NUM_OH != :new.DSC_TEMP_OH__NUM_OH)) then 
		update OH.CD_CONCLUSION__INSP_TMP_OH
		set CAMP_OH__ID_CAMP = :new.CAMP_OH__ID_CAMP,
		DSC_TEMP_OH__NUM_OH = :new.DSC_TEMP_OH__NUM_OH  
		where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
		DSC_TEMP_OH__NUM_OH = :old.DSC_TEMP_OH__NUM_OH;
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


create or replace TRIGGER "OH"."TDA_INSPTMPOH" after delete
on OH.INSP_TMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.ELT_INSP_TMP_OH"
	delete OH.ELT_INSP_TMP_OH
	where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
	DSC_TEMP_OH__NUM_OH = :old.DSC_TEMP_OH__NUM_OH;
	
	--  Suppression des enfants dans "OH.PHOTO_INSP_TMP_OH"
	delete OH.PHOTO_INSP_TMP_OH
	where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
	DSC_TEMP_OH__NUM_OH = :old.DSC_TEMP_OH__NUM_OH;
	
	--  Suppression des enfants dans "OH.CD_CONCLUSION__INSP_TMP_OH"
	delete OH.CD_CONCLUSION__INSP_TMP_OH
	where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
	DSC_TEMP_OH__NUM_OH = :old.DSC_TEMP_OH__NUM_OH;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_CDLIGNEOH" before insert
on OH.CD_LIGNE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_CHAPITRE_OH"
	cursor c1_cd_ligne_oh(Vcd_chapitre_oh__id_chap number) is
		select 1 
		from OH.CD_CHAPITRE_OH 
		where 
		ID_CHAP = Vcd_chapitre_oh__id_chap and Vcd_chapitre_oh__id_chap is not null;
begin

	
	--  Le parent "OH.CD_CHAPITRE_OH" doit exister à la création d'un enfant dans "OH.CD_LIGNE_OH"
	if :new.CD_CHAPITRE_OH__ID_CHAP is not null then 
		open c1_cd_ligne_oh ( :new.CD_CHAPITRE_OH__ID_CHAP);
		fetch c1_cd_ligne_oh into dummy;
		found := c1_cd_ligne_oh%FOUND;
		close c1_cd_ligne_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_CHAPITRE_OH". Impossible de créer un enfant dans "OH.CD_LIGNE_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_CDLIGNEOH" before update
on OH.CD_LIGNE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_CHAPITRE_OH"
	cursor c1_cd_ligne_oh (Vcd_chapitre_oh__id_chap number) is
		select 1 
		from OH.CD_CHAPITRE_OH 
		where 
		ID_CHAP = Vcd_chapitre_oh__id_chap and Vcd_chapitre_oh__id_chap is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.CD_CHAPITRE_OH" doit exister à la création d'un enfant dans "OH.CD_LIGNE_OH"
	if :new.CD_CHAPITRE_OH__ID_CHAP is not null and seq = 0 then 
		open c1_cd_ligne_oh ( :new.CD_CHAPITRE_OH__ID_CHAP);
		fetch c1_cd_ligne_oh into dummy;
		found := c1_cd_ligne_oh%FOUND;
		close c1_cd_ligne_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_CHAPITRE_OH". Impossible de modifier un enfant dans "OH.CD_LIGNE_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_CDLIGNEOH" after update
of CD_CHAPITRE_OH__ID_CHAP,ID_LIGNE
on OH.CD_LIGNE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_LIGNE_OH" dans les enfants "OH.SPRT_VST_OH"
	if ((updating('CD_CHAPITRE_OH__ID_CHAP') and :old.CD_CHAPITRE_OH__ID_CHAP != :new.CD_CHAPITRE_OH__ID_CHAP) or 
	(updating('ID_LIGNE') and :old.ID_LIGNE != :new.ID_LIGNE)) then 
		update OH.SPRT_VST_OH
		set CD_CHAPITRE_OH__ID_CHAP = :new.CD_CHAPITRE_OH__ID_CHAP,
		CD_LIGNE_OH__ID_LIGNE = :new.ID_LIGNE  
		where CD_CHAPITRE_OH__ID_CHAP = :old.CD_CHAPITRE_OH__ID_CHAP and 
		CD_LIGNE_OH__ID_LIGNE = :old.ID_LIGNE;
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


create or replace TRIGGER "OH"."TDA_CDLIGNEOH" after delete
on OH.CD_LIGNE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.SPRT_VST_OH"
	delete OH.SPRT_VST_OH
	where CD_CHAPITRE_OH__ID_CHAP = :old.CD_CHAPITRE_OH__ID_CHAP and 
	CD_LIGNE_OH__ID_LIGNE = :old.ID_LIGNE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDMOOH" after update
of MO
on OH.CD_MO_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_MO_OH" dans les enfants "OH.DSC_OH"
	if ((updating('MO') and :old.MO != :new.MO)) then 
		update OH.DSC_OH
		set CD_MO_OH__MO = :new.MO  
		where CD_MO_OH__MO = :old.MO;
	end if;
	--  Modification du code du parent "OH.CD_MO_OH" dans les enfants "OH.DSC_TEMP_OH"
	if ((updating('MO') and :old.MO != :new.MO)) then 
		update OH.DSC_TEMP_OH
		set CD_MO_OH__MO = :new.MO  
		where CD_MO_OH__MO = :old.MO;
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


create or replace TRIGGER "OH"."TDA_CDMOOH" after delete
on OH.CD_MO_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.DSC_OH"
	delete OH.DSC_OH
	where CD_MO_OH__MO = :old.MO;
	
	--  Suppression des enfants dans "OH.DSC_TEMP_OH"
	delete OH.DSC_TEMP_OH
	where CD_MO_OH__MO = :old.MO;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDMATOH" after update
of CODE
on OH.CD_MAT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_MAT_OH" dans les enfants "OH.DSC_OH"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update OH.DSC_OH
		set CD_MAT_OH__CODE = :new.CODE  
		where CD_MAT_OH__CODE = :old.CODE;
	end if;
	--  Modification du code du parent "OH.CD_MAT_OH" dans les enfants "OH.DSC_TEMP_OH"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update OH.DSC_TEMP_OH
		set CD_MAT_OH__CODE = :new.CODE  
		where CD_MAT_OH__CODE = :old.CODE;
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


create or replace TRIGGER "OH"."TDA_CDMATOH" after delete
on OH.CD_MAT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.DSC_OH"
	delete OH.DSC_OH
	where CD_MAT_OH__CODE = :old.CODE;
	
	--  Suppression des enfants dans "OH.DSC_TEMP_OH"
	delete OH.DSC_TEMP_OH
	where CD_MAT_OH__CODE = :old.CODE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDMETEOOH" after update
of METEO
on OH.CD_METEO_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_METEO_OH" dans les enfants "OH.INSP_OH"
	if ((updating('METEO') and :old.METEO != :new.METEO)) then 
		update OH.INSP_OH
		set CD_METEO_OH__METEO = :new.METEO  
		where CD_METEO_OH__METEO = :old.METEO;
	end if;
	--  Modification du code du parent "OH.CD_METEO_OH" dans les enfants "OH.INSP_TMP_OH"
	if ((updating('METEO') and :old.METEO != :new.METEO)) then 
		update OH.INSP_TMP_OH
		set CD_METEO_OH__METEO = :new.METEO  
		where CD_METEO_OH__METEO = :old.METEO;
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


create or replace TRIGGER "OH"."TDA_CDMETEOOH" after delete
on OH.CD_METEO_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.INSP_OH"
	delete OH.INSP_OH
	where CD_METEO_OH__METEO = :old.METEO;
	
	--  Suppression des enfants dans "OH.INSP_TMP_OH"
	delete OH.INSP_TMP_OH
	where CD_METEO_OH__METEO = :old.METEO;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_NATURETRAVOH" before insert
on OH.NATURE_TRAV_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_TRAVAUX_OH"
	cursor c1_nature_trav_oh(Vcd_travaux_oh__code varchar) is
		select 1 
		from OH.CD_TRAVAUX_OH 
		where 
		CODE = Vcd_travaux_oh__code and Vcd_travaux_oh__code is not null;
begin

	
	--  Le parent "OH.CD_TRAVAUX_OH" doit exister à la création d'un enfant dans "OH.NATURE_TRAV_OH"
	if :new.CD_TRAVAUX_OH__CODE is not null then 
		open c1_nature_trav_oh ( :new.CD_TRAVAUX_OH__CODE);
		fetch c1_nature_trav_oh into dummy;
		found := c1_nature_trav_oh%FOUND;
		close c1_nature_trav_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_TRAVAUX_OH". Impossible de créer un enfant dans "OH.NATURE_TRAV_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_NATURETRAVOH" before update
on OH.NATURE_TRAV_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_TRAVAUX_OH"
	cursor c1_nature_trav_oh (Vcd_travaux_oh__code varchar) is
		select 1 
		from OH.CD_TRAVAUX_OH 
		where 
		CODE = Vcd_travaux_oh__code and Vcd_travaux_oh__code is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.CD_TRAVAUX_OH" doit exister à la création d'un enfant dans "OH.NATURE_TRAV_OH"
	if :new.CD_TRAVAUX_OH__CODE is not null and seq = 0 then 
		open c1_nature_trav_oh ( :new.CD_TRAVAUX_OH__CODE);
		fetch c1_nature_trav_oh into dummy;
		found := c1_nature_trav_oh%FOUND;
		close c1_nature_trav_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_TRAVAUX_OH". Impossible de modifier un enfant dans "OH.NATURE_TRAV_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_NATURETRAVOH" after update
of CD_TRAVAUX_OH__CODE,NATURE
on OH.NATURE_TRAV_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.NATURE_TRAV_OH" dans les enfants "OH.TRAVAUX_OH"
	if ((updating('CD_TRAVAUX_OH__CODE') and :old.CD_TRAVAUX_OH__CODE != :new.CD_TRAVAUX_OH__CODE) or 
	(updating('NATURE') and :old.NATURE != :new.NATURE)) then 
		update OH.TRAVAUX_OH
		set CD_TRAVAUX_OH__CODE = :new.CD_TRAVAUX_OH__CODE,
		NATURE_TRAV_OH__NATURE = :new.NATURE  
		where CD_TRAVAUX_OH__CODE = :old.CD_TRAVAUX_OH__CODE and 
		NATURE_TRAV_OH__NATURE = :old.NATURE;
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


create or replace TRIGGER "OH"."TDA_NATURETRAVOH" after delete
on OH.NATURE_TRAV_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.TRAVAUX_OH"
	delete OH.TRAVAUX_OH
	where CD_TRAVAUX_OH__CODE = :old.CD_TRAVAUX_OH__CODE and 
	NATURE_TRAV_OH__NATURE = :old.NATURE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDNOMEAUOH" after update
of NOM
on OH.CD_NOM_EAU_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_NOM_EAU_OH" dans les enfants "OH.DSC_OH"
	if ((updating('NOM') and :old.NOM != :new.NOM)) then 
		update OH.DSC_OH
		set CD_NOM_EAU_OH__NOM = :new.NOM  
		where CD_NOM_EAU_OH__NOM = :old.NOM;
	end if;
	--  Modification du code du parent "OH.CD_NOM_EAU_OH" dans les enfants "OH.DSC_TEMP_OH"
	if ((updating('NOM') and :old.NOM != :new.NOM)) then 
		update OH.DSC_TEMP_OH
		set CD_NOM_EAU_OH__NOM = :new.NOM  
		where CD_NOM_EAU_OH__NOM = :old.NOM;
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


create or replace TRIGGER "OH"."TDA_CDNOMEAUOH" after delete
on OH.CD_NOM_EAU_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.DSC_OH"
	delete OH.DSC_OH
	where CD_NOM_EAU_OH__NOM = :old.NOM;
	
	--  Suppression des enfants dans "OH.DSC_TEMP_OH"
	delete OH.DSC_TEMP_OH
	where CD_NOM_EAU_OH__NOM = :old.NOM;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDORIGINOH" after update
of ORIGINE
on OH.CD_ORIGIN_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_ORIGIN_OH" dans les enfants "OH.HISTO_NOTE_OH"
	if ((updating('ORIGINE') and :old.ORIGINE != :new.ORIGINE)) then 
		update OH.HISTO_NOTE_OH
		set CD_ORIGIN_OH__ORIGINE = :new.ORIGINE  
		where CD_ORIGIN_OH__ORIGINE = :old.ORIGINE;
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


create or replace TRIGGER "OH"."TDA_CDORIGINOH" after delete
on OH.CD_ORIGIN_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.HISTO_NOTE_OH"
	delete OH.HISTO_NOTE_OH
	where CD_ORIGIN_OH__ORIGINE = :old.ORIGINE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_DSCOH" before insert
on OH.DSC_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_FAM_OH"
	cursor c1_dsc_oh(Vcd_fam_oh__famille varchar) is
		select 1 
		from OH.CD_FAM_OH 
		where 
		FAMILLE = Vcd_fam_oh__famille and Vcd_fam_oh__famille is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_ENTP_OH"
	cursor c2_dsc_oh(Vcd_entp_oh__entreprise varchar) is
		select 1 
		from OH.CD_ENTP_OH 
		where 
		ENTREPRISE = Vcd_entp_oh__entreprise and Vcd_entp_oh__entreprise is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_MAT_OH"
	cursor c3_dsc_oh(Vcd_mat_oh__code varchar) is
		select 1 
		from OH.CD_MAT_OH 
		where 
		CODE = Vcd_mat_oh__code and Vcd_mat_oh__code is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_EAU_OH"
	cursor c4_dsc_oh(Vcd_eau_oh__eau varchar) is
		select 1 
		from OH.CD_EAU_OH 
		where 
		EAU = Vcd_eau_oh__eau and Vcd_eau_oh__eau is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_OUV_OH"
	cursor c5_dsc_oh(Vcd_ouv_oh__ouv varchar) is
		select 1 
		from OH.CD_OUV_OH 
		where 
		OUV = Vcd_ouv_oh__ouv and Vcd_ouv_oh__ouv is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_ECOUL_OH"
	cursor c6_dsc_oh(Vcd_ecoul_oh__ecoul varchar) is
		select 1 
		from OH.CD_ECOUL_OH 
		where 
		ECOUL = Vcd_ecoul_oh__ecoul and Vcd_ecoul_oh__ecoul is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_TYPE_OH"
	cursor c7_dsc_oh(Vcd_type_oh__type varchar) is
		select 1 
		from OH.CD_TYPE_OH 
		where 
		TYPE = Vcd_type_oh__type and Vcd_type_oh__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_PRO_AV_OH"
	cursor c8_dsc_oh(Vcd_pro_av_oh__protect varchar) is
		select 1 
		from OH.CD_PRO_AV_OH 
		where 
		PROTECT = Vcd_pro_av_oh__protect and Vcd_pro_av_oh__protect is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_PRO_AM_OH"
	cursor c9_dsc_oh(Vcd_pro_am_oh__protect varchar) is
		select 1 
		from OH.CD_PRO_AM_OH 
		where 
		PROTECT = Vcd_pro_am_oh__protect and Vcd_pro_am_oh__protect is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_SOUS_TYPE_OH"
	cursor c10_dsc_oh(Vcd_sous_type_oh__sous_type varchar) is
		select 1 
		from OH.CD_SOUS_TYPE_OH 
		where 
		SOUS_TYPE = Vcd_sous_type_oh__sous_type and Vcd_sous_type_oh__sous_type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_EXT_OH"
	cursor c11_dsc_oh(Vcd_ext_oh__type varchar) is
		select 1 
		from OH.CD_EXT_OH 
		where 
		TYPE = Vcd_ext_oh__type and Vcd_ext_oh__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_QUALITE_OH"
	cursor c12_dsc_oh(Vcd_qualite_oh__qualite varchar) is
		select 1 
		from OH.CD_QUALITE_OH 
		where 
		QUALITE = Vcd_qualite_oh__qualite and Vcd_qualite_oh__qualite is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_NOM_EAU_OH"
	cursor c13_dsc_oh(Vcd_nom_eau_oh__nom varchar) is
		select 1 
		from OH.CD_NOM_EAU_OH 
		where 
		NOM = Vcd_nom_eau_oh__nom and Vcd_nom_eau_oh__nom is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_TETE_AM_OH"
	cursor c14_dsc_oh(Vcd_tete_am_oh__tete_am varchar) is
		select 1 
		from OH.CD_TETE_AM_OH 
		where 
		TETE_AM = Vcd_tete_am_oh__tete_am and Vcd_tete_am_oh__tete_am is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_TETE_AV_OH"
	cursor c15_dsc_oh(Vcd_tete_av_oh__tete_av varchar) is
		select 1 
		from OH.CD_TETE_AV_OH 
		where 
		TETE_AV = Vcd_tete_av_oh__tete_av and Vcd_tete_av_oh__tete_av is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_MO_OH"
	cursor c16_dsc_oh(Vcd_mo_oh__mo varchar) is
		select 1 
		from OH.CD_MO_OH 
		where 
		MO = Vcd_mo_oh__mo and Vcd_mo_oh__mo is not null;
begin

	
	--  Le parent "OH.CD_FAM_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_FAM_OH__FAMILLE is not null then 
		open c1_dsc_oh ( :new.CD_FAM_OH__FAMILLE);
		fetch c1_dsc_oh into dummy;
		found := c1_dsc_oh%FOUND;
		close c1_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_FAM_OH". Impossible de créer un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_ENTP_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_ENTP_OH__ENTREPRISE is not null then 
		open c2_dsc_oh ( :new.CD_ENTP_OH__ENTREPRISE);
		fetch c2_dsc_oh into dummy;
		found := c2_dsc_oh%FOUND;
		close c2_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_ENTP_OH". Impossible de créer un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_MAT_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_MAT_OH__CODE is not null then 
		open c3_dsc_oh ( :new.CD_MAT_OH__CODE);
		fetch c3_dsc_oh into dummy;
		found := c3_dsc_oh%FOUND;
		close c3_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_MAT_OH". Impossible de créer un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_EAU_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_EAU_OH__EAU is not null then 
		open c4_dsc_oh ( :new.CD_EAU_OH__EAU);
		fetch c4_dsc_oh into dummy;
		found := c4_dsc_oh%FOUND;
		close c4_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_EAU_OH". Impossible de créer un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_OUV_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_OUV_OH__OUV is not null then 
		open c5_dsc_oh ( :new.CD_OUV_OH__OUV);
		fetch c5_dsc_oh into dummy;
		found := c5_dsc_oh%FOUND;
		close c5_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_OUV_OH". Impossible de créer un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_ECOUL_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_ECOUL_OH__ECOUL is not null then 
		open c6_dsc_oh ( :new.CD_ECOUL_OH__ECOUL);
		fetch c6_dsc_oh into dummy;
		found := c6_dsc_oh%FOUND;
		close c6_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_ECOUL_OH". Impossible de créer un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_TYPE_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_TYPE_OH__TYPE is not null then 
		open c7_dsc_oh ( :new.CD_TYPE_OH__TYPE);
		fetch c7_dsc_oh into dummy;
		found := c7_dsc_oh%FOUND;
		close c7_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_TYPE_OH". Impossible de créer un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_PRO_AV_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_PRO_AV_OH__PROTECT is not null then 
		open c8_dsc_oh ( :new.CD_PRO_AV_OH__PROTECT);
		fetch c8_dsc_oh into dummy;
		found := c8_dsc_oh%FOUND;
		close c8_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_PRO_AV_OH". Impossible de créer un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_PRO_AM_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_PRO_AM_OH__PROTECT is not null then 
		open c9_dsc_oh ( :new.CD_PRO_AM_OH__PROTECT);
		fetch c9_dsc_oh into dummy;
		found := c9_dsc_oh%FOUND;
		close c9_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_PRO_AM_OH". Impossible de créer un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_SOUS_TYPE_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_SOUS_TYPE_OH__SOUS_TYPE is not null then 
		open c10_dsc_oh ( :new.CD_SOUS_TYPE_OH__SOUS_TYPE);
		fetch c10_dsc_oh into dummy;
		found := c10_dsc_oh%FOUND;
		close c10_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_SOUS_TYPE_OH". Impossible de créer un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_EXT_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_EXT_OH__TYPE is not null then 
		open c11_dsc_oh ( :new.CD_EXT_OH__TYPE);
		fetch c11_dsc_oh into dummy;
		found := c11_dsc_oh%FOUND;
		close c11_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_EXT_OH". Impossible de créer un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_QUALITE_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_QUALITE_OH__QUALITE is not null then 
		open c12_dsc_oh ( :new.CD_QUALITE_OH__QUALITE);
		fetch c12_dsc_oh into dummy;
		found := c12_dsc_oh%FOUND;
		close c12_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_QUALITE_OH". Impossible de créer un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_NOM_EAU_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_NOM_EAU_OH__NOM is not null then 
		open c13_dsc_oh ( :new.CD_NOM_EAU_OH__NOM);
		fetch c13_dsc_oh into dummy;
		found := c13_dsc_oh%FOUND;
		close c13_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_NOM_EAU_OH". Impossible de créer un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_TETE_AM_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_TETE_AM_OH__TETE_AM is not null then 
		open c14_dsc_oh ( :new.CD_TETE_AM_OH__TETE_AM);
		fetch c14_dsc_oh into dummy;
		found := c14_dsc_oh%FOUND;
		close c14_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_TETE_AM_OH". Impossible de créer un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_TETE_AV_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_TETE_AV_OH__TETE_AV is not null then 
		open c15_dsc_oh ( :new.CD_TETE_AV_OH__TETE_AV);
		fetch c15_dsc_oh into dummy;
		found := c15_dsc_oh%FOUND;
		close c15_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_TETE_AV_OH". Impossible de créer un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_MO_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_MO_OH__MO is not null then 
		open c16_dsc_oh ( :new.CD_MO_OH__MO);
		fetch c16_dsc_oh into dummy;
		found := c16_dsc_oh%FOUND;
		close c16_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_MO_OH". Impossible de créer un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_DSCOH" before update
on OH.DSC_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_FAM_OH"
	cursor c1_dsc_oh (Vcd_fam_oh__famille varchar) is
		select 1 
		from OH.CD_FAM_OH 
		where 
		FAMILLE = Vcd_fam_oh__famille and Vcd_fam_oh__famille is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_ENTP_OH"
	cursor c2_dsc_oh (Vcd_entp_oh__entreprise varchar) is
		select 1 
		from OH.CD_ENTP_OH 
		where 
		ENTREPRISE = Vcd_entp_oh__entreprise and Vcd_entp_oh__entreprise is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_MAT_OH"
	cursor c3_dsc_oh (Vcd_mat_oh__code varchar) is
		select 1 
		from OH.CD_MAT_OH 
		where 
		CODE = Vcd_mat_oh__code and Vcd_mat_oh__code is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_EAU_OH"
	cursor c4_dsc_oh (Vcd_eau_oh__eau varchar) is
		select 1 
		from OH.CD_EAU_OH 
		where 
		EAU = Vcd_eau_oh__eau and Vcd_eau_oh__eau is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_OUV_OH"
	cursor c5_dsc_oh (Vcd_ouv_oh__ouv varchar) is
		select 1 
		from OH.CD_OUV_OH 
		where 
		OUV = Vcd_ouv_oh__ouv and Vcd_ouv_oh__ouv is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_ECOUL_OH"
	cursor c6_dsc_oh (Vcd_ecoul_oh__ecoul varchar) is
		select 1 
		from OH.CD_ECOUL_OH 
		where 
		ECOUL = Vcd_ecoul_oh__ecoul and Vcd_ecoul_oh__ecoul is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_TYPE_OH"
	cursor c7_dsc_oh (Vcd_type_oh__type varchar) is
		select 1 
		from OH.CD_TYPE_OH 
		where 
		TYPE = Vcd_type_oh__type and Vcd_type_oh__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_PRO_AV_OH"
	cursor c8_dsc_oh (Vcd_pro_av_oh__protect varchar) is
		select 1 
		from OH.CD_PRO_AV_OH 
		where 
		PROTECT = Vcd_pro_av_oh__protect and Vcd_pro_av_oh__protect is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_PRO_AM_OH"
	cursor c9_dsc_oh (Vcd_pro_am_oh__protect varchar) is
		select 1 
		from OH.CD_PRO_AM_OH 
		where 
		PROTECT = Vcd_pro_am_oh__protect and Vcd_pro_am_oh__protect is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_SOUS_TYPE_OH"
	cursor c10_dsc_oh (Vcd_sous_type_oh__sous_type varchar) is
		select 1 
		from OH.CD_SOUS_TYPE_OH 
		where 
		SOUS_TYPE = Vcd_sous_type_oh__sous_type and Vcd_sous_type_oh__sous_type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_EXT_OH"
	cursor c11_dsc_oh (Vcd_ext_oh__type varchar) is
		select 1 
		from OH.CD_EXT_OH 
		where 
		TYPE = Vcd_ext_oh__type and Vcd_ext_oh__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_QUALITE_OH"
	cursor c12_dsc_oh (Vcd_qualite_oh__qualite varchar) is
		select 1 
		from OH.CD_QUALITE_OH 
		where 
		QUALITE = Vcd_qualite_oh__qualite and Vcd_qualite_oh__qualite is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_NOM_EAU_OH"
	cursor c13_dsc_oh (Vcd_nom_eau_oh__nom varchar) is
		select 1 
		from OH.CD_NOM_EAU_OH 
		where 
		NOM = Vcd_nom_eau_oh__nom and Vcd_nom_eau_oh__nom is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_TETE_AM_OH"
	cursor c14_dsc_oh (Vcd_tete_am_oh__tete_am varchar) is
		select 1 
		from OH.CD_TETE_AM_OH 
		where 
		TETE_AM = Vcd_tete_am_oh__tete_am and Vcd_tete_am_oh__tete_am is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_TETE_AV_OH"
	cursor c15_dsc_oh (Vcd_tete_av_oh__tete_av varchar) is
		select 1 
		from OH.CD_TETE_AV_OH 
		where 
		TETE_AV = Vcd_tete_av_oh__tete_av and Vcd_tete_av_oh__tete_av is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_MO_OH"
	cursor c16_dsc_oh (Vcd_mo_oh__mo varchar) is
		select 1 
		from OH.CD_MO_OH 
		where 
		MO = Vcd_mo_oh__mo and Vcd_mo_oh__mo is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.CD_FAM_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_FAM_OH__FAMILLE is not null and seq = 0 then 
		open c1_dsc_oh ( :new.CD_FAM_OH__FAMILLE);
		fetch c1_dsc_oh into dummy;
		found := c1_dsc_oh%FOUND;
		close c1_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_FAM_OH". Impossible de modifier un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_ENTP_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_ENTP_OH__ENTREPRISE is not null and seq = 0 then 
		open c2_dsc_oh ( :new.CD_ENTP_OH__ENTREPRISE);
		fetch c2_dsc_oh into dummy;
		found := c2_dsc_oh%FOUND;
		close c2_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_ENTP_OH". Impossible de modifier un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_MAT_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_MAT_OH__CODE is not null and seq = 0 then 
		open c3_dsc_oh ( :new.CD_MAT_OH__CODE);
		fetch c3_dsc_oh into dummy;
		found := c3_dsc_oh%FOUND;
		close c3_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_MAT_OH". Impossible de modifier un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_EAU_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_EAU_OH__EAU is not null and seq = 0 then 
		open c4_dsc_oh ( :new.CD_EAU_OH__EAU);
		fetch c4_dsc_oh into dummy;
		found := c4_dsc_oh%FOUND;
		close c4_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_EAU_OH". Impossible de modifier un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_OUV_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_OUV_OH__OUV is not null and seq = 0 then 
		open c5_dsc_oh ( :new.CD_OUV_OH__OUV);
		fetch c5_dsc_oh into dummy;
		found := c5_dsc_oh%FOUND;
		close c5_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_OUV_OH". Impossible de modifier un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_ECOUL_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_ECOUL_OH__ECOUL is not null and seq = 0 then 
		open c6_dsc_oh ( :new.CD_ECOUL_OH__ECOUL);
		fetch c6_dsc_oh into dummy;
		found := c6_dsc_oh%FOUND;
		close c6_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_ECOUL_OH". Impossible de modifier un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_TYPE_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_TYPE_OH__TYPE is not null and seq = 0 then 
		open c7_dsc_oh ( :new.CD_TYPE_OH__TYPE);
		fetch c7_dsc_oh into dummy;
		found := c7_dsc_oh%FOUND;
		close c7_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_TYPE_OH". Impossible de modifier un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_PRO_AV_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_PRO_AV_OH__PROTECT is not null and seq = 0 then 
		open c8_dsc_oh ( :new.CD_PRO_AV_OH__PROTECT);
		fetch c8_dsc_oh into dummy;
		found := c8_dsc_oh%FOUND;
		close c8_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_PRO_AV_OH". Impossible de modifier un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_PRO_AM_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_PRO_AM_OH__PROTECT is not null and seq = 0 then 
		open c9_dsc_oh ( :new.CD_PRO_AM_OH__PROTECT);
		fetch c9_dsc_oh into dummy;
		found := c9_dsc_oh%FOUND;
		close c9_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_PRO_AM_OH". Impossible de modifier un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_SOUS_TYPE_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_SOUS_TYPE_OH__SOUS_TYPE is not null and seq = 0 then 
		open c10_dsc_oh ( :new.CD_SOUS_TYPE_OH__SOUS_TYPE);
		fetch c10_dsc_oh into dummy;
		found := c10_dsc_oh%FOUND;
		close c10_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_SOUS_TYPE_OH". Impossible de modifier un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_EXT_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_EXT_OH__TYPE is not null and seq = 0 then 
		open c11_dsc_oh ( :new.CD_EXT_OH__TYPE);
		fetch c11_dsc_oh into dummy;
		found := c11_dsc_oh%FOUND;
		close c11_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_EXT_OH". Impossible de modifier un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_QUALITE_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_QUALITE_OH__QUALITE is not null and seq = 0 then 
		open c12_dsc_oh ( :new.CD_QUALITE_OH__QUALITE);
		fetch c12_dsc_oh into dummy;
		found := c12_dsc_oh%FOUND;
		close c12_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_QUALITE_OH". Impossible de modifier un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_NOM_EAU_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_NOM_EAU_OH__NOM is not null and seq = 0 then 
		open c13_dsc_oh ( :new.CD_NOM_EAU_OH__NOM);
		fetch c13_dsc_oh into dummy;
		found := c13_dsc_oh%FOUND;
		close c13_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_NOM_EAU_OH". Impossible de modifier un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_TETE_AM_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_TETE_AM_OH__TETE_AM is not null and seq = 0 then 
		open c14_dsc_oh ( :new.CD_TETE_AM_OH__TETE_AM);
		fetch c14_dsc_oh into dummy;
		found := c14_dsc_oh%FOUND;
		close c14_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_TETE_AM_OH". Impossible de modifier un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_TETE_AV_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_TETE_AV_OH__TETE_AV is not null and seq = 0 then 
		open c15_dsc_oh ( :new.CD_TETE_AV_OH__TETE_AV);
		fetch c15_dsc_oh into dummy;
		found := c15_dsc_oh%FOUND;
		close c15_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_TETE_AV_OH". Impossible de modifier un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_MO_OH" doit exister à la création d'un enfant dans "OH.DSC_OH"
	if :new.CD_MO_OH__MO is not null and seq = 0 then 
		open c16_dsc_oh ( :new.CD_MO_OH__MO);
		fetch c16_dsc_oh into dummy;
		found := c16_dsc_oh%FOUND;
		close c16_dsc_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_MO_OH". Impossible de modifier un enfant dans "OH.DSC_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_DSCOH" after update
of NUM_OH
on OH.DSC_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.DSC_OH" dans les enfants "OH.TRAVAUX_OH"
	if ((updating('NUM_OH') and :old.NUM_OH != :new.NUM_OH)) then 
		update OH.TRAVAUX_OH
		set DSC_OH__NUM_OH = :new.NUM_OH  
		where DSC_OH__NUM_OH = :old.NUM_OH;
	end if;
	--  Modification du code du parent "OH.DSC_OH" dans les enfants "OH.PREVISION_OH"
	if ((updating('NUM_OH') and :old.NUM_OH != :new.NUM_OH)) then 
		update OH.PREVISION_OH
		set DSC_OH__NUM_OH = :new.NUM_OH  
		where DSC_OH__NUM_OH = :old.NUM_OH;
	end if;
	--  Modification du code du parent "OH.DSC_OH" dans les enfants "OH.VST_OH"
	if ((updating('NUM_OH') and :old.NUM_OH != :new.NUM_OH)) then 
		update OH.VST_OH
		set DSC_OH__NUM_OH = :new.NUM_OH  
		where DSC_OH__NUM_OH = :old.NUM_OH;
	end if;
	--  Modification du code du parent "OH.DSC_OH" dans les enfants "OH.INSP_OH"
	if ((updating('NUM_OH') and :old.NUM_OH != :new.NUM_OH)) then 
		update OH.INSP_OH
		set DSC_OH__NUM_OH = :new.NUM_OH  
		where DSC_OH__NUM_OH = :old.NUM_OH;
	end if;
	--  Modification du code du parent "OH.DSC_OH" dans les enfants "OH.HISTO_NOTE_OH"
	if ((updating('NUM_OH') and :old.NUM_OH != :new.NUM_OH)) then 
		update OH.HISTO_NOTE_OH
		set DSC_OH__NUM_OH = :new.NUM_OH  
		where DSC_OH__NUM_OH = :old.NUM_OH;
	end if;
	--  Modification du code du parent "OH.DSC_OH" dans les enfants "OH.EVT_OH"
	if ((updating('NUM_OH') and :old.NUM_OH != :new.NUM_OH)) then 
		update OH.EVT_OH
		set DSC_OH__NUM_OH = :new.NUM_OH  
		where DSC_OH__NUM_OH = :old.NUM_OH;
	end if;
	--  Modification du code du parent "OH.DSC_OH" dans les enfants "OH.DSC_TEMP_OH"
	if ((updating('NUM_OH') and :old.NUM_OH != :new.NUM_OH)) then 
		update OH.DSC_TEMP_OH
		set DSC_OH__NUM_OH = :new.NUM_OH  
		where DSC_OH__NUM_OH = :old.NUM_OH;
	end if;
	--  Modification du code du parent "OH.DSC_OH" dans les enfants "OH.DSC_CAMP_OH"
	if ((updating('NUM_OH') and :old.NUM_OH != :new.NUM_OH)) then 
		update OH.DSC_CAMP_OH
		set DSC_OH__NUM_OH = :new.NUM_OH  
		where DSC_OH__NUM_OH = :old.NUM_OH;
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


create or replace TRIGGER "OH"."TDA_DSCOH" after delete
on OH.DSC_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.TRAVAUX_OH"
	delete OH.TRAVAUX_OH
	where DSC_OH__NUM_OH = :old.NUM_OH;
	
	--  Suppression des enfants dans "OH.PREVISION_OH"
	delete OH.PREVISION_OH
	where DSC_OH__NUM_OH = :old.NUM_OH;
	
	--  Suppression des enfants dans "OH.VST_OH"
	delete OH.VST_OH
	where DSC_OH__NUM_OH = :old.NUM_OH;
	
	--  Suppression des enfants dans "OH.INSP_OH"
	delete OH.INSP_OH
	where DSC_OH__NUM_OH = :old.NUM_OH;
	
	--  Suppression des enfants dans "OH.HISTO_NOTE_OH"
	delete OH.HISTO_NOTE_OH
	where DSC_OH__NUM_OH = :old.NUM_OH;
	
	--  Suppression des enfants dans "OH.EVT_OH"
	delete OH.EVT_OH
	where DSC_OH__NUM_OH = :old.NUM_OH;
	
	--  Suppression des enfants dans "OH.DSC_TEMP_OH"
	delete OH.DSC_TEMP_OH
	where DSC_OH__NUM_OH = :old.NUM_OH;
	
	--  Suppression des enfants dans "OH.DSC_CAMP_OH"
	delete OH.DSC_CAMP_OH
	where DSC_OH__NUM_OH = :old.NUM_OH;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_DSCTEMPOH" before insert
on OH.DSC_TEMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_FAM_OH"
	cursor c1_dsc_temp_oh(Vcd_fam_oh__famille varchar) is
		select 1 
		from OH.CD_FAM_OH 
		where 
		FAMILLE = Vcd_fam_oh__famille and Vcd_fam_oh__famille is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_TYPE_OH"
	cursor c2_dsc_temp_oh(Vcd_type_oh__type varchar) is
		select 1 
		from OH.CD_TYPE_OH 
		where 
		TYPE = Vcd_type_oh__type and Vcd_type_oh__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_SOUS_TYPE_OH"
	cursor c3_dsc_temp_oh(Vcd_sous_type_oh__sous_type varchar) is
		select 1 
		from OH.CD_SOUS_TYPE_OH 
		where 
		SOUS_TYPE = Vcd_sous_type_oh__sous_type and Vcd_sous_type_oh__sous_type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_MO_OH"
	cursor c4_dsc_temp_oh(Vcd_mo_oh__mo varchar) is
		select 1 
		from OH.CD_MO_OH 
		where 
		MO = Vcd_mo_oh__mo and Vcd_mo_oh__mo is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_ENTP_OH"
	cursor c5_dsc_temp_oh(Vcd_entp_oh__entreprise varchar) is
		select 1 
		from OH.CD_ENTP_OH 
		where 
		ENTREPRISE = Vcd_entp_oh__entreprise and Vcd_entp_oh__entreprise is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_MAT_OH"
	cursor c6_dsc_temp_oh(Vcd_mat_oh__code varchar) is
		select 1 
		from OH.CD_MAT_OH 
		where 
		CODE = Vcd_mat_oh__code and Vcd_mat_oh__code is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_NOM_EAU_OH"
	cursor c7_dsc_temp_oh(Vcd_nom_eau_oh__nom varchar) is
		select 1 
		from OH.CD_NOM_EAU_OH 
		where 
		NOM = Vcd_nom_eau_oh__nom and Vcd_nom_eau_oh__nom is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_EXT_OH"
	cursor c8_dsc_temp_oh(Vcd_ext_oh__type varchar) is
		select 1 
		from OH.CD_EXT_OH 
		where 
		TYPE = Vcd_ext_oh__type and Vcd_ext_oh__type is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_TETE_AV_OH"
	cursor c9_dsc_temp_oh(Vcd_tete_av_oh__tete_av varchar) is
		select 1 
		from OH.CD_TETE_AV_OH 
		where 
		TETE_AV = Vcd_tete_av_oh__tete_av and Vcd_tete_av_oh__tete_av is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_TETE_AM_OH"
	cursor c10_dsc_temp_oh(Vcd_tete_am_oh__tete_am varchar) is
		select 1 
		from OH.CD_TETE_AM_OH 
		where 
		TETE_AM = Vcd_tete_am_oh__tete_am and Vcd_tete_am_oh__tete_am is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_PRO_AM_OH"
	cursor c11_dsc_temp_oh(Vcd_pro_am_oh__protect varchar) is
		select 1 
		from OH.CD_PRO_AM_OH 
		where 
		PROTECT = Vcd_pro_am_oh__protect and Vcd_pro_am_oh__protect is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_PRO_AV_OH"
	cursor c12_dsc_temp_oh(Vcd_pro_av_oh__protect varchar) is
		select 1 
		from OH.CD_PRO_AV_OH 
		where 
		PROTECT = Vcd_pro_av_oh__protect and Vcd_pro_av_oh__protect is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_EAU_OH"
	cursor c13_dsc_temp_oh(Vcd_eau_oh__eau varchar) is
		select 1 
		from OH.CD_EAU_OH 
		where 
		EAU = Vcd_eau_oh__eau and Vcd_eau_oh__eau is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_OUV_OH"
	cursor c14_dsc_temp_oh(Vcd_ouv_oh__ouv varchar) is
		select 1 
		from OH.CD_OUV_OH 
		where 
		OUV = Vcd_ouv_oh__ouv and Vcd_ouv_oh__ouv is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_ECOUL_OH"
	cursor c15_dsc_temp_oh(Vcd_ecoul_oh__ecoul varchar) is
		select 1 
		from OH.CD_ECOUL_OH 
		where 
		ECOUL = Vcd_ecoul_oh__ecoul and Vcd_ecoul_oh__ecoul is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CAMP_OH"
	cursor c16_dsc_temp_oh(Vcamp_oh__id_camp varchar) is
		select 1 
		from OH.CAMP_OH 
		where 
		ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.DSC_OH"
	cursor c17_dsc_temp_oh(Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.DSC_OH 
		where 
		NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
begin

	
	--  Le parent "OH.CD_FAM_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_FAM_OH__FAMILLE is not null then 
		open c1_dsc_temp_oh ( :new.CD_FAM_OH__FAMILLE);
		fetch c1_dsc_temp_oh into dummy;
		found := c1_dsc_temp_oh%FOUND;
		close c1_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_FAM_OH". Impossible de créer un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_TYPE_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_TYPE_OH__TYPE is not null then 
		open c2_dsc_temp_oh ( :new.CD_TYPE_OH__TYPE);
		fetch c2_dsc_temp_oh into dummy;
		found := c2_dsc_temp_oh%FOUND;
		close c2_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_TYPE_OH". Impossible de créer un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_SOUS_TYPE_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_SOUS_TYPE_OH__SOUS_TYPE is not null then 
		open c3_dsc_temp_oh ( :new.CD_SOUS_TYPE_OH__SOUS_TYPE);
		fetch c3_dsc_temp_oh into dummy;
		found := c3_dsc_temp_oh%FOUND;
		close c3_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_SOUS_TYPE_OH". Impossible de créer un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_MO_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_MO_OH__MO is not null then 
		open c4_dsc_temp_oh ( :new.CD_MO_OH__MO);
		fetch c4_dsc_temp_oh into dummy;
		found := c4_dsc_temp_oh%FOUND;
		close c4_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_MO_OH". Impossible de créer un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_ENTP_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_ENTP_OH__ENTREPRISE is not null then 
		open c5_dsc_temp_oh ( :new.CD_ENTP_OH__ENTREPRISE);
		fetch c5_dsc_temp_oh into dummy;
		found := c5_dsc_temp_oh%FOUND;
		close c5_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_ENTP_OH". Impossible de créer un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_MAT_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_MAT_OH__CODE is not null then 
		open c6_dsc_temp_oh ( :new.CD_MAT_OH__CODE);
		fetch c6_dsc_temp_oh into dummy;
		found := c6_dsc_temp_oh%FOUND;
		close c6_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_MAT_OH". Impossible de créer un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_NOM_EAU_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_NOM_EAU_OH__NOM is not null then 
		open c7_dsc_temp_oh ( :new.CD_NOM_EAU_OH__NOM);
		fetch c7_dsc_temp_oh into dummy;
		found := c7_dsc_temp_oh%FOUND;
		close c7_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_NOM_EAU_OH". Impossible de créer un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_EXT_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_EXT_OH__TYPE is not null then 
		open c8_dsc_temp_oh ( :new.CD_EXT_OH__TYPE);
		fetch c8_dsc_temp_oh into dummy;
		found := c8_dsc_temp_oh%FOUND;
		close c8_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_EXT_OH". Impossible de créer un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_TETE_AV_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_TETE_AV_OH__TETE_AV is not null then 
		open c9_dsc_temp_oh ( :new.CD_TETE_AV_OH__TETE_AV);
		fetch c9_dsc_temp_oh into dummy;
		found := c9_dsc_temp_oh%FOUND;
		close c9_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_TETE_AV_OH". Impossible de créer un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_TETE_AM_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_TETE_AM_OH__TETE_AM is not null then 
		open c10_dsc_temp_oh ( :new.CD_TETE_AM_OH__TETE_AM);
		fetch c10_dsc_temp_oh into dummy;
		found := c10_dsc_temp_oh%FOUND;
		close c10_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_TETE_AM_OH". Impossible de créer un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_PRO_AM_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_PRO_AM_OH__PROTECT is not null then 
		open c11_dsc_temp_oh ( :new.CD_PRO_AM_OH__PROTECT);
		fetch c11_dsc_temp_oh into dummy;
		found := c11_dsc_temp_oh%FOUND;
		close c11_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_PRO_AM_OH". Impossible de créer un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_PRO_AV_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_PRO_AV_OH__PROTECT is not null then 
		open c12_dsc_temp_oh ( :new.CD_PRO_AV_OH__PROTECT);
		fetch c12_dsc_temp_oh into dummy;
		found := c12_dsc_temp_oh%FOUND;
		close c12_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_PRO_AV_OH". Impossible de créer un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_EAU_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_EAU_OH__EAU is not null then 
		open c13_dsc_temp_oh ( :new.CD_EAU_OH__EAU);
		fetch c13_dsc_temp_oh into dummy;
		found := c13_dsc_temp_oh%FOUND;
		close c13_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_EAU_OH". Impossible de créer un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_OUV_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_OUV_OH__OUV is not null then 
		open c14_dsc_temp_oh ( :new.CD_OUV_OH__OUV);
		fetch c14_dsc_temp_oh into dummy;
		found := c14_dsc_temp_oh%FOUND;
		close c14_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_OUV_OH". Impossible de créer un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_ECOUL_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_ECOUL_OH__ECOUL is not null then 
		open c15_dsc_temp_oh ( :new.CD_ECOUL_OH__ECOUL);
		fetch c15_dsc_temp_oh into dummy;
		found := c15_dsc_temp_oh%FOUND;
		close c15_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_ECOUL_OH". Impossible de créer un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CAMP_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CAMP_OH__ID_CAMP is not null then 
		open c16_dsc_temp_oh ( :new.CAMP_OH__ID_CAMP);
		fetch c16_dsc_temp_oh into dummy;
		found := c16_dsc_temp_oh%FOUND;
		close c16_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CAMP_OH". Impossible de créer un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.DSC_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.DSC_OH__NUM_OH is not null then 
		open c17_dsc_temp_oh ( :new.DSC_OH__NUM_OH);
		fetch c17_dsc_temp_oh into dummy;
		found := c17_dsc_temp_oh%FOUND;
		close c17_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DSC_OH". Impossible de créer un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_DSCTEMPOH" before update
on OH.DSC_TEMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_FAM_OH"
	cursor c1_dsc_temp_oh (Vcd_fam_oh__famille varchar) is
		select 1 
		from OH.CD_FAM_OH 
		where 
		FAMILLE = Vcd_fam_oh__famille and Vcd_fam_oh__famille is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_TYPE_OH"
	cursor c2_dsc_temp_oh (Vcd_type_oh__type varchar) is
		select 1 
		from OH.CD_TYPE_OH 
		where 
		TYPE = Vcd_type_oh__type and Vcd_type_oh__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_SOUS_TYPE_OH"
	cursor c3_dsc_temp_oh (Vcd_sous_type_oh__sous_type varchar) is
		select 1 
		from OH.CD_SOUS_TYPE_OH 
		where 
		SOUS_TYPE = Vcd_sous_type_oh__sous_type and Vcd_sous_type_oh__sous_type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_MO_OH"
	cursor c4_dsc_temp_oh (Vcd_mo_oh__mo varchar) is
		select 1 
		from OH.CD_MO_OH 
		where 
		MO = Vcd_mo_oh__mo and Vcd_mo_oh__mo is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_ENTP_OH"
	cursor c5_dsc_temp_oh (Vcd_entp_oh__entreprise varchar) is
		select 1 
		from OH.CD_ENTP_OH 
		where 
		ENTREPRISE = Vcd_entp_oh__entreprise and Vcd_entp_oh__entreprise is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_MAT_OH"
	cursor c6_dsc_temp_oh (Vcd_mat_oh__code varchar) is
		select 1 
		from OH.CD_MAT_OH 
		where 
		CODE = Vcd_mat_oh__code and Vcd_mat_oh__code is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_NOM_EAU_OH"
	cursor c7_dsc_temp_oh (Vcd_nom_eau_oh__nom varchar) is
		select 1 
		from OH.CD_NOM_EAU_OH 
		where 
		NOM = Vcd_nom_eau_oh__nom and Vcd_nom_eau_oh__nom is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_EXT_OH"
	cursor c8_dsc_temp_oh (Vcd_ext_oh__type varchar) is
		select 1 
		from OH.CD_EXT_OH 
		where 
		TYPE = Vcd_ext_oh__type and Vcd_ext_oh__type is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_TETE_AV_OH"
	cursor c9_dsc_temp_oh (Vcd_tete_av_oh__tete_av varchar) is
		select 1 
		from OH.CD_TETE_AV_OH 
		where 
		TETE_AV = Vcd_tete_av_oh__tete_av and Vcd_tete_av_oh__tete_av is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_TETE_AM_OH"
	cursor c10_dsc_temp_oh (Vcd_tete_am_oh__tete_am varchar) is
		select 1 
		from OH.CD_TETE_AM_OH 
		where 
		TETE_AM = Vcd_tete_am_oh__tete_am and Vcd_tete_am_oh__tete_am is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_PRO_AM_OH"
	cursor c11_dsc_temp_oh (Vcd_pro_am_oh__protect varchar) is
		select 1 
		from OH.CD_PRO_AM_OH 
		where 
		PROTECT = Vcd_pro_am_oh__protect and Vcd_pro_am_oh__protect is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_PRO_AV_OH"
	cursor c12_dsc_temp_oh (Vcd_pro_av_oh__protect varchar) is
		select 1 
		from OH.CD_PRO_AV_OH 
		where 
		PROTECT = Vcd_pro_av_oh__protect and Vcd_pro_av_oh__protect is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_EAU_OH"
	cursor c13_dsc_temp_oh (Vcd_eau_oh__eau varchar) is
		select 1 
		from OH.CD_EAU_OH 
		where 
		EAU = Vcd_eau_oh__eau and Vcd_eau_oh__eau is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_OUV_OH"
	cursor c14_dsc_temp_oh (Vcd_ouv_oh__ouv varchar) is
		select 1 
		from OH.CD_OUV_OH 
		where 
		OUV = Vcd_ouv_oh__ouv and Vcd_ouv_oh__ouv is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_ECOUL_OH"
	cursor c15_dsc_temp_oh (Vcd_ecoul_oh__ecoul varchar) is
		select 1 
		from OH.CD_ECOUL_OH 
		where 
		ECOUL = Vcd_ecoul_oh__ecoul and Vcd_ecoul_oh__ecoul is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CAMP_OH"
	cursor c16_dsc_temp_oh (Vcamp_oh__id_camp varchar) is
		select 1 
		from OH.CAMP_OH 
		where 
		ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.DSC_OH"
	cursor c17_dsc_temp_oh (Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.DSC_OH 
		where 
		NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.CD_FAM_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_FAM_OH__FAMILLE is not null and seq = 0 then 
		open c1_dsc_temp_oh ( :new.CD_FAM_OH__FAMILLE);
		fetch c1_dsc_temp_oh into dummy;
		found := c1_dsc_temp_oh%FOUND;
		close c1_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_FAM_OH". Impossible de modifier un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_TYPE_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_TYPE_OH__TYPE is not null and seq = 0 then 
		open c2_dsc_temp_oh ( :new.CD_TYPE_OH__TYPE);
		fetch c2_dsc_temp_oh into dummy;
		found := c2_dsc_temp_oh%FOUND;
		close c2_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_TYPE_OH". Impossible de modifier un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_SOUS_TYPE_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_SOUS_TYPE_OH__SOUS_TYPE is not null and seq = 0 then 
		open c3_dsc_temp_oh ( :new.CD_SOUS_TYPE_OH__SOUS_TYPE);
		fetch c3_dsc_temp_oh into dummy;
		found := c3_dsc_temp_oh%FOUND;
		close c3_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_SOUS_TYPE_OH". Impossible de modifier un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_MO_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_MO_OH__MO is not null and seq = 0 then 
		open c4_dsc_temp_oh ( :new.CD_MO_OH__MO);
		fetch c4_dsc_temp_oh into dummy;
		found := c4_dsc_temp_oh%FOUND;
		close c4_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_MO_OH". Impossible de modifier un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_ENTP_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_ENTP_OH__ENTREPRISE is not null and seq = 0 then 
		open c5_dsc_temp_oh ( :new.CD_ENTP_OH__ENTREPRISE);
		fetch c5_dsc_temp_oh into dummy;
		found := c5_dsc_temp_oh%FOUND;
		close c5_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_ENTP_OH". Impossible de modifier un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_MAT_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_MAT_OH__CODE is not null and seq = 0 then 
		open c6_dsc_temp_oh ( :new.CD_MAT_OH__CODE);
		fetch c6_dsc_temp_oh into dummy;
		found := c6_dsc_temp_oh%FOUND;
		close c6_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_MAT_OH". Impossible de modifier un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_NOM_EAU_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_NOM_EAU_OH__NOM is not null and seq = 0 then 
		open c7_dsc_temp_oh ( :new.CD_NOM_EAU_OH__NOM);
		fetch c7_dsc_temp_oh into dummy;
		found := c7_dsc_temp_oh%FOUND;
		close c7_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_NOM_EAU_OH". Impossible de modifier un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_EXT_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_EXT_OH__TYPE is not null and seq = 0 then 
		open c8_dsc_temp_oh ( :new.CD_EXT_OH__TYPE);
		fetch c8_dsc_temp_oh into dummy;
		found := c8_dsc_temp_oh%FOUND;
		close c8_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_EXT_OH". Impossible de modifier un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_TETE_AV_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_TETE_AV_OH__TETE_AV is not null and seq = 0 then 
		open c9_dsc_temp_oh ( :new.CD_TETE_AV_OH__TETE_AV);
		fetch c9_dsc_temp_oh into dummy;
		found := c9_dsc_temp_oh%FOUND;
		close c9_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_TETE_AV_OH". Impossible de modifier un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_TETE_AM_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_TETE_AM_OH__TETE_AM is not null and seq = 0 then 
		open c10_dsc_temp_oh ( :new.CD_TETE_AM_OH__TETE_AM);
		fetch c10_dsc_temp_oh into dummy;
		found := c10_dsc_temp_oh%FOUND;
		close c10_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_TETE_AM_OH". Impossible de modifier un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_PRO_AM_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_PRO_AM_OH__PROTECT is not null and seq = 0 then 
		open c11_dsc_temp_oh ( :new.CD_PRO_AM_OH__PROTECT);
		fetch c11_dsc_temp_oh into dummy;
		found := c11_dsc_temp_oh%FOUND;
		close c11_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_PRO_AM_OH". Impossible de modifier un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_PRO_AV_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_PRO_AV_OH__PROTECT is not null and seq = 0 then 
		open c12_dsc_temp_oh ( :new.CD_PRO_AV_OH__PROTECT);
		fetch c12_dsc_temp_oh into dummy;
		found := c12_dsc_temp_oh%FOUND;
		close c12_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_PRO_AV_OH". Impossible de modifier un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_EAU_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_EAU_OH__EAU is not null and seq = 0 then 
		open c13_dsc_temp_oh ( :new.CD_EAU_OH__EAU);
		fetch c13_dsc_temp_oh into dummy;
		found := c13_dsc_temp_oh%FOUND;
		close c13_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_EAU_OH". Impossible de modifier un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_OUV_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_OUV_OH__OUV is not null and seq = 0 then 
		open c14_dsc_temp_oh ( :new.CD_OUV_OH__OUV);
		fetch c14_dsc_temp_oh into dummy;
		found := c14_dsc_temp_oh%FOUND;
		close c14_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_OUV_OH". Impossible de modifier un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_ECOUL_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CD_ECOUL_OH__ECOUL is not null and seq = 0 then 
		open c15_dsc_temp_oh ( :new.CD_ECOUL_OH__ECOUL);
		fetch c15_dsc_temp_oh into dummy;
		found := c15_dsc_temp_oh%FOUND;
		close c15_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_ECOUL_OH". Impossible de modifier un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CAMP_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.CAMP_OH__ID_CAMP is not null and seq = 0 then 
		open c16_dsc_temp_oh ( :new.CAMP_OH__ID_CAMP);
		fetch c16_dsc_temp_oh into dummy;
		found := c16_dsc_temp_oh%FOUND;
		close c16_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CAMP_OH". Impossible de modifier un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.DSC_OH" doit exister à la création d'un enfant dans "OH.DSC_TEMP_OH"
	if :new.DSC_OH__NUM_OH is not null and seq = 0 then 
		open c17_dsc_temp_oh ( :new.DSC_OH__NUM_OH);
		fetch c17_dsc_temp_oh into dummy;
		found := c17_dsc_temp_oh%FOUND;
		close c17_dsc_temp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DSC_OH". Impossible de modifier un enfant dans "OH.DSC_TEMP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_DSCTEMPOH" after update
of CAMP_OH__ID_CAMP,NUM_OH
on OH.DSC_TEMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.DSC_TEMP_OH" dans les enfants "OH.INSP_TMP_OH"
	if ((updating('CAMP_OH__ID_CAMP') and :old.CAMP_OH__ID_CAMP != :new.CAMP_OH__ID_CAMP) or 
	(updating('NUM_OH') and :old.NUM_OH != :new.NUM_OH)) then 
		update OH.INSP_TMP_OH
		set CAMP_OH__ID_CAMP = :new.CAMP_OH__ID_CAMP,
		DSC_TEMP_OH__NUM_OH = :new.NUM_OH  
		where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
		DSC_TEMP_OH__NUM_OH = :old.NUM_OH;
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


create or replace TRIGGER "OH"."TDA_DSCTEMPOH" after delete
on OH.DSC_TEMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.INSP_TMP_OH"
	delete OH.INSP_TMP_OH
	where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
	DSC_TEMP_OH__NUM_OH = :old.NUM_OH;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_PRTOH" before insert
on OH.PRT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.GRP_OH"
	cursor c1_prt_oh(Vgrp_oh__id_grp number) is
		select 1 
		from OH.GRP_OH 
		where 
		ID_GRP = Vgrp_oh__id_grp and Vgrp_oh__id_grp is not null;
begin

	
	--  Le parent "OH.GRP_OH" doit exister à la création d'un enfant dans "OH.PRT_OH"
	if :new.GRP_OH__ID_GRP is not null then 
		open c1_prt_oh ( :new.GRP_OH__ID_GRP);
		fetch c1_prt_oh into dummy;
		found := c1_prt_oh%FOUND;
		close c1_prt_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.GRP_OH". Impossible de créer un enfant dans "OH.PRT_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_PRTOH" before update
on OH.PRT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.GRP_OH"
	cursor c1_prt_oh (Vgrp_oh__id_grp number) is
		select 1 
		from OH.GRP_OH 
		where 
		ID_GRP = Vgrp_oh__id_grp and Vgrp_oh__id_grp is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.GRP_OH" doit exister à la création d'un enfant dans "OH.PRT_OH"
	if :new.GRP_OH__ID_GRP is not null and seq = 0 then 
		open c1_prt_oh ( :new.GRP_OH__ID_GRP);
		fetch c1_prt_oh into dummy;
		found := c1_prt_oh%FOUND;
		close c1_prt_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.GRP_OH". Impossible de modifier un enfant dans "OH.PRT_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_PRTOH" after update
of GRP_OH__ID_GRP,ID_PRT
on OH.PRT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.PRT_OH" dans les enfants "OH.SPRT_OH"
	if ((updating('GRP_OH__ID_GRP') and :old.GRP_OH__ID_GRP != :new.GRP_OH__ID_GRP) or 
	(updating('ID_PRT') and :old.ID_PRT != :new.ID_PRT)) then 
		update OH.SPRT_OH
		set GRP_OH__ID_GRP = :new.GRP_OH__ID_GRP,
		PRT_OH__ID_PRT = :new.ID_PRT  
		where GRP_OH__ID_GRP = :old.GRP_OH__ID_GRP and 
		PRT_OH__ID_PRT = :old.ID_PRT;
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


create or replace TRIGGER "OH"."TDA_PRTOH" after delete
on OH.PRT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.SPRT_OH"
	delete OH.SPRT_OH
	where GRP_OH__ID_GRP = :old.GRP_OH__ID_GRP and 
	PRT_OH__ID_PRT = :old.ID_PRT;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_PHOTOINSPOH" before insert
on OH.PHOTO_INSP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.INSP_OH"
	cursor c1_photo_insp_oh(Vcamp_oh__id_camp varchar,
	Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.INSP_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_OH__NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
begin

	
	--  Le parent "OH.INSP_OH" doit exister à la création d'un enfant dans "OH.PHOTO_INSP_OH"
	if :new.CAMP_OH__ID_CAMP is not null and 
	:new.DSC_OH__NUM_OH is not null then 
		open c1_photo_insp_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_OH__NUM_OH);
		fetch c1_photo_insp_oh into dummy;
		found := c1_photo_insp_oh%FOUND;
		close c1_photo_insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.INSP_OH". Impossible de créer un enfant dans "OH.PHOTO_INSP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_PHOTOINSPOH" before update
on OH.PHOTO_INSP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.INSP_OH"
	cursor c1_photo_insp_oh (Vcamp_oh__id_camp varchar,
	Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.INSP_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_OH__NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.INSP_OH" doit exister à la création d'un enfant dans "OH.PHOTO_INSP_OH"
	if :new.CAMP_OH__ID_CAMP is not null and seq = 0 and 
	:new.DSC_OH__NUM_OH is not null and seq = 0 then 
		open c1_photo_insp_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_OH__NUM_OH);
		fetch c1_photo_insp_oh into dummy;
		found := c1_photo_insp_oh%FOUND;
		close c1_photo_insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.INSP_OH". Impossible de modifier un enfant dans "OH.PHOTO_INSP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TIB_PHOTOINSPTMPOH" before insert
on OH.PHOTO_INSP_TMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.INSP_TMP_OH"
	cursor c1_photo_insp_tmp_oh(Vcamp_oh__id_camp varchar,
	Vdsc_temp_oh__num_oh varchar) is
		select 1 
		from OH.INSP_TMP_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_TEMP_OH__NUM_OH = Vdsc_temp_oh__num_oh and Vdsc_temp_oh__num_oh is not null;
begin

	
	--  Le parent "OH.INSP_TMP_OH" doit exister à la création d'un enfant dans "OH.PHOTO_INSP_TMP_OH"
	if :new.CAMP_OH__ID_CAMP is not null and 
	:new.DSC_TEMP_OH__NUM_OH is not null then 
		open c1_photo_insp_tmp_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_TEMP_OH__NUM_OH);
		fetch c1_photo_insp_tmp_oh into dummy;
		found := c1_photo_insp_tmp_oh%FOUND;
		close c1_photo_insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.INSP_TMP_OH". Impossible de créer un enfant dans "OH.PHOTO_INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_PHOTOINSPTMPOH" before update
on OH.PHOTO_INSP_TMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.INSP_TMP_OH"
	cursor c1_photo_insp_tmp_oh (Vcamp_oh__id_camp varchar,
	Vdsc_temp_oh__num_oh varchar) is
		select 1 
		from OH.INSP_TMP_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_TEMP_OH__NUM_OH = Vdsc_temp_oh__num_oh and Vdsc_temp_oh__num_oh is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.INSP_TMP_OH" doit exister à la création d'un enfant dans "OH.PHOTO_INSP_TMP_OH"
	if :new.CAMP_OH__ID_CAMP is not null and seq = 0 and 
	:new.DSC_TEMP_OH__NUM_OH is not null and seq = 0 then 
		open c1_photo_insp_tmp_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_TEMP_OH__NUM_OH);
		fetch c1_photo_insp_tmp_oh into dummy;
		found := c1_photo_insp_tmp_oh%FOUND;
		close c1_photo_insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.INSP_TMP_OH". Impossible de modifier un enfant dans "OH.PHOTO_INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TIB_PHOTOELTINSPOH" before insert
on OH.PHOTO_ELT_INSP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.ELT_INSP_OH"
	cursor c1_photo_elt_insp_oh(Vgrp_oh__id_grp number,
	Vprt_oh__id_prt number,
	Vsprt_oh__id_sprt number,
	Vcamp_oh__id_camp varchar,
	Velt_oh__id_elem number,
	Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.ELT_INSP_OH 
		where 
		GRP_OH__ID_GRP = Vgrp_oh__id_grp and Vgrp_oh__id_grp is not null and 
		PRT_OH__ID_PRT = Vprt_oh__id_prt and Vprt_oh__id_prt is not null and 
		SPRT_OH__ID_SPRT = Vsprt_oh__id_sprt and Vsprt_oh__id_sprt is not null and 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		ELT_OH__ID_ELEM = Velt_oh__id_elem and Velt_oh__id_elem is not null and 
		DSC_OH__NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
begin

	
	--  Le parent "OH.ELT_INSP_OH" doit exister à la création d'un enfant dans "OH.PHOTO_ELT_INSP_OH"
	if :new.GRP_OH__ID_GRP is not null and 
	:new.PRT_OH__ID_PRT is not null and 
	:new.SPRT_OH__ID_SPRT is not null and 
	:new.CAMP_OH__ID_CAMP is not null and 
	:new.ELT_OH__ID_ELEM is not null and 
	:new.DSC_OH__NUM_OH is not null then 
		open c1_photo_elt_insp_oh ( :new.GRP_OH__ID_GRP,
		:new.PRT_OH__ID_PRT,
		:new.SPRT_OH__ID_SPRT,
		:new.CAMP_OH__ID_CAMP,
		:new.ELT_OH__ID_ELEM,
		:new.DSC_OH__NUM_OH);
		fetch c1_photo_elt_insp_oh into dummy;
		found := c1_photo_elt_insp_oh%FOUND;
		close c1_photo_elt_insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.ELT_INSP_OH". Impossible de créer un enfant dans "OH.PHOTO_ELT_INSP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_PHOTOELTINSPOH" before update
on OH.PHOTO_ELT_INSP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.ELT_INSP_OH"
	cursor c1_photo_elt_insp_oh (Vgrp_oh__id_grp number,
	Vprt_oh__id_prt number,
	Vsprt_oh__id_sprt number,
	Vcamp_oh__id_camp varchar,
	Velt_oh__id_elem number,
	Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.ELT_INSP_OH 
		where 
		GRP_OH__ID_GRP = Vgrp_oh__id_grp and Vgrp_oh__id_grp is not null and 
		PRT_OH__ID_PRT = Vprt_oh__id_prt and Vprt_oh__id_prt is not null and 
		SPRT_OH__ID_SPRT = Vsprt_oh__id_sprt and Vsprt_oh__id_sprt is not null and 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		ELT_OH__ID_ELEM = Velt_oh__id_elem and Velt_oh__id_elem is not null and 
		DSC_OH__NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.ELT_INSP_OH" doit exister à la création d'un enfant dans "OH.PHOTO_ELT_INSP_OH"
	if :new.GRP_OH__ID_GRP is not null and seq = 0 and 
	:new.PRT_OH__ID_PRT is not null and seq = 0 and 
	:new.SPRT_OH__ID_SPRT is not null and seq = 0 and 
	:new.CAMP_OH__ID_CAMP is not null and seq = 0 and 
	:new.ELT_OH__ID_ELEM is not null and seq = 0 and 
	:new.DSC_OH__NUM_OH is not null and seq = 0 then 
		open c1_photo_elt_insp_oh ( :new.GRP_OH__ID_GRP,
		:new.PRT_OH__ID_PRT,
		:new.SPRT_OH__ID_SPRT,
		:new.CAMP_OH__ID_CAMP,
		:new.ELT_OH__ID_ELEM,
		:new.DSC_OH__NUM_OH);
		fetch c1_photo_elt_insp_oh into dummy;
		found := c1_photo_elt_insp_oh%FOUND;
		close c1_photo_elt_insp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.ELT_INSP_OH". Impossible de modifier un enfant dans "OH.PHOTO_ELT_INSP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TIB_PHOTOELTINSPTMPOH" before insert
on OH.PHOTO_ELT_INSP_TMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.ELT_INSP_TMP_OH"
	cursor c1_photo_elt_insp_tmp_oh(Vgrp_oh__id_grp number,
	Vprt_oh__id_prt number,
	Vsprt_oh__id_sprt number,
	Vcamp_oh__id_camp varchar,
	Vdsc_temp_oh__num_oh varchar,
	Velt_oh__id_elem number) is
		select 1 
		from OH.ELT_INSP_TMP_OH 
		where 
		GRP_OH__ID_GRP = Vgrp_oh__id_grp and Vgrp_oh__id_grp is not null and 
		PRT_OH__ID_PRT = Vprt_oh__id_prt and Vprt_oh__id_prt is not null and 
		SPRT_OH__ID_SPRT = Vsprt_oh__id_sprt and Vsprt_oh__id_sprt is not null and 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_TEMP_OH__NUM_OH = Vdsc_temp_oh__num_oh and Vdsc_temp_oh__num_oh is not null and 
		ELT_OH__ID_ELEM = Velt_oh__id_elem and Velt_oh__id_elem is not null;
begin

	
	--  Le parent "OH.ELT_INSP_TMP_OH" doit exister à la création d'un enfant dans "OH.PHOTO_ELT_INSP_TMP_OH"
	if :new.GRP_OH__ID_GRP is not null and 
	:new.PRT_OH__ID_PRT is not null and 
	:new.SPRT_OH__ID_SPRT is not null and 
	:new.CAMP_OH__ID_CAMP is not null and 
	:new.DSC_TEMP_OH__NUM_OH is not null and 
	:new.ELT_OH__ID_ELEM is not null then 
		open c1_photo_elt_insp_tmp_oh ( :new.GRP_OH__ID_GRP,
		:new.PRT_OH__ID_PRT,
		:new.SPRT_OH__ID_SPRT,
		:new.CAMP_OH__ID_CAMP,
		:new.DSC_TEMP_OH__NUM_OH,
		:new.ELT_OH__ID_ELEM);
		fetch c1_photo_elt_insp_tmp_oh into dummy;
		found := c1_photo_elt_insp_tmp_oh%FOUND;
		close c1_photo_elt_insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.ELT_INSP_TMP_OH". Impossible de créer un enfant dans "OH.PHOTO_ELT_INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_PHOTOELTINSPTMPOH" before update
on OH.PHOTO_ELT_INSP_TMP_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.ELT_INSP_TMP_OH"
	cursor c1_photo_elt_insp_tmp_oh (Vgrp_oh__id_grp number,
	Vprt_oh__id_prt number,
	Vsprt_oh__id_sprt number,
	Vcamp_oh__id_camp varchar,
	Vdsc_temp_oh__num_oh varchar,
	Velt_oh__id_elem number) is
		select 1 
		from OH.ELT_INSP_TMP_OH 
		where 
		GRP_OH__ID_GRP = Vgrp_oh__id_grp and Vgrp_oh__id_grp is not null and 
		PRT_OH__ID_PRT = Vprt_oh__id_prt and Vprt_oh__id_prt is not null and 
		SPRT_OH__ID_SPRT = Vsprt_oh__id_sprt and Vsprt_oh__id_sprt is not null and 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_TEMP_OH__NUM_OH = Vdsc_temp_oh__num_oh and Vdsc_temp_oh__num_oh is not null and 
		ELT_OH__ID_ELEM = Velt_oh__id_elem and Velt_oh__id_elem is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.ELT_INSP_TMP_OH" doit exister à la création d'un enfant dans "OH.PHOTO_ELT_INSP_TMP_OH"
	if :new.GRP_OH__ID_GRP is not null and seq = 0 and 
	:new.PRT_OH__ID_PRT is not null and seq = 0 and 
	:new.SPRT_OH__ID_SPRT is not null and seq = 0 and 
	:new.CAMP_OH__ID_CAMP is not null and seq = 0 and 
	:new.DSC_TEMP_OH__NUM_OH is not null and seq = 0 and 
	:new.ELT_OH__ID_ELEM is not null and seq = 0 then 
		open c1_photo_elt_insp_tmp_oh ( :new.GRP_OH__ID_GRP,
		:new.PRT_OH__ID_PRT,
		:new.SPRT_OH__ID_SPRT,
		:new.CAMP_OH__ID_CAMP,
		:new.DSC_TEMP_OH__NUM_OH,
		:new.ELT_OH__ID_ELEM);
		fetch c1_photo_elt_insp_tmp_oh into dummy;
		found := c1_photo_elt_insp_tmp_oh%FOUND;
		close c1_photo_elt_insp_tmp_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.ELT_INSP_TMP_OH". Impossible de modifier un enfant dans "OH.PHOTO_ELT_INSP_TMP_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TIB_PHOTOSPRTVSTOH" before insert
on OH.PHOTO_SPRT_VST_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.SPRT_VST_OH"
	cursor c1_photo_sprt_vst_oh(Vcamp_oh__id_camp varchar,
	Vdsc_oh__num_oh varchar,
	Vcd_chapitre_oh__id_chap number,
	Vcd_ligne_oh__id_ligne number) is
		select 1 
		from OH.SPRT_VST_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_OH__NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null and 
		CD_CHAPITRE_OH__ID_CHAP = Vcd_chapitre_oh__id_chap and Vcd_chapitre_oh__id_chap is not null and 
		CD_LIGNE_OH__ID_LIGNE = Vcd_ligne_oh__id_ligne and Vcd_ligne_oh__id_ligne is not null;
begin

	
	--  Le parent "OH.SPRT_VST_OH" doit exister à la création d'un enfant dans "OH.PHOTO_SPRT_VST_OH"
	if :new.CAMP_OH__ID_CAMP is not null and 
	:new.DSC_OH__NUM_OH is not null and 
	:new.CD_CHAPITRE_OH__ID_CHAP is not null and 
	:new.CD_LIGNE_OH__ID_LIGNE is not null then 
		open c1_photo_sprt_vst_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_OH__NUM_OH,
		:new.CD_CHAPITRE_OH__ID_CHAP,
		:new.CD_LIGNE_OH__ID_LIGNE);
		fetch c1_photo_sprt_vst_oh into dummy;
		found := c1_photo_sprt_vst_oh%FOUND;
		close c1_photo_sprt_vst_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.SPRT_VST_OH". Impossible de créer un enfant dans "OH.PHOTO_SPRT_VST_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_PHOTOSPRTVSTOH" before update
on OH.PHOTO_SPRT_VST_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.SPRT_VST_OH"
	cursor c1_photo_sprt_vst_oh (Vcamp_oh__id_camp varchar,
	Vdsc_oh__num_oh varchar,
	Vcd_chapitre_oh__id_chap number,
	Vcd_ligne_oh__id_ligne number) is
		select 1 
		from OH.SPRT_VST_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_OH__NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null and 
		CD_CHAPITRE_OH__ID_CHAP = Vcd_chapitre_oh__id_chap and Vcd_chapitre_oh__id_chap is not null and 
		CD_LIGNE_OH__ID_LIGNE = Vcd_ligne_oh__id_ligne and Vcd_ligne_oh__id_ligne is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.SPRT_VST_OH" doit exister à la création d'un enfant dans "OH.PHOTO_SPRT_VST_OH"
	if :new.CAMP_OH__ID_CAMP is not null and seq = 0 and 
	:new.DSC_OH__NUM_OH is not null and seq = 0 and 
	:new.CD_CHAPITRE_OH__ID_CHAP is not null and seq = 0 and 
	:new.CD_LIGNE_OH__ID_LIGNE is not null and seq = 0 then 
		open c1_photo_sprt_vst_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_OH__NUM_OH,
		:new.CD_CHAPITRE_OH__ID_CHAP,
		:new.CD_LIGNE_OH__ID_LIGNE);
		fetch c1_photo_sprt_vst_oh into dummy;
		found := c1_photo_sprt_vst_oh%FOUND;
		close c1_photo_sprt_vst_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.SPRT_VST_OH". Impossible de modifier un enfant dans "OH.PHOTO_SPRT_VST_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TIB_PHOTOVSTOH" before insert
on OH.PHOTO_VST_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.VST_OH"
	cursor c1_photo_vst_oh(Vcamp_oh__id_camp varchar,
	Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.VST_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_OH__NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
begin

	
	--  Le parent "OH.VST_OH" doit exister à la création d'un enfant dans "OH.PHOTO_VST_OH"
	if :new.CAMP_OH__ID_CAMP is not null and 
	:new.DSC_OH__NUM_OH is not null then 
		open c1_photo_vst_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_OH__NUM_OH);
		fetch c1_photo_vst_oh into dummy;
		found := c1_photo_vst_oh%FOUND;
		close c1_photo_vst_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.VST_OH". Impossible de créer un enfant dans "OH.PHOTO_VST_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_PHOTOVSTOH" before update
on OH.PHOTO_VST_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.VST_OH"
	cursor c1_photo_vst_oh (Vcamp_oh__id_camp varchar,
	Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.VST_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_OH__NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.VST_OH" doit exister à la création d'un enfant dans "OH.PHOTO_VST_OH"
	if :new.CAMP_OH__ID_CAMP is not null and seq = 0 and 
	:new.DSC_OH__NUM_OH is not null and seq = 0 then 
		open c1_photo_vst_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_OH__NUM_OH);
		fetch c1_photo_vst_oh into dummy;
		found := c1_photo_vst_oh%FOUND;
		close c1_photo_vst_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.VST_OH". Impossible de modifier un enfant dans "OH.PHOTO_VST_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TIB_CDPRECOSPRTVSTOH" before insert
on OH.CD_PRECO__SPRT_VST_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.SPRT_VST_OH"
	cursor c1_cd_preco__sprt_vst_oh(Vcamp_oh__id_camp varchar,
	Vdsc_oh__num_oh varchar,
	Vcd_chapitre_oh__id_chap number,
	Vcd_ligne_oh__id_ligne number) is
		select 1 
		from OH.SPRT_VST_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_OH__NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null and 
		CD_CHAPITRE_OH__ID_CHAP = Vcd_chapitre_oh__id_chap and Vcd_chapitre_oh__id_chap is not null and 
		CD_LIGNE_OH__ID_LIGNE = Vcd_ligne_oh__id_ligne and Vcd_ligne_oh__id_ligne is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.BPU_OH"
	cursor c2_cd_preco__sprt_vst_oh(Vbpu_oh__id_bpu number) is
		select 1 
		from OH.BPU_OH 
		where 
		ID_BPU = Vbpu_oh__id_bpu and Vbpu_oh__id_bpu is not null;
begin

	
	--  Le parent "OH.SPRT_VST_OH" doit exister à la création d'un enfant dans "OH.CD_PRECO__SPRT_VST_OH"
	if :new.CAMP_OH__ID_CAMP is not null and 
	:new.DSC_OH__NUM_OH is not null and 
	:new.CD_CHAPITRE_OH__ID_CHAP is not null and 
	:new.CD_LIGNE_OH__ID_LIGNE is not null then 
		open c1_cd_preco__sprt_vst_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_OH__NUM_OH,
		:new.CD_CHAPITRE_OH__ID_CHAP,
		:new.CD_LIGNE_OH__ID_LIGNE);
		fetch c1_cd_preco__sprt_vst_oh into dummy;
		found := c1_cd_preco__sprt_vst_oh%FOUND;
		close c1_cd_preco__sprt_vst_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.SPRT_VST_OH". Impossible de créer un enfant dans "OH.CD_PRECO__SPRT_VST_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.BPU_OH" doit exister à la création d'un enfant dans "OH.CD_PRECO__SPRT_VST_OH"
	if :new.BPU_OH__ID_BPU is not null then 
		open c2_cd_preco__sprt_vst_oh ( :new.BPU_OH__ID_BPU);
		fetch c2_cd_preco__sprt_vst_oh into dummy;
		found := c2_cd_preco__sprt_vst_oh%FOUND;
		close c2_cd_preco__sprt_vst_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.BPU_OH". Impossible de créer un enfant dans "OH.CD_PRECO__SPRT_VST_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_CDPRECOSPRTVSTOH" before update
on OH.CD_PRECO__SPRT_VST_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.SPRT_VST_OH"
	cursor c1_cd_preco__sprt_vst_oh (Vcamp_oh__id_camp varchar,
	Vdsc_oh__num_oh varchar,
	Vcd_chapitre_oh__id_chap number,
	Vcd_ligne_oh__id_ligne number) is
		select 1 
		from OH.SPRT_VST_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_OH__NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null and 
		CD_CHAPITRE_OH__ID_CHAP = Vcd_chapitre_oh__id_chap and Vcd_chapitre_oh__id_chap is not null and 
		CD_LIGNE_OH__ID_LIGNE = Vcd_ligne_oh__id_ligne and Vcd_ligne_oh__id_ligne is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.BPU_OH"
	cursor c2_cd_preco__sprt_vst_oh (Vbpu_oh__id_bpu number) is
		select 1 
		from OH.BPU_OH 
		where 
		ID_BPU = Vbpu_oh__id_bpu and Vbpu_oh__id_bpu is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.SPRT_VST_OH" doit exister à la création d'un enfant dans "OH.CD_PRECO__SPRT_VST_OH"
	if :new.CAMP_OH__ID_CAMP is not null and seq = 0 and 
	:new.DSC_OH__NUM_OH is not null and seq = 0 and 
	:new.CD_CHAPITRE_OH__ID_CHAP is not null and seq = 0 and 
	:new.CD_LIGNE_OH__ID_LIGNE is not null and seq = 0 then 
		open c1_cd_preco__sprt_vst_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_OH__NUM_OH,
		:new.CD_CHAPITRE_OH__ID_CHAP,
		:new.CD_LIGNE_OH__ID_LIGNE);
		fetch c1_cd_preco__sprt_vst_oh into dummy;
		found := c1_cd_preco__sprt_vst_oh%FOUND;
		close c1_cd_preco__sprt_vst_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.SPRT_VST_OH". Impossible de modifier un enfant dans "OH.CD_PRECO__SPRT_VST_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.BPU_OH" doit exister à la création d'un enfant dans "OH.CD_PRECO__SPRT_VST_OH"
	if :new.BPU_OH__ID_BPU is not null and seq = 0 then 
		open c2_cd_preco__sprt_vst_oh ( :new.BPU_OH__ID_BPU);
		fetch c2_cd_preco__sprt_vst_oh into dummy;
		found := c2_cd_preco__sprt_vst_oh%FOUND;
		close c2_cd_preco__sprt_vst_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.BPU_OH". Impossible de modifier un enfant dans "OH.CD_PRECO__SPRT_VST_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_CDPRESTAOH" after update
of PRESTATAIRE
on OH.CD_PRESTA_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_PRESTA_OH" dans les enfants "OH.CAMP_OH"
	if ((updating('PRESTATAIRE') and :old.PRESTATAIRE != :new.PRESTATAIRE)) then 
		update OH.CAMP_OH
		set CD_PRESTA_OH__PRESTATAIRE = :new.PRESTATAIRE  
		where CD_PRESTA_OH__PRESTATAIRE = :old.PRESTATAIRE;
	end if;
	--  Modification du code du parent "OH.CD_PRESTA_OH" dans les enfants "OH.INSPECTEUR_OH"
	if ((updating('PRESTATAIRE') and :old.PRESTATAIRE != :new.PRESTATAIRE)) then 
		update OH.INSPECTEUR_OH
		set CD_PRESTA_OH__PRESTATAIRE = :new.PRESTATAIRE  
		where CD_PRESTA_OH__PRESTATAIRE = :old.PRESTATAIRE;
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


create or replace TRIGGER "OH"."TDA_CDPRESTAOH" after delete
on OH.CD_PRESTA_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.CAMP_OH"
	delete OH.CAMP_OH
	where CD_PRESTA_OH__PRESTATAIRE = :old.PRESTATAIRE;
	
	--  Suppression des enfants dans "OH.INSPECTEUR_OH"
	delete OH.INSPECTEUR_OH
	where CD_PRESTA_OH__PRESTATAIRE = :old.PRESTATAIRE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_PREVISIONOH" before insert
on OH.PREVISION_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.DSC_OH"
	cursor c1_prevision_oh(Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.DSC_OH 
		where 
		NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.BPU_OH"
	cursor c2_prevision_oh(Vbpu_oh__id_bpu number) is
		select 1 
		from OH.BPU_OH 
		where 
		ID_BPU = Vbpu_oh__id_bpu and Vbpu_oh__id_bpu is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_CONTRAINTE_OH"
	cursor c3_prevision_oh(Vcd_contrainte_oh__type varchar) is
		select 1 
		from OH.CD_CONTRAINTE_OH 
		where 
		TYPE = Vcd_contrainte_oh__type and Vcd_contrainte_oh__type is not null;
begin

	
	--  Le parent "OH.DSC_OH" doit exister à la création d'un enfant dans "OH.PREVISION_OH"
	if :new.DSC_OH__NUM_OH is not null then 
		open c1_prevision_oh ( :new.DSC_OH__NUM_OH);
		fetch c1_prevision_oh into dummy;
		found := c1_prevision_oh%FOUND;
		close c1_prevision_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DSC_OH". Impossible de créer un enfant dans "OH.PREVISION_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.BPU_OH" doit exister à la création d'un enfant dans "OH.PREVISION_OH"
	if :new.BPU_OH__ID_BPU is not null then 
		open c2_prevision_oh ( :new.BPU_OH__ID_BPU);
		fetch c2_prevision_oh into dummy;
		found := c2_prevision_oh%FOUND;
		close c2_prevision_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.BPU_OH". Impossible de créer un enfant dans "OH.PREVISION_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_CONTRAINTE_OH" doit exister à la création d'un enfant dans "OH.PREVISION_OH"
	if :new.CD_CONTRAINTE_OH__TYPE is not null then 
		open c3_prevision_oh ( :new.CD_CONTRAINTE_OH__TYPE);
		fetch c3_prevision_oh into dummy;
		found := c3_prevision_oh%FOUND;
		close c3_prevision_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_CONTRAINTE_OH". Impossible de créer un enfant dans "OH.PREVISION_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_PREVISIONOH" before update
on OH.PREVISION_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.DSC_OH"
	cursor c1_prevision_oh (Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.DSC_OH 
		where 
		NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.BPU_OH"
	cursor c2_prevision_oh (Vbpu_oh__id_bpu number) is
		select 1 
		from OH.BPU_OH 
		where 
		ID_BPU = Vbpu_oh__id_bpu and Vbpu_oh__id_bpu is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_CONTRAINTE_OH"
	cursor c3_prevision_oh (Vcd_contrainte_oh__type varchar) is
		select 1 
		from OH.CD_CONTRAINTE_OH 
		where 
		TYPE = Vcd_contrainte_oh__type and Vcd_contrainte_oh__type is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.DSC_OH" doit exister à la création d'un enfant dans "OH.PREVISION_OH"
	if :new.DSC_OH__NUM_OH is not null and seq = 0 then 
		open c1_prevision_oh ( :new.DSC_OH__NUM_OH);
		fetch c1_prevision_oh into dummy;
		found := c1_prevision_oh%FOUND;
		close c1_prevision_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DSC_OH". Impossible de modifier un enfant dans "OH.PREVISION_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.BPU_OH" doit exister à la création d'un enfant dans "OH.PREVISION_OH"
	if :new.BPU_OH__ID_BPU is not null and seq = 0 then 
		open c2_prevision_oh ( :new.BPU_OH__ID_BPU);
		fetch c2_prevision_oh into dummy;
		found := c2_prevision_oh%FOUND;
		close c2_prevision_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.BPU_OH". Impossible de modifier un enfant dans "OH.PREVISION_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_CONTRAINTE_OH" doit exister à la création d'un enfant dans "OH.PREVISION_OH"
	if :new.CD_CONTRAINTE_OH__TYPE is not null and seq = 0 then 
		open c3_prevision_oh ( :new.CD_CONTRAINTE_OH__TYPE);
		fetch c3_prevision_oh into dummy;
		found := c3_prevision_oh%FOUND;
		close c3_prevision_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_CONTRAINTE_OH". Impossible de modifier un enfant dans "OH.PREVISION_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_CDPROAMOH" after update
of PROTECT
on OH.CD_PRO_AM_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_PRO_AM_OH" dans les enfants "OH.DSC_OH"
	if ((updating('PROTECT') and :old.PROTECT != :new.PROTECT)) then 
		update OH.DSC_OH
		set CD_PRO_AM_OH__PROTECT = :new.PROTECT  
		where CD_PRO_AM_OH__PROTECT = :old.PROTECT;
	end if;
	--  Modification du code du parent "OH.CD_PRO_AM_OH" dans les enfants "OH.DSC_TEMP_OH"
	if ((updating('PROTECT') and :old.PROTECT != :new.PROTECT)) then 
		update OH.DSC_TEMP_OH
		set CD_PRO_AM_OH__PROTECT = :new.PROTECT  
		where CD_PRO_AM_OH__PROTECT = :old.PROTECT;
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


create or replace TRIGGER "OH"."TDA_CDPROAMOH" after delete
on OH.CD_PRO_AM_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.DSC_OH"
	delete OH.DSC_OH
	where CD_PRO_AM_OH__PROTECT = :old.PROTECT;
	
	--  Suppression des enfants dans "OH.DSC_TEMP_OH"
	delete OH.DSC_TEMP_OH
	where CD_PRO_AM_OH__PROTECT = :old.PROTECT;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDPROAVOH" after update
of PROTECT
on OH.CD_PRO_AV_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_PRO_AV_OH" dans les enfants "OH.DSC_OH"
	if ((updating('PROTECT') and :old.PROTECT != :new.PROTECT)) then 
		update OH.DSC_OH
		set CD_PRO_AV_OH__PROTECT = :new.PROTECT  
		where CD_PRO_AV_OH__PROTECT = :old.PROTECT;
	end if;
	--  Modification du code du parent "OH.CD_PRO_AV_OH" dans les enfants "OH.DSC_TEMP_OH"
	if ((updating('PROTECT') and :old.PROTECT != :new.PROTECT)) then 
		update OH.DSC_TEMP_OH
		set CD_PRO_AV_OH__PROTECT = :new.PROTECT  
		where CD_PRO_AV_OH__PROTECT = :old.PROTECT;
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


create or replace TRIGGER "OH"."TDA_CDPROAVOH" after delete
on OH.CD_PRO_AV_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.DSC_OH"
	delete OH.DSC_OH
	where CD_PRO_AV_OH__PROTECT = :old.PROTECT;
	
	--  Suppression des enfants dans "OH.DSC_TEMP_OH"
	delete OH.DSC_TEMP_OH
	where CD_PRO_AV_OH__PROTECT = :old.PROTECT;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_ENTETEOH" before insert
on OH.ENTETE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_ENTETE_OH"
	cursor c1_entete_oh(Vcd_entete_oh__id_entete number) is
		select 1 
		from OH.CD_ENTETE_OH 
		where 
		ID_ENTETE = Vcd_entete_oh__id_entete and Vcd_entete_oh__id_entete is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.VST_OH"
	cursor c2_entete_oh(Vcamp_oh__id_camp varchar,
	Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.VST_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_OH__NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
begin

	
	--  Le parent "OH.CD_ENTETE_OH" doit exister à la création d'un enfant dans "OH.ENTETE_OH"
	if :new.CD_ENTETE_OH__ID_ENTETE is not null then 
		open c1_entete_oh ( :new.CD_ENTETE_OH__ID_ENTETE);
		fetch c1_entete_oh into dummy;
		found := c1_entete_oh%FOUND;
		close c1_entete_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_ENTETE_OH". Impossible de créer un enfant dans "OH.ENTETE_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.VST_OH" doit exister à la création d'un enfant dans "OH.ENTETE_OH"
	if :new.CAMP_OH__ID_CAMP is not null and 
	:new.DSC_OH__NUM_OH is not null then 
		open c2_entete_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_OH__NUM_OH);
		fetch c2_entete_oh into dummy;
		found := c2_entete_oh%FOUND;
		close c2_entete_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.VST_OH". Impossible de créer un enfant dans "OH.ENTETE_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_ENTETEOH" before update
on OH.ENTETE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_ENTETE_OH"
	cursor c1_entete_oh (Vcd_entete_oh__id_entete number) is
		select 1 
		from OH.CD_ENTETE_OH 
		where 
		ID_ENTETE = Vcd_entete_oh__id_entete and Vcd_entete_oh__id_entete is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.VST_OH"
	cursor c2_entete_oh (Vcamp_oh__id_camp varchar,
	Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.VST_OH 
		where 
		CAMP_OH__ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null and 
		DSC_OH__NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.CD_ENTETE_OH" doit exister à la création d'un enfant dans "OH.ENTETE_OH"
	if :new.CD_ENTETE_OH__ID_ENTETE is not null and seq = 0 then 
		open c1_entete_oh ( :new.CD_ENTETE_OH__ID_ENTETE);
		fetch c1_entete_oh into dummy;
		found := c1_entete_oh%FOUND;
		close c1_entete_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_ENTETE_OH". Impossible de modifier un enfant dans "OH.ENTETE_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.VST_OH" doit exister à la création d'un enfant dans "OH.ENTETE_OH"
	if :new.CAMP_OH__ID_CAMP is not null and seq = 0 and 
	:new.DSC_OH__NUM_OH is not null and seq = 0 then 
		open c2_entete_oh ( :new.CAMP_OH__ID_CAMP,
		:new.DSC_OH__NUM_OH);
		fetch c2_entete_oh into dummy;
		found := c2_entete_oh%FOUND;
		close c2_entete_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.VST_OH". Impossible de modifier un enfant dans "OH.ENTETE_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TIB_SEUILQUALITEOH" before insert
on OH.SEUIL_QUALITE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_QUALITE_OH"
	cursor c1_seuil_qualite_oh(Vcd_qualite_oh__qualite varchar) is
		select 1 
		from OH.CD_QUALITE_OH 
		where 
		QUALITE = Vcd_qualite_oh__qualite and Vcd_qualite_oh__qualite is not null;
begin

	
	--  Le parent "OH.CD_QUALITE_OH" doit exister à la création d'un enfant dans "OH.SEUIL_QUALITE_OH"
	if :new.CD_QUALITE_OH__QUALITE is not null then 
		open c1_seuil_qualite_oh ( :new.CD_QUALITE_OH__QUALITE);
		fetch c1_seuil_qualite_oh into dummy;
		found := c1_seuil_qualite_oh%FOUND;
		close c1_seuil_qualite_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_QUALITE_OH". Impossible de créer un enfant dans "OH.SEUIL_QUALITE_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_SEUILQUALITEOH" before update
on OH.SEUIL_QUALITE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_QUALITE_OH"
	cursor c1_seuil_qualite_oh (Vcd_qualite_oh__qualite varchar) is
		select 1 
		from OH.CD_QUALITE_OH 
		where 
		QUALITE = Vcd_qualite_oh__qualite and Vcd_qualite_oh__qualite is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.CD_QUALITE_OH" doit exister à la création d'un enfant dans "OH.SEUIL_QUALITE_OH"
	if :new.CD_QUALITE_OH__QUALITE is not null and seq = 0 then 
		open c1_seuil_qualite_oh ( :new.CD_QUALITE_OH__QUALITE);
		fetch c1_seuil_qualite_oh into dummy;
		found := c1_seuil_qualite_oh%FOUND;
		close c1_seuil_qualite_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_QUALITE_OH". Impossible de modifier un enfant dans "OH.SEUIL_QUALITE_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TIB_SPRTOH" before insert
on OH.SPRT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.PRT_OH"
	cursor c1_sprt_oh(Vgrp_oh__id_grp number,
	Vprt_oh__id_prt number) is
		select 1 
		from OH.PRT_OH 
		where 
		GRP_OH__ID_GRP = Vgrp_oh__id_grp and Vgrp_oh__id_grp is not null and 
		ID_PRT = Vprt_oh__id_prt and Vprt_oh__id_prt is not null;
begin

	
	--  Le parent "OH.PRT_OH" doit exister à la création d'un enfant dans "OH.SPRT_OH"
	if :new.GRP_OH__ID_GRP is not null and 
	:new.PRT_OH__ID_PRT is not null then 
		open c1_sprt_oh ( :new.GRP_OH__ID_GRP,
		:new.PRT_OH__ID_PRT);
		fetch c1_sprt_oh into dummy;
		found := c1_sprt_oh%FOUND;
		close c1_sprt_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.PRT_OH". Impossible de créer un enfant dans "OH.SPRT_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_SPRTOH" before update
on OH.SPRT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.PRT_OH"
	cursor c1_sprt_oh (Vgrp_oh__id_grp number,
	Vprt_oh__id_prt number) is
		select 1 
		from OH.PRT_OH 
		where 
		GRP_OH__ID_GRP = Vgrp_oh__id_grp and Vgrp_oh__id_grp is not null and 
		ID_PRT = Vprt_oh__id_prt and Vprt_oh__id_prt is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.PRT_OH" doit exister à la création d'un enfant dans "OH.SPRT_OH"
	if :new.GRP_OH__ID_GRP is not null and seq = 0 and 
	:new.PRT_OH__ID_PRT is not null and seq = 0 then 
		open c1_sprt_oh ( :new.GRP_OH__ID_GRP,
		:new.PRT_OH__ID_PRT);
		fetch c1_sprt_oh into dummy;
		found := c1_sprt_oh%FOUND;
		close c1_sprt_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.PRT_OH". Impossible de modifier un enfant dans "OH.SPRT_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_SPRTOH" after update
of GRP_OH__ID_GRP,PRT_OH__ID_PRT,ID_SPRT
on OH.SPRT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.SPRT_OH" dans les enfants "OH.ELT_OH"
	if ((updating('GRP_OH__ID_GRP') and :old.GRP_OH__ID_GRP != :new.GRP_OH__ID_GRP) or 
	(updating('PRT_OH__ID_PRT') and :old.PRT_OH__ID_PRT != :new.PRT_OH__ID_PRT) or 
	(updating('ID_SPRT') and :old.ID_SPRT != :new.ID_SPRT)) then 
		update OH.ELT_OH
		set GRP_OH__ID_GRP = :new.GRP_OH__ID_GRP,
		PRT_OH__ID_PRT = :new.PRT_OH__ID_PRT,
		SPRT_OH__ID_SPRT = :new.ID_SPRT  
		where GRP_OH__ID_GRP = :old.GRP_OH__ID_GRP and 
		PRT_OH__ID_PRT = :old.PRT_OH__ID_PRT and 
		SPRT_OH__ID_SPRT = :old.ID_SPRT;
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


create or replace TRIGGER "OH"."TDA_SPRTOH" after delete
on OH.SPRT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.ELT_OH"
	delete OH.ELT_OH
	where GRP_OH__ID_GRP = :old.GRP_OH__ID_GRP and 
	PRT_OH__ID_PRT = :old.PRT_OH__ID_PRT and 
	SPRT_OH__ID_SPRT = :old.ID_SPRT;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDSOUSTYPEOH" after update
of SOUS_TYPE
on OH.CD_SOUS_TYPE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_SOUS_TYPE_OH" dans les enfants "OH.DSC_OH"
	if ((updating('SOUS_TYPE') and :old.SOUS_TYPE != :new.SOUS_TYPE)) then 
		update OH.DSC_OH
		set CD_SOUS_TYPE_OH__SOUS_TYPE = :new.SOUS_TYPE  
		where CD_SOUS_TYPE_OH__SOUS_TYPE = :old.SOUS_TYPE;
	end if;
	--  Modification du code du parent "OH.CD_SOUS_TYPE_OH" dans les enfants "OH.DSC_TEMP_OH"
	if ((updating('SOUS_TYPE') and :old.SOUS_TYPE != :new.SOUS_TYPE)) then 
		update OH.DSC_TEMP_OH
		set CD_SOUS_TYPE_OH__SOUS_TYPE = :new.SOUS_TYPE  
		where CD_SOUS_TYPE_OH__SOUS_TYPE = :old.SOUS_TYPE;
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


create or replace TRIGGER "OH"."TDA_CDSOUSTYPEOH" after delete
on OH.CD_SOUS_TYPE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.DSC_OH"
	delete OH.DSC_OH
	where CD_SOUS_TYPE_OH__SOUS_TYPE = :old.SOUS_TYPE;
	
	--  Suppression des enfants dans "OH.DSC_TEMP_OH"
	delete OH.DSC_TEMP_OH
	where CD_SOUS_TYPE_OH__SOUS_TYPE = :old.SOUS_TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_TRAVAUXOH" before insert
on OH.TRAVAUX_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.DSC_OH"
	cursor c1_travaux_oh(Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.DSC_OH 
		where 
		NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.NATURE_TRAV_OH"
	cursor c2_travaux_oh(Vcd_travaux_oh__code varchar,
	Vnature_trav_oh__nature varchar) is
		select 1 
		from OH.NATURE_TRAV_OH 
		where 
		CD_TRAVAUX_OH__CODE = Vcd_travaux_oh__code and Vcd_travaux_oh__code is not null and 
		NATURE = Vnature_trav_oh__nature and Vnature_trav_oh__nature is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CD_ENTP_OH"
	cursor c3_travaux_oh(Vcd_entp_oh__entreprise varchar) is
		select 1 
		from OH.CD_ENTP_OH 
		where 
		ENTREPRISE = Vcd_entp_oh__entreprise and Vcd_entp_oh__entreprise is not null;
begin

	
	--  Le parent "OH.DSC_OH" doit exister à la création d'un enfant dans "OH.TRAVAUX_OH"
	if :new.DSC_OH__NUM_OH is not null then 
		open c1_travaux_oh ( :new.DSC_OH__NUM_OH);
		fetch c1_travaux_oh into dummy;
		found := c1_travaux_oh%FOUND;
		close c1_travaux_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DSC_OH". Impossible de créer un enfant dans "OH.TRAVAUX_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.NATURE_TRAV_OH" doit exister à la création d'un enfant dans "OH.TRAVAUX_OH"
	if :new.CD_TRAVAUX_OH__CODE is not null and 
	:new.NATURE_TRAV_OH__NATURE is not null then 
		open c2_travaux_oh ( :new.CD_TRAVAUX_OH__CODE,
		:new.NATURE_TRAV_OH__NATURE);
		fetch c2_travaux_oh into dummy;
		found := c2_travaux_oh%FOUND;
		close c2_travaux_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.NATURE_TRAV_OH". Impossible de créer un enfant dans "OH.TRAVAUX_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_ENTP_OH" doit exister à la création d'un enfant dans "OH.TRAVAUX_OH"
	if :new.CD_ENTP_OH__ENTREPRISE is not null then 
		open c3_travaux_oh ( :new.CD_ENTP_OH__ENTREPRISE);
		fetch c3_travaux_oh into dummy;
		found := c3_travaux_oh%FOUND;
		close c3_travaux_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_ENTP_OH". Impossible de créer un enfant dans "OH.TRAVAUX_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_TRAVAUXOH" before update
on OH.TRAVAUX_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.DSC_OH"
	cursor c1_travaux_oh (Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.DSC_OH 
		where 
		NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.NATURE_TRAV_OH"
	cursor c2_travaux_oh (Vcd_travaux_oh__code varchar,
	Vnature_trav_oh__nature varchar) is
		select 1 
		from OH.NATURE_TRAV_OH 
		where 
		CD_TRAVAUX_OH__CODE = Vcd_travaux_oh__code and Vcd_travaux_oh__code is not null and 
		NATURE = Vnature_trav_oh__nature and Vnature_trav_oh__nature is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CD_ENTP_OH"
	cursor c3_travaux_oh (Vcd_entp_oh__entreprise varchar) is
		select 1 
		from OH.CD_ENTP_OH 
		where 
		ENTREPRISE = Vcd_entp_oh__entreprise and Vcd_entp_oh__entreprise is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.DSC_OH" doit exister à la création d'un enfant dans "OH.TRAVAUX_OH"
	if :new.DSC_OH__NUM_OH is not null and seq = 0 then 
		open c1_travaux_oh ( :new.DSC_OH__NUM_OH);
		fetch c1_travaux_oh into dummy;
		found := c1_travaux_oh%FOUND;
		close c1_travaux_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DSC_OH". Impossible de modifier un enfant dans "OH.TRAVAUX_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.NATURE_TRAV_OH" doit exister à la création d'un enfant dans "OH.TRAVAUX_OH"
	if :new.CD_TRAVAUX_OH__CODE is not null and seq = 0 and 
	:new.NATURE_TRAV_OH__NATURE is not null and seq = 0 then 
		open c2_travaux_oh ( :new.CD_TRAVAUX_OH__CODE,
		:new.NATURE_TRAV_OH__NATURE);
		fetch c2_travaux_oh into dummy;
		found := c2_travaux_oh%FOUND;
		close c2_travaux_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.NATURE_TRAV_OH". Impossible de modifier un enfant dans "OH.TRAVAUX_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.CD_ENTP_OH" doit exister à la création d'un enfant dans "OH.TRAVAUX_OH"
	if :new.CD_ENTP_OH__ENTREPRISE is not null and seq = 0 then 
		open c3_travaux_oh ( :new.CD_ENTP_OH__ENTREPRISE);
		fetch c3_travaux_oh into dummy;
		found := c3_travaux_oh%FOUND;
		close c3_travaux_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CD_ENTP_OH". Impossible de modifier un enfant dans "OH.TRAVAUX_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_CDCOMPOSANTOH" after update
of TYPE_COMP
on OH.CD_COMPOSANT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_COMPOSANT_OH" dans les enfants "OH.CD_ENTETE_OH"
	if ((updating('TYPE_COMP') and :old.TYPE_COMP != :new.TYPE_COMP)) then 
		update OH.CD_ENTETE_OH
		set CD_COMPOSANT_OH__TYPE_COMP = :new.TYPE_COMP  
		where CD_COMPOSANT_OH__TYPE_COMP = :old.TYPE_COMP;
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


create or replace TRIGGER "OH"."TDA_CDCOMPOSANTOH" after delete
on OH.CD_COMPOSANT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.CD_ENTETE_OH"
	delete OH.CD_ENTETE_OH
	where CD_COMPOSANT_OH__TYPE_COMP = :old.TYPE_COMP;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDDOCOH" after update
of CODE
on OH.CD_DOC_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_DOC_OH" dans les enfants "OH.DOC_OH"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update OH.DOC_OH
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


create or replace TRIGGER "OH"."TDA_CDDOCOH" after delete
on OH.CD_DOC_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.DOC_OH"
	delete OH.DOC_OH
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


create or replace TRIGGER "OH"."TUA_CDEVTOH" after update
of TYPE
on OH.CD_EVT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_EVT_OH" dans les enfants "OH.EVT_OH"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update OH.EVT_OH
		set CD_EVT_OH__TYPE = :new.TYPE  
		where CD_EVT_OH__TYPE = :old.TYPE;
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


create or replace TRIGGER "OH"."TDA_CDEVTOH" after delete
on OH.CD_EVT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.EVT_OH"
	delete OH.EVT_OH
	where CD_EVT_OH__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDEXTOH" after update
of TYPE
on OH.CD_EXT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_EXT_OH" dans les enfants "OH.DSC_OH"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update OH.DSC_OH
		set CD_EXT_OH__TYPE = :new.TYPE  
		where CD_EXT_OH__TYPE = :old.TYPE;
	end if;
	--  Modification du code du parent "OH.CD_EXT_OH" dans les enfants "OH.DSC_TEMP_OH"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update OH.DSC_TEMP_OH
		set CD_EXT_OH__TYPE = :new.TYPE  
		where CD_EXT_OH__TYPE = :old.TYPE;
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


create or replace TRIGGER "OH"."TDA_CDEXTOH" after delete
on OH.CD_EXT_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.DSC_OH"
	delete OH.DSC_OH
	where CD_EXT_OH__TYPE = :old.TYPE;
	
	--  Suppression des enfants dans "OH.DSC_TEMP_OH"
	delete OH.DSC_TEMP_OH
	where CD_EXT_OH__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDOUVOH" after update
of OUV
on OH.CD_OUV_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_OUV_OH" dans les enfants "OH.DSC_OH"
	if ((updating('OUV') and :old.OUV != :new.OUV)) then 
		update OH.DSC_OH
		set CD_OUV_OH__OUV = :new.OUV  
		where CD_OUV_OH__OUV = :old.OUV;
	end if;
	--  Modification du code du parent "OH.CD_OUV_OH" dans les enfants "OH.DSC_TEMP_OH"
	if ((updating('OUV') and :old.OUV != :new.OUV)) then 
		update OH.DSC_TEMP_OH
		set CD_OUV_OH__OUV = :new.OUV  
		where CD_OUV_OH__OUV = :old.OUV;
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


create or replace TRIGGER "OH"."TDA_CDOUVOH" after delete
on OH.CD_OUV_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.DSC_OH"
	delete OH.DSC_OH
	where CD_OUV_OH__OUV = :old.OUV;
	
	--  Suppression des enfants dans "OH.DSC_TEMP_OH"
	delete OH.DSC_TEMP_OH
	where CD_OUV_OH__OUV = :old.OUV;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDTYPEOH" after update
of TYPE
on OH.CD_TYPE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_TYPE_OH" dans les enfants "OH.DSC_OH"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update OH.DSC_OH
		set CD_TYPE_OH__TYPE = :new.TYPE  
		where CD_TYPE_OH__TYPE = :old.TYPE;
	end if;
	--  Modification du code du parent "OH.CD_TYPE_OH" dans les enfants "OH.DSC_TEMP_OH"
	if ((updating('TYPE') and :old.TYPE != :new.TYPE)) then 
		update OH.DSC_TEMP_OH
		set CD_TYPE_OH__TYPE = :new.TYPE  
		where CD_TYPE_OH__TYPE = :old.TYPE;
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


create or replace TRIGGER "OH"."TDA_CDTYPEOH" after delete
on OH.CD_TYPE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.DSC_OH"
	delete OH.DSC_OH
	where CD_TYPE_OH__TYPE = :old.TYPE;
	
	--  Suppression des enfants dans "OH.DSC_TEMP_OH"
	delete OH.DSC_TEMP_OH
	where CD_TYPE_OH__TYPE = :old.TYPE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDTYPEPVOH" after update
of CODE
on OH.CD_TYPE_PV_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_TYPE_PV_OH" dans les enfants "OH.CAMP_OH"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update OH.CAMP_OH
		set CD_TYPE_PV_OH__CODE = :new.CODE  
		where CD_TYPE_PV_OH__CODE = :old.CODE;
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


create or replace TRIGGER "OH"."TDA_CDTYPEPVOH" after delete
on OH.CD_TYPE_PV_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.CAMP_OH"
	delete OH.CAMP_OH
	where CD_TYPE_PV_OH__CODE = :old.CODE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDTETEAMOH" after update
of TETE_AM
on OH.CD_TETE_AM_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_TETE_AM_OH" dans les enfants "OH.DSC_OH"
	if ((updating('TETE_AM') and :old.TETE_AM != :new.TETE_AM)) then 
		update OH.DSC_OH
		set CD_TETE_AM_OH__TETE_AM = :new.TETE_AM  
		where CD_TETE_AM_OH__TETE_AM = :old.TETE_AM;
	end if;
	--  Modification du code du parent "OH.CD_TETE_AM_OH" dans les enfants "OH.DSC_TEMP_OH"
	if ((updating('TETE_AM') and :old.TETE_AM != :new.TETE_AM)) then 
		update OH.DSC_TEMP_OH
		set CD_TETE_AM_OH__TETE_AM = :new.TETE_AM  
		where CD_TETE_AM_OH__TETE_AM = :old.TETE_AM;
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


create or replace TRIGGER "OH"."TDA_CDTETEAMOH" after delete
on OH.CD_TETE_AM_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.DSC_OH"
	delete OH.DSC_OH
	where CD_TETE_AM_OH__TETE_AM = :old.TETE_AM;
	
	--  Suppression des enfants dans "OH.DSC_TEMP_OH"
	delete OH.DSC_TEMP_OH
	where CD_TETE_AM_OH__TETE_AM = :old.TETE_AM;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDTETEAVOH" after update
of TETE_AV
on OH.CD_TETE_AV_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_TETE_AV_OH" dans les enfants "OH.DSC_OH"
	if ((updating('TETE_AV') and :old.TETE_AV != :new.TETE_AV)) then 
		update OH.DSC_OH
		set CD_TETE_AV_OH__TETE_AV = :new.TETE_AV  
		where CD_TETE_AV_OH__TETE_AV = :old.TETE_AV;
	end if;
	--  Modification du code du parent "OH.CD_TETE_AV_OH" dans les enfants "OH.DSC_TEMP_OH"
	if ((updating('TETE_AV') and :old.TETE_AV != :new.TETE_AV)) then 
		update OH.DSC_TEMP_OH
		set CD_TETE_AV_OH__TETE_AV = :new.TETE_AV  
		where CD_TETE_AV_OH__TETE_AV = :old.TETE_AV;
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


create or replace TRIGGER "OH"."TDA_CDTETEAVOH" after delete
on OH.CD_TETE_AV_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.DSC_OH"
	delete OH.DSC_OH
	where CD_TETE_AV_OH__TETE_AV = :old.TETE_AV;
	
	--  Suppression des enfants dans "OH.DSC_TEMP_OH"
	delete OH.DSC_TEMP_OH
	where CD_TETE_AV_OH__TETE_AV = :old.TETE_AV;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDTRAVAUXOH" after update
of CODE
on OH.CD_TRAVAUX_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_TRAVAUX_OH" dans les enfants "OH.NATURE_TRAV_OH"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update OH.NATURE_TRAV_OH
		set CD_TRAVAUX_OH__CODE = :new.CODE  
		where CD_TRAVAUX_OH__CODE = :old.CODE;
	end if;
	--  Modification du code du parent "OH.CD_TRAVAUX_OH" dans les enfants "OH.BPU_OH"
	if ((updating('CODE') and :old.CODE != :new.CODE)) then 
		update OH.BPU_OH
		set CD_TRAVAUX_OH__CODE = :new.CODE  
		where CD_TRAVAUX_OH__CODE = :old.CODE;
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


create or replace TRIGGER "OH"."TDA_CDTRAVAUXOH" after delete
on OH.CD_TRAVAUX_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.NATURE_TRAV_OH"
	delete OH.NATURE_TRAV_OH
	where CD_TRAVAUX_OH__CODE = :old.CODE;
	
	--  Suppression des enfants dans "OH.BPU_OH"
	delete OH.BPU_OH
	where CD_TRAVAUX_OH__CODE = :old.CODE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TUA_CDUNITEOH" after update
of UNITE
on OH.CD_UNITE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.CD_UNITE_OH" dans les enfants "OH.BPU_OH"
	if ((updating('UNITE') and :old.UNITE != :new.UNITE)) then 
		update OH.BPU_OH
		set CD_UNITE_OH__UNITE = :new.UNITE  
		where CD_UNITE_OH__UNITE = :old.UNITE;
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


create or replace TRIGGER "OH"."TDA_CDUNITEOH" after delete
on OH.CD_UNITE_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.BPU_OH"
	delete OH.BPU_OH
	where CD_UNITE_OH__UNITE = :old.UNITE;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


create or replace TRIGGER "OH"."TIB_VSTOH" before insert
on OH.VST_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.CAMP_OH"
	cursor c1_vst_oh(Vcamp_oh__id_camp varchar) is
		select 1 
		from OH.CAMP_OH 
		where 
		ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.DSC_OH"
	cursor c2_vst_oh(Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.DSC_OH 
		where 
		NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
	
	--  Déclaration de la contrainte InsertChildParentExist pour le parent "OH.INSPECTEUR_OH"
	cursor c3_vst_oh(Vinspecteur_oh__nom varchar) is
		select 1 
		from OH.INSPECTEUR_OH 
		where 
		NOM = Vinspecteur_oh__nom and Vinspecteur_oh__nom is not null;
begin

	
	--  Le parent "OH.CAMP_OH" doit exister à la création d'un enfant dans "OH.VST_OH"
	if :new.CAMP_OH__ID_CAMP is not null then 
		open c1_vst_oh ( :new.CAMP_OH__ID_CAMP);
		fetch c1_vst_oh into dummy;
		found := c1_vst_oh%FOUND;
		close c1_vst_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CAMP_OH". Impossible de créer un enfant dans "OH.VST_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.DSC_OH" doit exister à la création d'un enfant dans "OH.VST_OH"
	if :new.DSC_OH__NUM_OH is not null then 
		open c2_vst_oh ( :new.DSC_OH__NUM_OH);
		fetch c2_vst_oh into dummy;
		found := c2_vst_oh%FOUND;
		close c2_vst_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DSC_OH". Impossible de créer un enfant dans "OH.VST_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.INSPECTEUR_OH" doit exister à la création d'un enfant dans "OH.VST_OH"
	if :new.INSPECTEUR_OH__NOM is not null then 
		open c3_vst_oh ( :new.INSPECTEUR_OH__NOM);
		fetch c3_vst_oh into dummy;
		found := c3_vst_oh%FOUND;
		close c3_vst_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.INSPECTEUR_OH". Impossible de créer un enfant dans "OH.VST_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUB_VSTOH" before update
on OH.VST_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	seq              number;
	found            boolean;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.CAMP_OH"
	cursor c1_vst_oh (Vcamp_oh__id_camp varchar) is
		select 1 
		from OH.CAMP_OH 
		where 
		ID_CAMP = Vcamp_oh__id_camp and Vcamp_oh__id_camp is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.DSC_OH"
	cursor c2_vst_oh (Vdsc_oh__num_oh varchar) is
		select 1 
		from OH.DSC_OH 
		where 
		NUM_OH = Vdsc_oh__num_oh and Vdsc_oh__num_oh is not null;
	--  Déclaration de la contrainte UpdateChildParentExist pour le parent "OH.INSPECTEUR_OH"
	cursor c3_vst_oh (Vinspecteur_oh__nom varchar) is
		select 1 
		from OH.INSPECTEUR_OH 
		where 
		NOM = Vinspecteur_oh__nom and Vinspecteur_oh__nom is not null;
begin

	seq := IntegrityPackage.GetNestLevel;
	
	--  Le parent "OH.CAMP_OH" doit exister à la création d'un enfant dans "OH.VST_OH"
	if :new.CAMP_OH__ID_CAMP is not null and seq = 0 then 
		open c1_vst_oh ( :new.CAMP_OH__ID_CAMP);
		fetch c1_vst_oh into dummy;
		found := c1_vst_oh%FOUND;
		close c1_vst_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.CAMP_OH". Impossible de modifier un enfant dans "OH.VST_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.DSC_OH" doit exister à la création d'un enfant dans "OH.VST_OH"
	if :new.DSC_OH__NUM_OH is not null and seq = 0 then 
		open c2_vst_oh ( :new.DSC_OH__NUM_OH);
		fetch c2_vst_oh into dummy;
		found := c2_vst_oh%FOUND;
		close c2_vst_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.DSC_OH". Impossible de modifier un enfant dans "OH.VST_OH".';
			raise integrity_error;
		end if;
	end if;
	
	--  Le parent "OH.INSPECTEUR_OH" doit exister à la création d'un enfant dans "OH.VST_OH"
	if :new.INSPECTEUR_OH__NOM is not null and seq = 0 then 
		open c3_vst_oh ( :new.INSPECTEUR_OH__NOM);
		fetch c3_vst_oh into dummy;
		found := c3_vst_oh%FOUND;
		close c3_vst_oh;
		if not found then
			errno  := -20002;
			errmsg := 'Le parent n''''existe pas dans "OH.INSPECTEUR_OH". Impossible de modifier un enfant dans "OH.VST_OH".';
			raise integrity_error;
		end if;
	end if;

--  Traitement d'erreurs
exception
	when integrity_error then
		raise_application_error(errno, errmsg);
end;
/


create or replace TRIGGER "OH"."TUA_VSTOH" after update
of CAMP_OH__ID_CAMP,DSC_OH__NUM_OH
on OH.VST_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Modification du code du parent "OH.VST_OH" dans les enfants "OH.SPRT_VST_OH"
	if ((updating('CAMP_OH__ID_CAMP') and :old.CAMP_OH__ID_CAMP != :new.CAMP_OH__ID_CAMP) or 
	(updating('DSC_OH__NUM_OH') and :old.DSC_OH__NUM_OH != :new.DSC_OH__NUM_OH)) then 
		update OH.SPRT_VST_OH
		set CAMP_OH__ID_CAMP = :new.CAMP_OH__ID_CAMP,
		DSC_OH__NUM_OH = :new.DSC_OH__NUM_OH  
		where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
		DSC_OH__NUM_OH = :old.DSC_OH__NUM_OH;
	end if;
	--  Modification du code du parent "OH.VST_OH" dans les enfants "OH.PHOTO_VST_OH"
	if ((updating('CAMP_OH__ID_CAMP') and :old.CAMP_OH__ID_CAMP != :new.CAMP_OH__ID_CAMP) or 
	(updating('DSC_OH__NUM_OH') and :old.DSC_OH__NUM_OH != :new.DSC_OH__NUM_OH)) then 
		update OH.PHOTO_VST_OH
		set CAMP_OH__ID_CAMP = :new.CAMP_OH__ID_CAMP,
		DSC_OH__NUM_OH = :new.DSC_OH__NUM_OH  
		where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
		DSC_OH__NUM_OH = :old.DSC_OH__NUM_OH;
	end if;
	--  Modification du code du parent "OH.VST_OH" dans les enfants "OH.ENTETE_OH"
	if ((updating('CAMP_OH__ID_CAMP') and :old.CAMP_OH__ID_CAMP != :new.CAMP_OH__ID_CAMP) or 
	(updating('DSC_OH__NUM_OH') and :old.DSC_OH__NUM_OH != :new.DSC_OH__NUM_OH)) then 
		update OH.ENTETE_OH
		set CAMP_OH__ID_CAMP = :new.CAMP_OH__ID_CAMP,
		DSC_OH__NUM_OH = :new.DSC_OH__NUM_OH  
		where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
		DSC_OH__NUM_OH = :old.DSC_OH__NUM_OH;
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


create or replace TRIGGER "OH"."TDA_VSTOH" after delete
on OH.VST_OH for each row
declare
	integrity_error  exception;
	errno            integer;
	errmsg           char(200);
	dummy            integer;
	found            boolean;
begin
	IntegrityPackage.NextNestLevel;
	--  Suppression des enfants dans "OH.SPRT_VST_OH"
	delete OH.SPRT_VST_OH
	where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
	DSC_OH__NUM_OH = :old.DSC_OH__NUM_OH;
	
	--  Suppression des enfants dans "OH.PHOTO_VST_OH"
	delete OH.PHOTO_VST_OH
	where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
	DSC_OH__NUM_OH = :old.DSC_OH__NUM_OH;
	
	--  Suppression des enfants dans "OH.ENTETE_OH"
	delete OH.ENTETE_OH
	where CAMP_OH__ID_CAMP = :old.CAMP_OH__ID_CAMP and 
	DSC_OH__NUM_OH = :old.DSC_OH__NUM_OH;
	
	IntegrityPackage.PreviousNestLevel;
exception
	when integrity_error then
		begin
		IntegrityPackage.InitNestLevel;
		 raise_application_error(errno, errmsg);
		end;
end;
/


