namespace WhatTheMud3.Models;

public partial class AppModel : ObservableObject
{
	#region AppParameters

	[ObservableProperty] private string wellName;

	#endregion
	
	#region Collection Inputs

	[ObservableProperty] private ObservableCollection<Segment> drillString = new()
	{
		new Segment
		{
			Id = Guid.NewGuid(),
			OuterDiameter="177.8",
			InnerDiameter = "97.18",
			BottomDepth = "2000",
			TopDepth = "0",
			WeightInAir = "22.47",
			FluidType = "Oil Based Mud"
		}
	};

	[ObservableProperty] private ObservableCollection<Segment> casings = new()
	{
		new Segment
		{
			Id = Guid.NewGuid(),
			OuterDiameter = "177.8",
			InnerDiameter = "159.41",
			WeightInAir = "35.38",
			TopDepth = "0",
			BottomDepth = "1578",
			MudDensity = "1605",
			FluidType = "Water Based Mud",
		}
	};

	[ObservableProperty] private ObservableCollection<Segment> openHoles = new()
	{
		new Segment
		{
			Id = Guid.NewGuid(),
			OuterDiameter = "155.6",
			TopDepth = "1578",
			BottomDepth = "5834",
			MudDensity = "1605",
			FluidType = "Water Based Mud",
		}
	};
	
	[ObservableProperty] private ObservableCollection<DownholeTool> downholetools = new()
	{
    		new DownholeTool
    		{
    			id = Guid.NewGuid(),
    			Name = "Stage Tool",
    			ActivationType = "Differential",
    			ActivationPressure = "20705",
    			MeasuredDepth = "1966.59",
    		},
    		new DownholeTool
    		{
    			id = Guid.NewGuid(),
    			Name = "Voyager Packer",
    			ActivationType = "Differential",
    			ActivationPressure = "15693",
    			MeasuredDepth = "1982.13",
    		},
    		new DownholeTool
    		{
    			id = Guid.NewGuid(),
    			Name = "URFC",
    			ActivationType = "Absolute",
    			ActivationPressure = "48265",
    			MeasuredDepth = "1937.8",
    		},
    	};

	[ObservableProperty] private ObservableCollection<StringRestriction> stringRestictions = new()
	{
		new StringRestriction
		{
			id = Guid.NewGuid(),
			Name = "Josh",
			InnerDiameter = "93",
			Depth = "1111",
			DischargeCoefficient = "0.93"
		},
		new StringRestriction
		{
			id = Guid.NewGuid(),
			Name = "Sallows",
			InnerDiameter = "93",
			Depth = "2222",
			DischargeCoefficient = "0.93"
		}
	};

	[ObservableProperty] private ObservableCollection<FluidStage> pumpSchedule = new()
	{
		new FluidStage
		{
			id = Guid.NewGuid(),
			FluidVolume = "43.3",
			FluidType = "Base Oil",
			Density = "2000"
		},
		new FluidStage
		{
			id = Guid.NewGuid(),
			FluidVolume = "10",
			FluidType = "Water Based Mud",
			Density = "2000"
		},
	};

	[ObservableProperty] private ObservableCollection<Survey> surveys = new()
	{
		new Survey
		{
			id = Guid.NewGuid(),
			Inc = "0",
			Azi = "0",
			Md = "0",
			Tvd = "0",
		},
		new Survey
		{
			id = Guid.NewGuid(),
			Inc = "0",
			Azi = "0",
			Md = "6000",
			Tvd = "6000",
		},
	};
	#endregion

	#region App Collections and Parameters

	[ObservableProperty] 
	private ObservableCollection<AppSegment> appAnnulusSegments = new ObservableCollection<AppSegment>();

	[ObservableProperty]
	private ObservableCollection<AppSegment> appDrillStringSegments = new ObservableCollection<AppSegment>();
	
	[ObservableProperty]
	private double surfaceLineVolume = 1.5;
	[ObservableProperty]
	private double pumpOutput = 0.01012;

