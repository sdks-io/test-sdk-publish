
# Pet

## Structure

`Pet`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `long?` | Optional | - |
| `Category` | [`Models.Category`](../../doc/models/category.md) | Optional | - |
| `Name` | `string` | Required | - |
| `PhotoUrls` | `List<string>` | Required | - |
| `Tags` | [`List<Models.Tag>`](../../doc/models/tag.md) | Optional | - |
| `Status` | [`Models.StatusEnum?`](../../doc/models/status-enum.md) | Optional | pet status in the store |

## Example (as JSON)

```json
{
  "id": 112,
  "category": {
    "id": 232,
    "name": "name2"
  },
  "name": "name0",
  "photoUrls": [
    "photoUrls5",
    "photoUrls6",
    "photoUrls7"
  ],
  "tags": [
    {
      "id": 239,
      "photoUrls": [
        "photoUrls0",
        "photoUrls1",
        "photoUrls2"
      ],
      "name": "name5"
    },
    {
      "id": 240,
      "photoUrls": [
        "photoUrls1"
      ],
      "name": "name6"
    }
  ],
  "status": "sold"
}
```

