# Geo.Api

Api for geographical calculation.

![File](file.png)

## Distance between points on Earth

Program accepts gegraphical coordinates and produce response with distance between them. 
For eample:
```
GET ~​/api​/v1​/Earth​/surfaceDistanse​/{latitudeA}​/{longitudeA}​/{latitudeB}​/{longitudeB}
```
Will produce HTTP 200 with following body:
```json
{
  "distance": <double>
}
```