	public int DrillStringStartIndex = -1;
	public int DrillStringEndIndex = -1;
	public int AnnulusStartIndex = -1;
	public int AnnulusEndIndex = -1;
	public int SurfaceLineStartIndex = -1;
	public int SurfaceLineEndIndex = -1;
	public int StageToolIndexAnnulus = -1;
	public int StageToolIndexDrillString = -1;
	public bool StageToolIsOpen = false;
	public bool PumpingWithCementers = false;
	public double StageToolAverageHP = -1.0;
	public DownholeTool StageTool = null;

	[ObservableProperty] private int fluidsOut = 0;
	[ObservableProperty] private ObservableCollection<AppFluid> appPumpSchedule = new();
	private ObservableCollection<double> tvd_list_ds = new ObservableCollection<double>();
	public ObservableCollection<Color> drillStringColors = new ObservableCollection<Color>();
	private ObservableCollection<double> tvd_list_ann = new ObservableCollection<double>();
	public ObservableCollection<Color> annulusColors = new ObservableCollection<Color>();

	[ObservableProperty]
	private double drillStringHP;
	[ObservableProperty]
	private double annulusHP;
	[ObservableProperty]
	private double deltaBHP;
	
	#endregion

	#region Add Remove and Delete Commands

		[RelayCommand]
    	public void AddDrillString()
    	{
    		DrillString.Add( new Segment
    		{
    			Id = Guid.NewGuid(),
    			OuterDiameter="222.2",
    			InnerDiameter = "97.18",
    			BottomDepth = "2000",
    			TopDepth = "0",
    			WeightInAir = "22.47",
    			FluidType = "Oil Based Mud"
    		});
    	}

	#endregion

	#region methods

	        public void ComputeAppSegmentVolumes()
        {
            if (AppAnnulusSegments.Count is not 0) { AppAnnulusSegments.Clear(); };
            if (Surveys.First().md_d > 0)
            {
                Surveys.Insert(0, new Survey
                {
                    id = Guid.NewGuid(),
                    Md = "0",
                    Inc = "00",
                    Azi = "0",
                    Tvd = "0"
                });
            }

            CreateAppAnnulus(Casings);
            CreateAppAnnulus(OpenHoles);
            UpdateAppAnnulusForDrillString();
            CreateAppDrillString();

            if (Surveys.Last().md_d < AppDrillStringSegments.Last().BottomDepth)
            {
                Surveys.Last().Md = AppDrillStringSegments.Last().BottomDepth.ToString();
            }

            if (Surveys.Last().md_d < AppAnnulusSegments.Last().BottomDepth)
            {
                Surveys.Last().Md = AppAnnulusSegments.Last().BottomDepth.ToString();
            }

            computeToolVolumes();
            CreateAppPumpSchedule();
            computeHP();
            getToolIndexes();
            getToolTVDs();
            computeToolHPDS();
            computerToolHPANN();

        }

        private void CreateAppAnnulus(ObservableCollection<Segment> csgSections)
        {

            if (csgSections.Count == 1)
            {
                var csg_1 = csgSections.First();
                
                AppAnnulusSegments.Add(new AppSegment
                {
                    TopDepth = csg_1.TopDepth_D,
                    BottomDepth = csg_1.BottomDepth_D,
                    Volume = csg_1.Volume_D,
                    MudDensity = csg_1.MudDensity_D,
                    FluidType = csg_1.FluidType,
                    InnerDiameter = csg_1.InnerDiameter_D,
                    OuterDiameter = csg_1.OuterDiameter_D,
                });
                return;
            }

            for (int i = 0; i < csgSections.Count; i++)
            {
                var csg_1 = csgSections[i];
                var csg_2 = i < csgSections.Count - 1 ? csgSections[i + 1] : csg_1;

                if (csg_2.TopDepth_D <= csg_1.TopDepth_D)
                {
                    AppAnnulusSegments.Add(new AppSegment
                    {
                        TopDepth = csg_2.TopDepth_D,
                        BottomDepth = csg_2.BottomDepth_D,
                        Volume = csg_2.Volume_D,
                        MudDensity = csg_2.MudDensity_D,
                        FluidType = csg_2.FluidType,
                        InnerDiameter = csg_2.InnerDiameter_D,
                        OuterDiameter = csg_2.OuterDiameter_D

                    });
                }
                else
                {
                    var bottomDepth = csg_2.TopDepth_D < csg_1.BottomDepth_D ?
                        csg_2.TopDepth_D : csg_1.BottomDepth_D;
                    AppAnnulusSegments.Add(new AppSegment
                    {
                        TopDepth = csg_1.TopDepth_D,
                        BottomDepth = bottomDepth,
                        Volume = csg_1.Volume_D,
                        MudDensity = csg_1.MudDensity_D,
                        FluidType = csg_1.FluidType,
                        InnerDiameter = csg_1.InnerDiameter_D,
                        OuterDiameter = csg_1.OuterDiameter_D
                    });
                }

                if (csg_2 == csgSections.Last())
                {
                    var bottomDepth = csg_2.TopDepth_D < csg_1.BottomDepth_D ?
                        csg_2.TopDepth_D : csg_1.BottomDepth_D;
                    var newCasing = new AppSegment
                    {
                        TopDepth = bottomDepth,
                        BottomDepth = csg_2.BottomDepth_D,
                        Volume = csg_2.Volume_D,
                        MudDensity = csg_2.MudDensity_D,
                        FluidType = csg_2.FluidType,
                        InnerDiameter = csg_2.InnerDiameter_D,
                        OuterDiameter = csg_2.OuterDiameter_D
                    };

                    if (newCasing != AppAnnulusSegments.Last())
                    {
                        AppAnnulusSegments.Add(newCasing);
                    }

                    break;
                }
            };
        }

