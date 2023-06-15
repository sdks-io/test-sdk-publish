
# Order

## Structure

`Order`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `long?` | Optional | - |
| `PetId` | `long?` | Optional | - |
| `Quantity` | `int?` | Optional | - |
| `ShipDate` | `DateTime?` | Optional | - |
| `Status` | [`Models.Status1Enum?`](../../doc/models/status-1-enum.md) | Optional | Order Status |
| `Complete` | `bool?` | Optional | - |

## Example (as JSON)

```json
{
  "id": 112,
  "petId": 152,
  "quantity": 68,
  "shipDate": "2016-03-13T12:52:32.123Z",
  "status": "delivered"
}
```

