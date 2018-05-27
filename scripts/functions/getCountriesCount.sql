CREATE OR REPLACE FUNCTION getCountriesCount(
	)
    RETURNS bigint
    LANGUAGE 'plpgsql'
AS $BODY$

  DECLARE 
          total bigint;
  BEGIN
      SELECT COUNT(*) INTO total FROM country;
	  RETURN total;
  END
$BODY$;