        private void CreateAppAnnulus(ObservableCollection<Segment> sections, bool isOpenHole)
        {

            if (sections.Count == 1)
            {
                var section = sections.First();
                AppAnnulusSegments.Add(new AppSegment
                {
                    TopDepth = section.TopDepth_D,
                    BottomDepth = section.BottomDepth_D,
                    Volume = section.Volume_D,
                    MudDensity = section.MudDensity_D,
                    FluidType = section.FluidType,
                    InnerDiameter = 0.0,
                    OuterDiameter = section.OuterDiameter_D
                });
                return;
            }

            for (int i = 0; i < sections.Count; i++)
            {
                var sec_1 = sections[i];
                var sec_2 = i < sections.Count - 1 ? sections[i + 1] : sec_1;

                if (sec_2.TopDepth_D <= sec_1.TopDepth_D)
                {
                    AppAnnulusSegments.Add(new AppSegment
                    {
                        TopDepth = sec_2.TopDepth_D,
                        BottomDepth = sec_2.BottomDepth_D,
                        Volume = sec_2.Volume_D,
                        MudDensity = sec_2.MudDensity_D,
                        FluidType = sec_2.FluidType,
                        InnerDiameter = 0.0,
                        OuterDiameter = sec_2.OuterDiameter_D
                    });
                }
                else
                {
                    var bottomDepth = sec_2.TopDepth_D < sec_1.BottomDepth_D ?
                        sec_2.TopDepth_D : sec_1.BottomDepth_D;
                    AppAnnulusSegments.Add(new AppSegment
                    {
                        TopDepth = sec_1.TopDepth_D,
                        BottomDepth = bottomDepth,
                        Volume = sec_1.Volume_D,
                        MudDensity = sec_1.MudDensity_D,
                        FluidType = sec_1.FluidType,
                        InnerDiameter = 0.0,
                        OuterDiameter = sec_1.OuterDiameter_D
                    });
                }

                if (sec_2 == sections.Last())
                {
                    var bottomDepth = sec_2.TopDepth_D < sec_1.BottomDepth_D ?
                        sec_2.TopDepth_D : sec_1.BottomDepth_D;
                    var newOpenHole = new AppSegment
                    {
                        TopDepth = bottomDepth,
                        BottomDepth = sec_2.BottomDepth_D,
                        Volume = sec_2.Volume_D,
                        MudDensity = sec_2.MudDensity_D,
                        FluidType = sec_2.FluidType,
                        InnerDiameter = 0.0,
                        OuterDiameter = sec_2.OuterDiameter_D
                    };
                    if (newOpenHole != AppAnnulusSegments.Last())
                    {
                        AppAnnulusSegments.Add(newOpenHole);
                    }
                    break;
                }
            };
        }

