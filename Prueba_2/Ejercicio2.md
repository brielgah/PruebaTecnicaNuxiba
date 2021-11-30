**A continuación se muestran las ejecuciones de cada query indicadas en el ejercicio y su respuesta.**

# Query 1

---

SELECT * from logDial WHERE MONTH(fechaDeLlamada)=2 AND tipoDeLlamada="CEL LD";

| idLlamada | fechaDeLlamada | tiempoDialogo | telefono   | tipoDeLlamada |
| --------- | -------------- | ------------- | ---------- | ------------- |
| 197496    | 2020-02-03     | 240           | 8000000034 | Cel LD        |
| 197497    | 2020-02-04     | 60            | 8000000035 | Cel LD        |
| 197498    | 2020-02-05     | 240           | 8000000036 | Cel LD        |
| 197499    | 2020-02-06     | 120           | 8000000037 | Cel LD        |
| 197500    | 2020-02-07     | 95            | 8000000038 | Cel LD        |
| 197501    | 2020-02-08     | 60            | 8000000039 | Cel LD        |
| 197502    | 2020-02-09     | 60            | 8000000040 | Cel LD        |
| 197503    | 2020-02-10     | 360           | 8000000041 | Cel LD        |
| 197505    | 2020-02-12     | 60            | 8000000043 | Cel LD        |
| 197506    | 2020-02-13     | 60            | 8000000044 | Cel LD        |
| 197507    | 2020-02-14     | 120           | 8000000045 | Cel LD        |
| 197508    | 2020-02-15     | 60            | 8000000046 | Cel LD        |
| 197509    | 2020-02-16     | 60            | 8000000047 | Cel LD        |
| 197510    | 2020-02-17     | 120           | 8000000048 | Cel LD        |
| 197511    | 2020-02-18     | 120           | 8000000049 | Cel LD        |
| 197512    | 2020-02-19     | 60            | 8000000050 | Cel LD        |
| 197513    | 2020-02-20     | 85            | 8000000051 | Cel LD        |
| 197516    | 2020-02-23     | 120           | 8000000054 | Cel LD        |
| 197517    | 2020-02-24     | 120           | 8000000055 | Cel LD        |
| 197518    | 2020-02-25     | 240           | 8000000056 | Cel LD        |
| 197519    | 2020-02-26     | 60            | 8000000057 | Cel LD        |
| 197520    | 2020-02-27     | 180           | 8000000058 | Cel LD        |
| 197521    | 2020-02-28     | 180           | 8000000059 | Cel LD        |

---

![Query1](C:\Users\Testing_IT\Documents\GitHub\src\Prueba_2\imagenes\Query1.png)

# Query 2

---
SELECT AVG(tiempoDialogo) FROM logDial WHERE MONTH(fechaDeLlamada)=2 AND tipoDeLlamada="CEL LD";

| AVG(tiempoDialogo) |
| ------------------ |
| 125.2174           |

---

![Query2](C:\Users\Testing_IT\Documents\GitHub\src\Prueba_2\imagenes\Query2.png)


# Query 3

---
SELECT tiempoDialogo/60,(tiempoDialogo/60)*costo FROM logDial l LEFT JOIN costos c ON l.tipoDeLlamada = c.tipoDeLlamada WHERE MONTH(l.fechaDeLlamada)=2;

| tiempoDialogo/60 | (tiempoDialogo/60)*costo  |
| ---------------- | ------------------------- |
| 1.0000           | 0.40000000                |
| 1.0000           | 0.40000000                |
| 1.0000           | 0.40000000                |
| 1.0000           | 0.40000000                |
| 1.0000           | 0.40000000                |
| 2.0000           | 0.80000000                |
| 4.0000           | 2.00000000                |
| 1.0000           | 0.50000000                |
| 4.0000           | 2.00000000                |
| 2.0000           | 1.00000000                |
| 1.5833           | 0.79166667                |
| 1.0000           | 0.50000000                |
| 1.0000           | 0.50000000                |
| 6.0000           | 3.00000000                |
| 1.0000           | 0.50000000                |
| 1.0000           | 0.50000000                |
| 2.0000           | 1.00000000                |
| 1.0000           | 0.50000000                |
| 1.0000           | 0.50000000                |
| 2.0000           | 1.00000000                |
| 2.0000           | 1.00000000                |
| 1.0000           | 0.50000000                |
| 1.4167           | 0.70833333                |
| 2.0000           | 1.00000000                |
| 2.0000           | 1.00000000                |
| 4.0000           | 2.00000000                |
| 1.0000           | 0.50000000                |
| 3.0000           | 1.50000000                |
| 3.0000           | 1.50000000                |

---

![Query3](C:\Users\Testing_IT\Documents\GitHub\src\Prueba_2\imagenes\Query3.png)