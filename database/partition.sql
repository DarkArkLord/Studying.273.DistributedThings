DROP TABLE partition_test_main;

CREATE TABLE partition_test_main (
    id INT GENERATED BY DEFAULT AS IDENTITY,
    value INT NOT NULL
) PARTITION BY RANGE (value);

CREATE TABLE partition_test_1 PARTITION OF partition_test_main
    FOR VALUES FROM (0) TO (333);

CREATE TABLE partition_test_2 PARTITION OF partition_test_main
    FOR VALUES FROM (333) TO (666);

CREATE TABLE partition_test_3 PARTITION OF partition_test_main
    FOR VALUES FROM (666) TO (1001);

--INSERT INTO partition_test_main(value)
--SELECT floor(random() * 1000 + 1)::int AS value
--FROM generate_series(1, 1000)

SELECT * FROM partition_test_main

SELECT * FROM partition_test_1

SELECT * FROM partition_test_2

SELECT * FROM partition_test_3