        private void UpdateAppAnnulusForDrillString()
        {
            var j = 0;
            var secondSegment = false;

            for (int i = 0; i < AppAnnulusSegments.Count; i++)
            {

                var seg_ann = AppAnnulusSegments[i];

                if (seg_ann.BottomDepth > DrillString[j].BottomDepth_D)
                {
                    var bottom_ds = DrillString[j].BottomDepth_D;

                    var volume = (seg_ann.Volume - DrillString[j].Capacity_D) * (bottom_ds - seg_ann.TopDepth);

                    // IF THE CASING IS LONGER THAN THE DRILL STRING INSERT A CASING SECTION THAT ENDS AT THE BOTTOM OF THE DRILL STRING
                    //BUT ONLY IF ITS NOT THE LAST DRILL STRING SEGMENT BECAUSE NOTHING BELOW THAT MATTERS RIGHT NOW.

                    if (j < DrillString.Count - 1)
                    {
                        AppAnnulusSegments.Insert(i, new AppSegment
                        {
                            TopDepth = seg_ann.TopDepth,
                            BottomDepth = bottom_ds,
                            Volume = volume,
                            MudDensity = seg_ann.MudDensity,
                            FluidType = seg_ann.FluidType,
                            Strokes = (int)(volume / PumpOutput),
                            InnerDiameter = DrillString[j].OuterDiameter_D,
                            OuterDiameter = seg_ann.InnerDiameter,
                        });
                    }
                    i++;
                    if (j < DrillString.Count - 1)
                    {
                        j++;
                    }

                    seg_ann.TopDepth = secondSegment ? seg_ann.TopDepth : DrillString[j].TopDepth_D;
                    seg_ann.Volume -= DrillString[j].Volume_D;
                    seg_ann.Volume *= secondSegment ?
                        (seg_ann.BottomDepth - seg_ann.TopDepth) :
                        (seg_ann.BottomDepth - DrillString[j].TopDepth_D);
                    seg_ann.Strokes = (int)(seg_ann.Volume / PumpOutput);
                    seg_ann.OuterDiameter = secondSegment ? seg_ann.OuterDiameter : seg_ann.InnerDiameter;
                    seg_ann.InnerDiameter = DrillString[j].OuterDiameter_D;
                    secondSegment = false;
                }
                else
                {
                    seg_ann.Volume -= DrillString[j].Volume_D;
                    seg_ann.Volume *= (seg_ann.BottomDepth - seg_ann.TopDepth);
                    seg_ann.Strokes = (int)(seg_ann.Volume / PumpOutput);
                    seg_ann.OuterDiameter = seg_ann.InnerDiameter;
                    seg_ann.InnerDiameter = DrillString[j].OuterDiameter_D;
                    secondSegment = true;

                }
            }
        }

