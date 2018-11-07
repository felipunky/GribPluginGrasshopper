using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;
using GH_IO;

namespace ReadGribFiles
{

    public class ReadGribFiles : GH_Component
    {

        public ReadGribFiles() : base("Read Grib Files", "RGF", "This component converts Grib files into Grasshopper data", "GIS", "GribFiles")
        {



        }

        public override Guid ComponentGuid
        {

            get { return new Guid("87C9CF98-C72F-4A14-8296-F5EA90F132D4"); }

        }

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {

            pManager.AddTextParameter("String", "S", "String", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {

            pManager.AddTextParameter("StringOut", "SO", "String Out", GH_ParamAccess.item);

        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {

            GdalConfiguration.ConfigureOgr();

            GdalConfiguration.ConfigureGdal();

            string input = "";

            DA.GetData(0, ref input);

            string file = @"C:\Users\Paula\Desktop\Felipe\New\multi_1.20181031.grb2";

            OSGeo.GDAL.Dataset ds = OSGeo.GDAL.Gdal.Open( file, OSGeo.GDAL.Access.GA_ReadOnly );

            //string output = ds.GetProjectionRef();

            string output = file;

            DA.SetData(0, output);

        }

    }

}