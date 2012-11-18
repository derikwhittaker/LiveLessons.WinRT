﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metro.LL.Common.Models;

namespace LL.SearchContracts.DataModel
{
    public class Repository
    {
        private static IList<SimpleItem> _all = new List<SimpleItem>();
        public IList<SimpleItem> All()
        {
            if (_all.Any()) { return _all; }

            _all.Add(new SimpleItem { Id = 1, Name = "Bugatti Veyron", ImagePath = "../Images/Bugatti_Veyron.png", ShortDescription = "The Bugatti Veyron 16.4 was the most powerful...", FullDescription = "Not just a super car that carries on the name of racing driver Pierre Veyron, who, while racing for the original Bugatti car manufacturer, won the 24 hours of Le Mans in 1939. The Bugatti Veyron 16.4 was the most powerful and the faster car in the world when it first came out in 2005, it can easily pass as a super hero`s car like Batman. It has the fastest acceleration speed, reaching 60 mph in 2.5 seconds. Endowed with a 8.0L W16-Cylinder, four turbochargers, and a dual-clutch DSG computer-controlled manual transmission, the Veyron can reach a top speed of 253 mph. Counting a sum of 10 radiators, for the engine cooling system, for transmission oil, a heat exchanger for the air to liquid intercoolers, for engine oil etc., the car has a power to weight ratio of 529 bhp/tonne" });
            _all.Add(new SimpleItem { Id = 2, Name = "Jaguar XJ Ultimate", ImagePath = "../Images/Jaguar_xj.png", ShortDescription = "Jaguars have always been about refined performance...", FullDescription = "Jaguars have always been about refined performance, and that's certainly the case with the XJ Ultimate. You have two engine choices - either a 5.0-liter V8 gasoline-powered unit or a 3.0-litre V6 turbo diesel. A third option, a supercharged 3.0-liter gas unit, will be made available soon. The largest engine gives incredible levels of performance, with over 500 horse power on tap. Despite this, however, fuel consumption of close to 40 mpg is possible in mixed driving, making any type of journey a pleasure rather than a chore." });
            _all.Add(new SimpleItem { Id = 3, Name = "Aston Martin Zagato", ImagePath = "../Images/AstonMartin_V12Zagato.png", ShortDescription = "The new V12 Zagato is a celebration of Aston Martin's heritage and the future....", FullDescription = "Aston Martin has just celebrated its 50th Anniversary, and is proud to introduce the 2013 Aston Martin V12 Zagato. Inspired by the years that were spent by the company, they are back to entice car enthusiasts from all over the world. The new V12 Zagato is a celebration of Aston Martin's heritage and the future. This was delivered by the CEO of the company who is proud to announce that this new Aston Martin will be in production later this year." });
            _all.Add(new SimpleItem { Id = 4, Name = "Audi R8", ImagePath = "../Images/Audi_R8.png", ShortDescription = "When it comes to the latest car innovations, Audi is a pioneer in its own right...", FullDescription = "With its 4.2 liter V8, this Toxique kit engine designed by TC Concepts boasts of its performance engineered to meet the highest standards in modern car manufacturing. Using software optimization, a serial power of approximately 440 horsepower is created to exceed any driver’s expectations when it comes to performance." });
            _all.Add(new SimpleItem { Id = 5, Name = "Corvette Z06", ImagePath = "../Images/Corvette_Z06.png", ShortDescription = "This special edition can attain a top speed of 198 mph...", FullDescription = "The Corvette Centennial Edition Z06 is fitted with a 7-litre V8 engine producing 505 horsepower. The car does the 0-60 mph sprint in 3.8 seconds and runs the quarter mile in about 11.9 seconds, a tad slower than some of its contemporaries like the Ferrari 458 Italia, Nissan GT-R and Porsche 911 GT3 RS, though the Z06 is much cheaper than these cars." });
            _all.Add(new SimpleItem { Id = 6, Name = "Lamborghini Aventador", ImagePath = "../Images/Lamborghini_Aventador.png", ShortDescription = "Any Lamborghini is sure to be a superbly engineered and designed sports car...", FullDescription = "The Rabbioso boasts a mighty 6.5-liter, naturally aspirated V12 engine, with one of the most exciting and spine-tingling exhaust notes around. The enormous power on tap - no less than 777 horsepower - requires no fewer than four driveshafts to be fitted." });
            _all.Add(new SimpleItem { Id = 7, Name = "Ferrari F12 Berlinetta", ImagePath = "../Images/Ferrari_F12berlinetta.png", ShortDescription = "The most stunning feature of the car is its speed...", FullDescription = "The F12berlinetta packs 730 Horsepower with 509 lb-ft of torque under the hood, in a 6.3 liter V-12 engine that can accelerate from 0-62 miles per hour in 3.1 seconds. It's a new speed record in its class, delivering maximum revs of up to 8,700 rpm. In this Ferrari, you can cruise up to a top speed of 211 miles per hour in style. Like other Ferraris, this car delivers the best precision handling you would expect from the creators of top formula one vehicle, and this car definitely offers more of a racing feel." });
            _all.Add(new SimpleItem { Id = 8, Name = "McLaren MP4", ImagePath = "../Images/McLaren_MP4.png", ShortDescription = "The newly developed McLaren 3.8 liter Biturbo V8 engine wasn't missing horsepower...", FullDescription = "The newly developed McLaren 3.8 liter Biturbo V8 engine wasn't missing horsepower, as the original factory model boasts 597 BHP. Wheelsandmore were simply following the exclusive sales order to create something that was diabolical (and they certainly delivered when they decided to ramp up the BHP and torque of this supercar!)." });
            _all.Add(new SimpleItem { Id = 9, Name = "Lamborghini Aventador", ImagePath = "../Images/Lamborghini_Aventador.png", ShortDescription = "Any Lamborghini is sure to be a superbly engineered and designed sports car...", FullDescription = "The Rabbioso boasts a mighty 6.5-liter, naturally aspirated V12 engine, with one of the most exciting and spine-tingling exhaust notes around. The enormous power on tap - no less than 777 horsepower - requires no fewer than four driveshafts to be fitted." });
            _all.Add(new SimpleItem { Id = 10, Name = "Porsche Panamera", ImagePath = "../Images/Porsche_Panamera.png", ShortDescription = "Porsche performance speaks for itself and can now be even sportier...", FullDescription = "The Panamera, with its 4.8 liter, V8 twin, turbo engine guarantees Porsche performance. It has a seven-speed PDK, which is standard in all models. In addition it has Porsche Traction Management (PTM), Automatic Brake Differential (ABD), Anti-Slip Regulation (ASR), and Direct Fuel Injection (DFI)." });
            _all.Add(new SimpleItem { Id = 11, Name = "Maybach 57", ImagePath = "../Images/Maybach_57.png", ShortDescription = "Specifically designed to commemorate the wedding of Prince William and Kate Middleton...", FullDescription = "This model is specifically designed to commemorate the wedding of Prince William and Kate Middleton, now known as the Duke and Duchess of Cambridge. Yes, you may shop to your heart’s content when it comes to purchasing other memorabilia of the bug day, but having the 2011 Project Kahn Wedding Commemorative Maybach 57 in your collection will surely set you apart from the other well wishers." });
            _all.Add(new SimpleItem { Id = 12, Name = "Lotus Exige S", ImagePath = "../Images/Lotus_ExigeS.png", ShortDescription = "The vehicle goes 0 to 62 mph in just under 4 seconds ...", FullDescription = "The exterior is identifiable with the well known Lotus lines and curves. The interior comes standard with the basic necessities and little more. There is an option to upgrade the inside to a more comfortable and stylish interior for those that are concerned more with how the ride feels than just the basics that represent true speed." });
            
            return _all;
        }

        public async Task<IList<SimpleItem>> SearchAsync(string searchString)
        {
            var simpleItems = All()
                .Where(x => x.Name.ToLower().Contains(searchString.ToLower()))
                .ToList();

            return simpleItems;
        }

        public async Task<IList<string>> SearchSuggestionsAsync(string searchString)
        {
            var keywords = All()
                .Where(x => x.Name.ToLower().StartsWith(searchString, StringComparison.OrdinalIgnoreCase))
                .Select(x => x.Name.Substring(0, x.Name.IndexOf(" ", StringComparison.OrdinalIgnoreCase)))
                .Distinct()
                .ToList();
            
            return keywords;
        }
    }
}