        private void CreateAppDrillString()
        {

            if (DrillString.Count == 1)
            {
                var ds_1 = DrillString.First();
                var volume = (ds_1.BottomDepth_D - ds_1.TopDepth_D) * ds_1.Capacity_D;

                AppDrillStringSegments.Add(new AppSegment
                {
                    TopDepth = ds_1.TopDepth_D,
                    BottomDepth = ds_1.BottomDepth_D,
                    Volume = volume,
                    MudDensity = ds_1.MudDensity_D,
                    FluidType = ds_1.FluidType,
                    Strokes = (int)(volume / PumpOutput),
                    InnerDiameter = ds_1.InnerDiameter_D,
                    OuterDiameter = ds_1.OuterDiameter_D,
                });
                return;
            }


            for (int i = 0; i <= DrillString.Count + 1; i++)
            {
                var ds_1 = DrillString[i];
                var ds_2 = i < DrillString.Count - 1 ? DrillString[i + 1] : ds_1;

                if (ds_2.TopDepth_D <= ds_1.TopDepth_D)
                {
                    var volume = (ds_2.BottomDepth_D - ds_2.TopDepth_D) * ds_2.Capacity_D;
                    AppDrillStringSegments.Add(new AppSegment
                    {
                        TopDepth = ds_2.TopDepth_D,
                        BottomDepth = ds_2.BottomDepth_D,
                        Volume = volume,
                        MudDensity = ds_2.MudDensity_D,
                        FluidType = ds_2.FluidType,
                        Strokes = (int)(volume / PumpOutput),
                        InnerDiameter = ds_2.InnerDiameter_D,
                        OuterDiameter = ds_2.OuterDiameter_D,
                    });
                }
                else
                {
                    var bottomDepth = ds_2.TopDepth_D < ds_1.BottomDepth_D ?
                        ds_2.TopDepth_D : ds_1.BottomDepth_D;
                    var volume = (bottomDepth - ds_1.TopDepth_D) * ds_1.Capacity_D;
                    AppDrillStringSegments.Add(new AppSegment
                    {
                        TopDepth = ds_1.TopDepth_D,
                        BottomDepth = bottomDepth,
                        Volume = volume,
                        MudDensity = ds_1.MudDensity_D,
                        FluidType = ds_1.FluidType,
                        Strokes = (int)(volume / PumpOutput),
                        InnerDiameter = ds_1.InnerDiameter_D,
                        OuterDiameter = ds_1.OuterDiameter_D,
                    });
                }

                if (ds_2 == DrillString.Last())
                {
                    var bottomDepth = ds_2.TopDepth_D < ds_1.BottomDepth_D ?
                        ds_2.TopDepth_D : ds_1.BottomDepth_D;
                    var volume = (ds_2.BottomDepth_D - bottomDepth) * ds_2.Capacity_D;
                    AppDrillStringSegments.Add(new AppSegment
                    {
                        TopDepth = bottomDepth,
                        BottomDepth = ds_2.BottomDepth_D,
                        Volume = volume,
                        MudDensity = ds_2.MudDensity_D,
                        FluidType = ds_2.FluidType,
                        Strokes = (int)(volume / PumpOutput),
                        InnerDiameter = ds_2.InnerDiameter_D,
                        OuterDiameter = ds_2.OuterDiameter_D,
                    });
                    break;
                }
            };
        }

        private void CreateAppPumpSchedule()
        {
            var tvd = 0.0;
            var tvd_historical = 0.0;
            var md = 0.0;

            foreach (FluidStage segment in PumpSchedule)
            {
                var num_segments = (int)(segment.volume_d * 10);
                var i = 0;
                while (i < num_segments)
                {
                    AppPumpSchedule.Insert(0, new AppFluid()
                    {
                        FluidDensity = segment.mudDensity_d,
                        FluidType = segment.fluidType_s
                    });
                    i++;
                }
            }
            SurfaceLineEndIndex = AppPumpSchedule.Count - 1;
            DrillStringStartIndex = AppPumpSchedule.Count;

            foreach (AppSegment segment in AppDrillStringSegments)
            {
                var num_segments = (segment.Volume * 10);
                var node_length = (segment.BottomDepth - segment.TopDepth) / num_segments;
                num_segments = (int)(num_segments);

                var i = 0;
                while (i < num_segments)
                {
                    AppPumpSchedule.Add(new AppFluid()
                    {
                        FluidDensity = segment.MudDensity,
                        FluidType = segment.FluidType
                    });
                    md += node_length;
                    if (Surveys.Count > 0)
                    {
                        tvd = GetClosestTVD(md);
                    }
                    else
                    {
                        tvd = md;
                    }

                    var tvd_delta = tvd - tvd_historical;
                    tvd_list_ds.Add(tvd_delta);
                    tvd_historical = tvd;
                    i++;
                }
            }
            DrillStringEndIndex = AppPumpSchedule.Count;
            AnnulusStartIndex = AppPumpSchedule.Count + 1;

            foreach (AppSegment segment in AppAnnulusSegments)
            {
                var num_segments = (segment.Volume * 10);
                var node_length = (segment.BottomDepth - segment.TopDepth) / num_segments;
                num_segments = (int)(num_segments);
                var i = 0;
                md = AppAnnulusSegments.Last().BottomDepth;
                tvd_historical = GetClosestTVD(md);

                while (i < num_segments)
                {
                    AppPumpSchedule.Insert(AnnulusStartIndex - 1, new AppFluid()
                    {
                        FluidDensity = segment.MudDensity,
                        FluidType = segment.FluidType
                    });

                    md -= node_length;
                    if (Surveys.Count > 0)
                    {
                        tvd = GetClosestTVD(md);
                    }
                    else
                    {
                        tvd = md;
                    }

                    var tvd_delta = tvd_historical - tvd;
                    tvd_list_ann.Add(tvd_delta);
                    tvd_historical = tvd;
                    i++;
                }
            }
            AnnulusEndIndex = AppPumpSchedule.Count;
        }

