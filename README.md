# Introduction 
If when we do the oracle db design, we have understanding the table will have a lot of data, we should use the partition table for it. Our realization generate partitions for oracle 11g but in another version or database it may be same. When we creating the partition table we writing like follow:
```sql
CREATE TABLE MY_TABLE (
  ID          NUMBER        NOT NULL,
  NAME        NVARCHAR2(50) NOT NULL,
  DATE_TIME   DATE NOT NULL
)
PARTITION BY RANGE (DATE_TIME)
(
	PARTITION P_TABLE_2_1_2018 VALUES LESS THAN (TO_DATE(' 2018-01-02 00:00:00', 'SYYYY-MM-DD HH24:MI:SS', 'NLS_CALENDAR=GREGORIAN')),
    PARTITION P_TABLE_3_1_2018 VALUES LESS THAN (TO_DATE(' 2018-01-03 00:00:00', 'SYYYY-MM-DD HH24:MI:SS', 'NLS_CALENDAR=GREGORIAN')), 
    .... 
)
```
The problem is you must write much of text for that. And you will lose your time and of course make many mistakes.

# Documentation
Our solution is console application. You can use it via cmd or powershell terminal. We must pass next arguments:

|   Name   |              Definition              | Required |         Values type         |   Sample   |
|:--------:|:------------------------------------:|:--------:|:---------------------------:|:----------:|
| prefix   | It will be used for partitions name  | true     | text one word               | my_table   |
| duration | It is step between partitions        | true     | [ d, m ]                    | d          |
| from     | Date for start partitions generation | true     | date by format = dd.mm.yyyy | 01.01.2000 |
| to       | Date for end partitions generation   | true     | date by format = dd.mm.yyyy | 01.01.2001 |
| fileName | Result will save to that file        | false    | result file name            | result.txt |

# Exsample

```cmd
pgen mytable d 01.01.2000 01.01.2001 my_part.txt
```
