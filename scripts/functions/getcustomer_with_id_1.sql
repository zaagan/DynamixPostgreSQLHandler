CREATE OR REPLACE FUNCTION getcustomer_with_id_1()
    RETURNS SETOF customer
    LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
    RETURN QUERY (select * from customer WHERE customer_id = 1);
END
$BODY$;