        private double GetClosestTVD(double md)
        {

            Survey closest = Surveys.Aggregate((x, y) => Math.Abs(x.md_d - md) < Math.Abs(y.md_d - md) ? x : y);
            if (closest.md_d == 0.0)
            {
                return md;
            }

            var idx = Surveys.IndexOf(closest);
            var tvd_shallower = 0.0;
            var tvd_deeper = 0.0;
            var md_shallower = 0.0;
            var md_deeper = 0.0;

            if (closest.md_d > md)
            {
                tvd_shallower = Surveys[idx - 1].tvd_d;
                tvd_deeper = closest.tvd_d;
                md_shallower = Surveys[idx - 1].md_d;
                md_deeper = closest.md_d;

            }
            else
            {
                tvd_shallower = closest.tvd_d;
                if (idx == Surveys.Count - 1)
                {
                    idx -= 1;
                }
                tvd_deeper = Surveys[idx + 1].tvd_d;
                md_shallower = closest.md_d;
                md_deeper = Surveys[idx + 1].md_d;
            }
            var deltaTVD = tvd_deeper - tvd_shallower;
            var deltaMD = md_deeper - md_shallower;
            var slope = deltaTVD / deltaMD;
            var md_change = md - md_shallower;
            var increaseTVD = md_change * slope;
            return tvd_shallower + increaseTVD;
        }

        private void computeHP()
        {
            var ds_app_list = AppPumpSchedule.Skip(DrillStringStartIndex).Take(DrillStringEndIndex - DrillStringStartIndex);
            var hp_ds = 0.0;
            var i = 0;
            var tvD = 0.0;
            var tvd_final = GetClosestTVD(AppDrillStringSegments.Last().BottomDepth);
            var tvd_sum = tvd_list_ds.Sum();
            var tempDSColors = new ObservableCollection<Color>();
            var tempAnnColors = new ObservableCollection<Color>();

            foreach (var item in ds_app_list)
            {
                hp_ds += (item.FluidDensity * tvd_list_ds[i] * 0.00981);
                tvD += tvd_list_ds[i];
                tempDSColors.Add(item.fluidColor);
                i++;
            }

            if (tvd_final != tvd_sum)
            {
                hp_ds -= (tvD - tvd_final) * 0.00981 * ds_app_list.Last().FluidDensity;
            }

            drillStringColors = tempDSColors;
            DrillStringHP = hp_ds;

            var ann_app_list = AppPumpSchedule.Skip(DrillStringEndIndex).Take(AnnulusEndIndex - DrillStringEndIndex);
            var hp_ann = 0.0;

            i = 0;
            tvD = tvd_list_ann.Last();

            foreach (var item in ann_app_list)
            {
                hp_ann += (item.FluidDensity * tvd_list_ann[i] * 0.00981);
                tvD += tvd_list_ann[i];
                tempAnnColors.Add(item.fluidColor);
                i++;
            }
            tvd_sum = tvd_list_ann.Sum();
            tvd_final = GetClosestTVD(AppAnnulusSegments.Last().BottomDepth);
            if (tvd_final != tvd_sum)
            {
                hp_ann += (tvD - tvd_final) * 0.00981 * ann_app_list.Last().FluidDensity;
            }

            annulusColors = tempAnnColors;

            //Console.WriteLine($"Hydrostatic Pressure Annulus {hp_ann} at {tvD}");
            AnnulusHP = hp_ann;

            DeltaBHP = hp_ds - hp_ann;
        }

