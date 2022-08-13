# Geo.Api

Api for geographical calculation.

![File](file.png)

## Distance between points on Earth

Program accepts gegraphical coordinates and produce response with distance between them. 
For eample:
```
GET ~/api/v1/GeoDistance/latA/53.297975/longA/-6.372663/latB/41.385101/longB/-81.440440?unit=km
```
Will produce HTTP 200 with following body:
```json
{
  "distance": 5535.28
}
```