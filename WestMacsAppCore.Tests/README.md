# Test Documentation

## Framework
[NUnit](https://nunit.org/)
<br>
## Policy

Aims to test the reliability, completeness and sorting of lists created via deserialization of JSON data.
<br>
<br>
## Test Cases

**Pre-conditions** Each set is executed with a new set of data from file.
<br>
<br>
### Place

| num | name                                                                                  | inputs                           | expected                             | result |
|-----|---------------------------------------------------------------------------------------|----------------------------------|--------------------------------------|--------|
| 1   | Get_All_Places_Return_All_Places                                                      |                                  | List of 25 Place                     | pass   |
| 2   | Get_Any_Place_Facility_Observations_ Return_Any_Place_Facility_Observations           | "Wallaby Gap Campsite", "Toilet" | List of 2 Observation                | pass   |
| 3   | Get_Any_Place_Observations_ Return_Any_Place_Observations                             | "Wallaby Gap Campsite"           | Author at [0] = rrr@burntsugar.rocks | pass   |
| 4   | Get_Any_Place_Observations_ Return_Null                                               | "Brinkley Bluff  CampSite"       | null                                 | pass   |
| 5   | Get_Any_Place_Instance_With_Water_Source_ Return_Any_Place_With_Water_Source          |                                  | List of 15 Place                     | pass   |
| 6   | Get_Any_Place_Instance_By_Name_ Return_Any_Place_Instance                             | "Wallaby Gap Campsite"           | matching Place instance              | pass   |
| 7   | Get_Any_Place_By_Name_ Return_Null                                                    | "does not exist"                 | null                                 | pass   |
| 8   | Get_Any_Place_Instance_Types_By_Distance_East_ Return_Any_Place_Instances_By_Distance | 106                              | List of 2 Place                      | pass   |
| 9   | Get_Any_Places_With_Water_Tank                                                        |                                  | List of 15 Place                     | pass   |
| 10  | Get_Any_Place_Instances_With_Shelter_ Return_Place_Instances_With_Shelter             |                                  | List of 9 Place                      | pass   |
| 11  | Get_Any_Place_Instances_With_Toilet_ Return_Place_Instances_With_Toilet               |                                  | List of 15 Place                     | pass   |
| 12  | Get_Any_Places_With_Parking_Facilities                                                |                                  | List of 1 Place                      | pass   |

<br>
<br>

### CampSite
<br>

| num | name                                                                                          | inputs                 | expected                | result |
|-----|-----------------------------------------------------------------------------------------------|------------------------|-------------------------|--------|
| 1   | Get_All_CampSite_Instances_With_Water_Source_ Return_All_Campsite_Instances_With_Water_Source |                        | List of 14 CampSite     | pass   |
| 2   | Get_Campsite_Instance_By_Name_ Return_CampSite_Instance                                       | "Wallaby Gap Campsite" | Matching Place instance | pass   |
| 3   | Get_CampSite_By_Name_Return_Null                                                              | "does not exist"       | null                    | pass   |
| 4   | Get_All_CampSite_Instances_With_Water_Tank_ Return_All_Campsite_Instances_With_Water_Tank     |                        | List of 14 CampSite     | pass   |
| 5   | Get_CampSite_Instance_Types_By_Distance_East_ Return_CampSite_Instances_By_Distance           | 106                    | List of 2 CampSite      | pass   |
| 6   | Get_CampSite_Instances_With_Shelter_ Return_CampSite_Instances_With_Shelter                   |                        | List of 2 CampSite      | pass   |
| 7   | Get_CampSite_Instances_With_Toilet_ Return_CampSite_Instances_With_Toilet                     |                        | List of 14 CampSite     | pass   |
| 8   | Get_CampSite_Instances_With_USB_Charging_ Return_CampSite_Instances_With_USB_Charging         |                        | List of 6 CampSite      | pass   |
| 9   | Get_CampSite_Instances_With_Tap_Water_ Return_CampSite_Instances_With_Tap_Water               |                        | List of 1 CampSite      | pass   |
| 10  | Get_CampSite_Instances_With_Shower_ Return_CampSite_Instances_With_Shower                     |                        | List of 2 CampSite      | pass   |

<br>
<br>

### TrailSite
<br>

| num | name                                                                                            | inputs                      | expected                     | result |
|-----|-------------------------------------------------------------------------------------------------|-----------------------------|------------------------------|--------|
| 1   | Get_All_TrailSite_Instances_With_Water_Source_ Return_All_TrailSite_Instances_With_Water_Source |                             | List of 1 TrailSite          | pass   |
| 2   | Get_TrailSite_Instance_By_Name_ Return_TrailSite_Instance_By_Name                               | "Serpentine Gorge Car Park" | Matching TrailSite instance  | pass   |
| 3   | Get_TrailSite_By_Name_ Return_Null                                                              | "does not exist"            | null                         | pass   |
| 4   | Get_TrailSite_Instances_By_Distance_East_ Return_TrailSite_Instances_By_Distance_East           | 140                         | List of 1 TrailSite instance | pass   |
| 5   | Get_All_TrailSite_Instances_With_Water_Tank_ Return_All_TrailSite_Instances_With_Water_Tank     |                             | List of 1 TrailSite          | pass   |
| 7   |                                                                                                 |                             |                              |        |
| 8   |                                                                                                 |                             |                              |        |
| 9   |                                                                                                 |                             |                              |        |
| 10  |                                                                                                 |                             |                              |        |

<br>

<hr>

*rrr@<span></span>burntsugar.rocks*
