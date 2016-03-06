using System.Collections.Generic;

// Text and data from http://www.theplanetstoday.com/the_planets.html
namespace MoM.Tutorial.Models.Seed
{
    public class HelloPlanetInit
    {
        public static readonly IEnumerable<HelloPlanet> HelloPlanetListV1 =
            new List<HelloPlanet>
            {
                new HelloPlanet {
                    Name = "Mercury",
                    Description =
                    @"Mercury is the closest planet to the Sun. It orbits in a highly elliptical orbit ranging from 46 million km (29 million miles) from the Sun out to 70 million km (43.5 million miles).
                    It takes about 88 earth days to orbit the sun but rotates on it's axis once every 59 earth days. Because of the slow rotation, a single day on Mercury (mid day to mid day) takes 176 Earth days. It's axial tilt is remarkably small at 3/100ths of a degree. Much smaller than any other planet.
                    Mercury is quite small with a diameter of 4,878km, (2/5ths that of earth) and only 5% of earth’s mass. It's gravity on the surface is 1/3rd of earth’s.
                    Mercury has almost no atmosphere and is blasted by the Sun during the day and exposed to cold space during the night. This means that it undergoes some of the widest temperature swings of any body in the Solar System with temperatures reaching +430 C and dipping down to -180 C.
                    It has a highly cratered rocky surface and is known to have an iron core. However it's magnetic field is much weaker than the earth’s (1% as strong). Initially RADAR waves reflected from the surface of Mercury indicated that water ice might be present at the poles. It has recently been confirmed by the Messenger Spacecraft that ice water does indeed exist in deep craters at the poles the interiors of which are permanently shrouded in shadow.
                    Because mercury is so close to the sun, it is only ever seen with the naked eye just before sunrise and just after sunset. At all other times it is masked by the brightness of the sun."
                },
                new HelloPlanet
                {
                    Name ="Venus",
                    Description =
                    @"Venus is the second closest planet to the Sun and orbits in an almost circular orbit at 108 million km. As it orbits, Venus comes closer to earth than any other planet in the solar system and can come to within about 40 million km.
                    Venus takes about 225 earth days to orbit the Sun and rotates at the incredibly slow rate of once every 243 days - and in a clockwise direction (as seen from looking down on the Suns north pole). Only Uranus (which almost spins on it's side) also has a clockwise spin. A day on Venus (sunrise to sunrise) lasts 117 earth days.
                    Venus has a gentle axial tilt of 3 degrees.
                    Venus, with a diameter of 12100 km, it is very nearly the same size as earth (1000km smaller), and has 80% of earth’s mass. It's gravity on the surface is 90% that of earth’s.
                    Venus has a very dense atmosphere with pressures at the surface over 90 times that of earth’s. The atmosphere is comprised of carbon dioxide with thick clouds of sulphur dioxide. This atmosphere has the strongest greenhouse effect known in the solar system which keeps the planet at a reasonably constant temperature of 460 degrees C. This makes Venus the hottest planet in the solar system, far hotter even then mercury which is twice as close to the sun.
                    The surface of Venus, although hidden from view by thick clouds, has been mapped using radar and it is known that is is covered by large flat volcanic plains with two higher areas of land (continents) with mountains and valleys. The surface also shows impact craters and volcano like structures. Venus has a very weak magnetic field."
                },
                new HelloPlanet
                {
                    Name = "Earth",
                    Description =
                    @"The third closest planet to the sun is earth and is the largest and densest of the inner planets. Earth orbits in a reasonably circular at 150 million km and is the first of the planets to have a moon. Earth is of course the only place that we know of that has life.
                    Earth takes 365.25 earth days to orbit the Sun and rotates once every 23 hours, 56 minutes and 4 seconds. Because it rotates around the sun the length of a day on earth (sunrise to sunrise) takes 24 hours.
                    The earth has an axial tilt of 23.4 degrees and a diameter of 12742km.
                    The earth is thought to be 4.54 billion years old and has been accompanied by the moon for most of that time. It is believed that the moon was formed when a large Mars sized body impacted the earth causing enough material to be ejected which eventually coalesced into the moon. The moon has had the effect of stabilising Earth’s axial tilt and is the source of the earth’s ocean tides.
                    The moon is 3,474km in diameter (27% that of earth) and orbits at a distance of between about 362,000 to 405,000 km. It has also been affected by the gravitational pull of the earth which has over time caused the moons rotation to be slowed until it matches the time it takes to orbit the earth. This is why the same side of the moon always faces the earth.
                    Earth is protected from solar radiation by a strong magnetic field generated by movement of it's core which is mainly comprised of molten iron."
                },
                new HelloPlanet
                {
                    Name ="Mars",
                    Description =
                    @"Mars is the fourth closest planet to the Sun and orbits in an fairly eccentric orbit at around 230 (+-20) million km.
                    Mars takes about 686 earth days to orbit the Sun. It has a tilt (25.1 degrees) and rotational period (24 hour 37 minutes) which are both similar to the earth with a day (sunrise to sunrise) lasting 24 hours, 39 mins. Because of the tilt it also has seasons in the same way as the earth does.
                    Mars is about half the size of the earth with a diameter of 6,792km. However it's mass is only a tenth of earth’s with gravity on the surface being around 37% that of earth’s.
                    Because Mars no longer has a magnetic field to protect it, Mars has lost it's original atmosphere due to the effects of the solar wind interacting with the atmosphere causing atoms to be lost into space. Spacecraft have detected streams of atoms trailing off into space behind Mars. As a result the atmospheric pressure on Mars is 1% that on earth. It is comprised of mostly (95%) carbon dioxide. Mars is very cold. Not only is it about 1.5 times further from the Sun than earth, it also has a thin atmosphere which cannot store much heat. Because of this the temperature ranges from about -87 degrees C in winter up to a maximum of -5 degrees C in summer.
                    Mars is very dusty and prone to huge dust storms which can envelop the entire planet. These are more likely to occur when the planet is closest to the Sun."
                }
            };
    }
}
