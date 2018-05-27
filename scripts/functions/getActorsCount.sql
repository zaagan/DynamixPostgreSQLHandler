CREATE OR REPLACE FUNCTION getActorsCount(
	)
    RETURNS bigint
    LANGUAGE 'plpgsql'
AS $BODY$

  DECLARE 
          total bigint;
  BEGIN
      SELECT COUNT(*) INTO total FROM actor;
	  RETURN total;
  END
$BODY$;