        private void computeToolVolumes()
        {
            double totalStringVolume = AppDrillStringSegments.Sum(item => item.Volume);
            double totalAnnVolume = AppAnnulusSegments.Sum(item => item.Volume);

            foreach (DownholeTool tool in Downholetools)
            {
                foreach (AppSegment stringModel in AppDrillStringSegments)
                {
                    if (tool.MeasuredDepth_D < stringModel.BottomDepth)
                    {

                        var fillUP = stringModel.Volume / (stringModel.BottomDepth - stringModel.TopDepth);
                        var volume = fillUP * (tool.MeasuredDepth_D - stringModel.TopDepth);
                        tool.VolumeAboveDS_d += volume;
                        tool.VolumeBelowDS_d = totalStringVolume - tool.VolumeAboveDS_d;
                        break;
                    }
                    else
                    {
                        tool.VolumeAboveDS_d += stringModel.Volume;
                    }
                }

                foreach (AppSegment stringModel in AppAnnulusSegments)
                {
                    if (tool.MeasuredDepth_D < stringModel.BottomDepth)
                    {

                        var fillUP = stringModel.Volume / (stringModel.BottomDepth - stringModel.TopDepth);
                        var volume = fillUP * (tool.MeasuredDepth_D - stringModel.TopDepth);
                        tool.VolumeAboveAnn_d += volume;
                        tool.VolumeBelowAnn_d = totalAnnVolume - tool.VolumeAboveAnn_d;
                        break;
                    }
                    else
                    {
                        tool.VolumeAboveAnn_d += stringModel.Volume;
                    }
                }
            }
        }

        private void getToolIndexes()
        {
            foreach (DownholeTool downholeToolModel in Downholetools)
            {
                downholeToolModel.ToolIndexDS = (int)(downholeToolModel.VolumeAboveDS_d * 10);
                downholeToolModel.ToolIndexAnn = DrillStringEndIndex + (int)(downholeToolModel.VolumeBelowAnn_d * 10);

                if (downholeToolModel.Name == "Stage Tool")
                {
                    StageTool = downholeToolModel;
                    StageToolIndexAnnulus = StageTool.ToolIndexAnn;
                    StageToolIndexDrillString = StageTool.ToolIndexDS  + SurfaceLineEndIndex;
                }
            }
        }

        private void getToolTVDs()
        {
            foreach (DownholeTool downholeToolModel in Downholetools)
            {
                downholeToolModel.TVD_D = GetClosestTVD(downholeToolModel.MeasuredDepth_D);
            }
        }

        private void computeToolHPDS()
        {
            foreach (DownholeTool downholeToolModel in Downholetools)
            {
                var toolStringSegments = AppPumpSchedule.Skip(DrillStringStartIndex).Take(downholeToolModel.ToolIndexDS).ToList();
                var toolDSHP = 0.0;
                var toolTVDDS = 0.0;
                for (int i = 0; i < toolStringSegments.Count; i++)
                {
                    var tvdDelta = tvd_list_ds[i];
                    toolDSHP += toolStringSegments[i].FluidDensity * tvdDelta * 0.00981;
                    toolTVDDS += tvdDelta;

                    if (i == toolStringSegments.Count - 1)
                    {
                        if (toolTVDDS != downholeToolModel.TVD_D)
                        {
                            toolDSHP -= (toolTVDDS - downholeToolModel.TVD_D) * toolStringSegments[i].FluidDensity * 0.00981;
                        }
                    }
                }

                if (StageToolIsOpen && downholeToolModel.MeasuredDepth_D > StageTool.MeasuredDepth_D) { toolDSHP = toolDSHP - StageTool.DsHP_d + StageToolAverageHP; }

                downholeToolModel.DsHP_d = toolDSHP;
            }
        }

