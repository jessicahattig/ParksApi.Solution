### Documenting Endpoints in an API.
In this application, there are two models: the first is named (`NationalParks`), and the second is named (`StateParks`). Each model has five associated endpoints. Below, you'll find instructions on how to access each endpoint, along with details on expected responses, URLs, and parameters.

### Model:NationalParks
### GET /api/NationalParks
<table>
    <thead>
      <tr>
        <th>HTTP Verb</th>
        <th>URL</th>
        <th>Expected Behavior</th>
        <th>Response Status</th>
      </tr>
    </thead>
      <tr>
        <td>GET</td>
        <td>/api/NationalParks</td>
        <td>Returns an array containing all NationalParks objects in the database.</td>
        <td>200: Ok</td>
      </tr>
</table>

Expected Response:
```json
[
  {
    "nationalParkId": 1,
    "name": "Grand Canyon National Park",
    "location": "Arizona",
    "description": "A majestic national park known for the Grand Canyon."
  },
  {
    "nationalParkId": 2,
    "name": "Yellowstone National Park",
    "location": "Wyoming",
    "description": "The first national park with geothermal wonders."
  },
  {
    "nationalParkId": 3,
    "name": "Great Smoky Mountains National Park",
    "location": "North Carolina",
    "description": "A national park with diverse plant and animal life."
  },
  {
    "nationalParkId": 4,
    "name": "Yosemite National Park",
    "location": "California",
    "description": "Known for its waterfalls, giant sequoias, and diverse ecosystems."
  }
]
```

### GET /api/NationalParks *with optional query parameters
<table>
    <thead>
      <tr>
        <th>HTTP Verb</th>
        <th>URL</th>
        <th>Optional URL Parameters</th>
        <th>Expected Behavior</th>
        <th>Response Status</th>
      </tr>
    </thead>
      <tr>
        <td>GET</td>
        <td>/api/NationalParks?[PARAMETER NAME]=[PARAMETER VALUE]</td>
        <td>name (string) <br> location (string) <br> description (string)</td>
        <td>Returns an array containing all NationalPark objects in the database that match the included parameters, multiple parameters may be included.</td>
        <td>200: Ok</td>
      </tr>
</table>

Example Request URL: `GET /api/NationalParks?name=Grand%20Canyon&location=Arizona`


Expected Response:
```json
[
  {
    "nationalParkId": 1,
    "name": "Grand Canyon National Park",
    "location": "Arizona",
    "description": "A majestic national park known for the Grand Canyon."
  },
]
```

### GET /api/NationalParks/{id}
<table>
    <thead>
      <tr>
        <th>HTTP Verb</th>
        <th>URL</th>
        <th>URL Parameter *required</th>
        <th>Expected Behavior</th>
        <th>Response Status</th>
      </tr>
    </thead>
      <tr>
        <td>GET</td>
        <td>/api/NationalParks/{id}</td>
        <td>id (int)</td>
        <td>Returns a JSON object representing an NationalPark object with an "NationalParkId" property that matches the "id" provided as a URL parameter.</td>
        <td>200: Ok</td>
      </tr>
</table>

Example Request URL: `GET /api/NationalParks/3`

Expected Response: 

```json
{
  "nationalParkId": 3,
  "name": "Great Smoky Mountains National Park",
  "location": "North Carolina",
  "description": "A national park with diverse plant and animal life."
}
```

### POST /api/NationalParks
<table>
    <thead>
      <tr>
        <th>HTTP Verb</th>
        <th>URL</th>
        <th>Request Body *required</th>
        <th>Expected Behavior</th>
        <th>Response Status</th>
      </tr>
    </thead>
      <tr>
        <td>POST</td>
        <td>/api/NationalParks</td>
        <td>A JSON object containing key-value pairs for: <br> - name(string), <br> - location(string), <br> - description(string) <br> - nationalparkId(int) may be included but regardless of the value provided, it's value will be set by the database when the record is saved.</td>
        <td>Creates a new NationalPark object in the database.</td>
        <td>201: Created</td>
      </tr>
</table>

Example Request Body *required:

```json
{
  "name": "Crater Lake National Park",
  "location": "Oregon",
  "description": "Breathtaking landscapes with the deepest U.S. lake, nestled in a captivating volcanic caldera."
}
```

Expected Response:

```json
{
  "nationalParkId": 5,
  "name": "Crater Lake National Park",
  "location": "Oregon",
  "description": "Breathtaking landscapes with the deepest U.S. lake, nestled in a captivating volcanic caldera."
}
```

### PUT /api/NationalParks/{id}
<table>
    <thead>
      <tr>
        <th>HTTP Verb</th>
        <th>URL</th>
        <th>URL Parameter *required</th>
        <th>Request Body *required</th>
        <th>Expected Response</th>
        <th>Response Status</th>
      </tr>
    </thead>
      <tr>
        <td>PUT</td>
        <td>/api/NationalParks/{id}</td>
        <td>id (int)</td>
        <td>A JSON object containing key-value pairs for: <br> - nationalparkId(int) <br> - name(string), <br> - location(string), <br> - description(string) <br> *Note that the "nationalparkId" must match the "id" provided as a URL parameter.</td>
        <td>No content</td>
        <td>204: No Content</td>
      </tr>
</table>

Example Request Body *required:

```json
{
  "nationalParkId": 5,
  "name": "Crater Lake National Park",
  "location": "Oregon",
  "description": "Just beautiful."
}
```

### DELETE /api/NationalParks/{id}
<table>
    <thead>
      <tr>
        <th>HTTP Verb</th>
        <th>URL</th>
        <th>URL Parameter *required</th>
        <th>Expected Behavior</th>
        <th>Response Status</th>
      </tr>
    </thead>
      <tr>
        <td>DELETE</td>
        <td>/api/NationalParks/{id}</td>
        <td>id (int)</td>
        <td>Deletes a NationalPark from the database.</td>
        <td>204: No Content</td>
      </tr>
</table>