using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WebApplicationGIS.Domain.Models;

namespace CqrsSami.Core.Manage
{
    public class BaseManage
    {

        // Function calculates distance
        // between two points
        public static float CalculateDistance(Vector2 p1, Vector2 p2)
        {
            return Vector2.Distance(p2, p1);
        }

    }
}
