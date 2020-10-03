/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:39:56 
 * @Last Modified by: rrr@burntsugar.rocks
 * @Last Modified time: 2020-10-03 11:23:44
 */
using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace WestMacsAppCore.Tests
{
    public class PlaceTest
    {
        private static int NUM_OF_PLACES = 25;
        private static int NUM_OF_PLACES_WITH_WATER_SOURCE = 15;
        private static int NUM_OF_PLACES_WITH_WATER_TANK = 15;
        private static int NUM_OF_PLACES_WITH_SHELTER = 9;
        private static int NUM_OF_PLACES_WITH_TOILET = 15;
        private static int NUM_OF_PLACES_WITH_PARKING = 1;
        private static int DISTANCE_1 = 106;
        private static string[] PLACE_NAMES_NEAR_DISTANCE_1 = { "Ghost Gum Flat Campsite", "Rocky Gully Campsite" };
        private static string OBSERVATION_AUTHOR_1 = "rrr@burntsugar.rocks";
        private static int NUM_OF_OBSERVATIONS_1 = 2;

        private Controller controller;
        [SetUp]
        public void Setup()
        {
            Model model = DataUtils.ReadDataFile();
            controller = new Controller(model);
        }

        [Test]
        public void Get_All_Places_Return_All_Places()
        {
            List<Place> allPlaces = controller.GetAllPlaces();
            Assert.IsNotNull(allPlaces);
            Assert.IsNotEmpty(allPlaces);
            Assert.AreEqual(NUM_OF_PLACES, allPlaces.Count);
        }

        [Test]
        public void Get_Any_Place_Facility_Observations_Return_Any_Place_Facility_Observations()
        {
            List<Observation> returned = controller.GetPlaceFacilityObservations("Wallaby Gap Campsite", "Toilet");
            Assert.IsNotNull(returned);
            Assert.IsNotEmpty(returned);
            string expectedAuthor = OBSERVATION_AUTHOR_1;
            string actualAuthor = returned[0].AuthorName;
            Assert.AreEqual(expectedAuthor, actualAuthor);
            int expectedCount = NUM_OF_OBSERVATIONS_1;
            int actualCount = returned.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Get_Any_Place_Observations_Return_Any_Place_Observations()
        {
            List<Observation> returned = controller.GetPlaceObservations("Wallaby Gap Campsite");
            Assert.IsNotNull(returned);
            Assert.IsNotEmpty(returned);
            string expected = OBSERVATION_AUTHOR_1;
            string actual = returned[0].AuthorName;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Get_Any_Place_Observations_Return_Null()
        {
            List<Observation> returned = controller.GetPlaceObservations("Brinkley Bluff CampSite");
            Assert.IsNull(returned);
        }

        [Test]
        public void Get_Any_Place_Instance_With_Water_Source_Return_Any_Place_With_Water_Source()
        {
            List<Place> returned = controller.GetPlacesWithWaterSource();
            Assert.IsNotNull(returned);
            Assert.IsNotEmpty(returned);
            Assert.AreEqual(NUM_OF_PLACES_WITH_WATER_SOURCE, returned.Count);
        }

        [Test]
        public void Get_Any_Place_Instance_By_Name_Return_Any_Place_Instance()
        {
            string expectedName = "Wallaby Gap Campsite";
            Place p = controller.GetPlaceByName(expectedName);
            Assert.IsNotNull(p);
            Assert.AreEqual(expectedName, p.Name);
        }

        [Test]
        public void Get_Any_Place_By_Name_Return_Null()
        {
            Place p = controller.GetPlaceByName("does not exist");
            Assert.IsNull(p);
        }

        [Test]
        public void Get_Any_Place_Instance_Types_By_Distance_East_Return_Any_Place_Instances_By_Distance()
        {
            List<Place> actual = controller.GetPlacesAtDistanceEast(DISTANCE_1);
            Assert.IsNotNull(actual);
            Assert.IsNotEmpty(actual);
            Assert.AreEqual(PLACE_NAMES_NEAR_DISTANCE_1.Length, actual.Count);
            Assert.AreEqual(PLACE_NAMES_NEAR_DISTANCE_1[0], actual[0].Name);
            Assert.AreEqual(PLACE_NAMES_NEAR_DISTANCE_1[1], actual[1].Name);
        }

        [Test]
        public void Get_Any_Places_With_Water_Tank()
        {
            int expected = NUM_OF_PLACES_WITH_WATER_TANK;
            List<Place> places = controller.GetPlacesWithTankWater();
            Assert.IsNotNull(places);
            Assert.IsNotEmpty(places);
            Assert.AreEqual(expected, places.Count);
        }

        [Test]
        public void Get_Any_Place_Instances_With_Shelter_Return_Place_Instances_With_Shelter()
        {
            var returned = controller.GetPlacesWithShelter();
            Assert.IsNotNull(returned);
            Assert.IsNotEmpty(returned);
            Assert.AreEqual(NUM_OF_PLACES_WITH_SHELTER, returned.Count);
        }

        [Test]
        public void Get_Any_Place_Instances_With_Toilet_Return_Place_Instances_With_Toilet()
        {
            var returned = controller.GetPlacesWithToilet();
            Assert.IsNotNull(returned);
            Assert.IsNotEmpty(returned);
            Assert.AreEqual(NUM_OF_PLACES_WITH_TOILET, returned.Count);
        }

        [Test]
        public void Get_Any_Places_With_Parking_Facilities()
        {
            int expected = NUM_OF_PLACES_WITH_PARKING;
            List<Place> places = controller.GetPlacesWithParking();
            Assert.IsNotNull(places);
            Assert.IsNotEmpty(places);
            Assert.AreEqual(expected, places.Count);
        }

    }
}