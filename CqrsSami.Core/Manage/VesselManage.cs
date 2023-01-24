using CqrsSami.Contracts.Data.Repositories;
using CqrsSami.Providers.Handlers.Queries;
using GeometRi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WebApplicationGIS.Domain.Models;

namespace CqrsSami.Core.Manage
{
    public class VesselManage: BaseManage
    {
        public VesselManage() { }

        public static void ManageSpeedDistanceVessels(ref List<VesselDTO> vessels)
        {
            
            foreach (var vessel in vessels)
            {
                VesselPositions prev = new VesselPositions();
                bool first = true;

                foreach (var next in vessel.positions)
                {
                    if (!first)
                {
                        float distanceInKm = CalculateDistance(new Vector2(prev.x, prev.y), new Vector2(next.x, next.y));
                        next.distance_traveled = prev.distance_traveled + distanceInKm;
                        
                        float timeInHours = (float)next.timestamp.Subtract(prev.timestamp).TotalHours;
                        next.average_speed = distanceInKm / timeInHours;

                }

                (prev, first) = (next, false);
                }
            }

        }

        internal static string ManageIntersectionByVessel(List<VesselDTO> vessels, string vessel_name, DateTime date)
        {
            string intersection_message = string.Empty;
            Line3d selected_SegLine = getSelectedSegLine(vessels, vessel_name, date);
            

            var lstVesselForCheckIntersection = vessels.Where(x => x.name != vessel_name).ToList();

            foreach (var item in lstVesselForCheckIntersection)
            {
                VesselPositions prev = new VesselPositions();
                bool first = true;

                foreach (var next in item.positions)
                {
                    if (!first)
                    {
                        if (prev.timestamp <= date && date <= next.timestamp)
                        {
                            var segLine = new Line3d(new Point3d(prev.x, prev.y, 0), new Point3d(next.x, next.y, 0));
                            
                            if (selected_SegLine.IntersectionWith(segLine) != null)
                            {
                                intersection_message += String.Format("{0}; ", item.name);
                            }
                        }

                    }

                    (prev, first) = (next, false);
                }
            }

            return intersection_message;
        }

        private static Line3d getSelectedSegLine(List<VesselDTO> vessels, string vessel_name, DateTime date)
        {
            var selectedVessel = vessels.FirstOrDefault(x => x.name == vessel_name);

            VesselPositions prev = new VesselPositions();
            bool first = true;
            var selected_SegLine = new Line3d();

            foreach (var next in selectedVessel.positions)
            {
                if (!first)
                {
                    if (prev.timestamp <= date && date <= next.timestamp)
                    {
                        selected_SegLine = new Line3d(new Point3d(prev.x, prev.y, 0), new Point3d(next.x, next.y, 0));
                    }

                }

                (prev, first) = (next, false);
            }

            return selected_SegLine;
        }
    }
}