        private void computerToolHPANN()
        {
            foreach (DownholeTool downholeToolModel in Downholetools)
            {
                var toolAnnulusSegments = AppPumpSchedule.Skip(downholeToolModel.ToolIndexAnn).Take((int)(downholeToolModel.VolumeAboveAnn_d * 10)).ToList();
                var toolAnnHP = 0.0;
                var toolTVDANN = 0.0;

                for (int i = 0; i < toolAnnulusSegments.Count; i++)
                {
                    var tvdDelta = tvd_list_ann[i];
                    toolAnnHP += toolAnnulusSegments[i].FluidDensity * tvdDelta * 0.00981;
                    toolTVDANN += tvdDelta;
                    // Console.WriteLine($"{toolTVDANN} {tvdDelta}");

                    if (i == toolAnnulusSegments.Count - 1)
                    {
                        if (toolTVDANN != downholeToolModel.TVD_D)
                        {
                            toolAnnHP -= (toolTVDANN - downholeToolModel.TVD_D) * 0.00981 * toolAnnulusSegments[i].FluidDensity;
                        }
                    }
                }

                if (StageToolIsOpen && downholeToolModel.MeasuredDepth_D > StageTool.MeasuredDepth_D) { toolAnnHP = toolAnnHP - StageTool.AnnHP_d + StageToolAverageHP; }


                downholeToolModel.AnnHP_d = toolAnnHP;

                downholeToolModel.Diff_d = downholeToolModel.DsHP_d - toolAnnHP;

                downholeToolModel.CurrentfunctionPressure = downholeToolModel.ActivationType == "Absolute" ?
                    downholeToolModel.ActivationPressure_D - downholeToolModel.DsHP_d :
                    downholeToolModel.ActivationPressure_D - downholeToolModel.Diff_d;
            }
        }

        public void pumpMudForward()
        {
            if (DrillStringStartIndex != 0)
            {
                if (StageToolIsOpen) 
                {
                    // AppFluid node = AppPumpSchedule[DrillStringStartIndex+StageToolIndexDrillString+1];
                    // AppPumpSchedule.RemoveAt(DrillStringStartIndex+StageToolIndexDrillString+1);
                    // AppPumpSchedule.Insert(StageToolIndexAnnulus, node);

                    AppFluid node = AppPumpSchedule[StageToolIndexDrillString];
                    AppPumpSchedule.RemoveAt(StageToolIndexDrillString);
                    AppPumpSchedule.Insert(StageToolIndexAnnulus, node);
                    StageToolAverageHP = (StageTool.DsHP_d + StageTool.AnnHP_d) / 2;
                }

                if (PumpingWithCementers)
                {
                    AppFluid node = AppPumpSchedule[SurfaceLineStartIndex - 1];
                    AppPumpSchedule.RemoveAt(SurfaceLineStartIndex - 1);
                    AppPumpSchedule.Insert(SurfaceLineEndIndex, node);
                }

                
                // SurfaceLineEndIndex -= 1;
                // SurfaceLineStartIndex -= 1;
                // DrillStringEndIndex -= 1;
                // DrillStringStartIndex -= 1;
                // AnnulusEndIndex -= 1;
                // AnnulusStartIndex -= 1;
                // StageToolIndexDrillString -= 1;
                // StageToolIndexAnnulus -= 1;
                AppPumpSchedule.Insert(0, new AppFluid());

                computeHP();
                computeToolHPDS();
                computerToolHPANN();
            }
        }

        public void pumpMudReverse()
        {
            if (AnnulusEndIndex < AppPumpSchedule.Count)
            {
                if (StageToolIsOpen)
                {
                    AppFluid node = AppPumpSchedule[StageToolIndexAnnulus];
                    AppPumpSchedule.RemoveAt(StageToolIndexAnnulus);
                    AppPumpSchedule.Insert(StageToolIndexDrillString, node);
                    StageToolAverageHP = (StageTool.DsHP_d + StageTool.AnnHP_d) / 2;
                }

                if (PumpingWithCementers)
                {
                    AppFluid node = AppPumpSchedule[SurfaceLineEndIndex + 1];
                    AppPumpSchedule.RemoveAt(SurfaceLineEndIndex + 1);
                    AppPumpSchedule.Insert(SurfaceLineEndIndex, node);
                }

                // SurfaceLineEndIndex += 1;
                // SurfaceLineStartIndex += 1;
                // DrillStringEndIndex += 1;
                // DrillStringStartIndex += 1;
                // AnnulusEndIndex += 1;
                // AnnulusStartIndex += 1;
                // StageToolIndexDrillString += 1;
                // StageToolIndexAnnulus += 1;
                AppPumpSchedule.RemoveAt(0);
                computeHP();
                computeToolHPDS();
                computerToolHPANN();
            }
        }

	#endregion

}