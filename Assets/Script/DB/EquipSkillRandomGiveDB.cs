// This code automatically generated by TableCodeGen
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquipSkillRandomGiveDB : MonoBehaviour
{
    
    public TextAsset ItemDatabase;

   
    public void Awake()
    {
        ItemDatabase = Resources.Load("CSV/EquipSkillRandomGive") as TextAsset;
        Load(ItemDatabase);
    }

    //싱글톤만들기. 변경
    private static EquipSkillRandomGiveDB _instance = null;
    public static EquipSkillRandomGiveDB Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(EquipSkillRandomGiveDB)) as EquipSkillRandomGiveDB;

                if (_instance == null)
                {
                }
            }
            return _instance;
        }
    }


	public class Row
	{
        		public string id;
		public string explain;
		public string equipskills;
		public string minlv;
		public string maxlv;
		public string percent;
		public string A;
		public string B;
		public string C;

	}

	List<Row> rowList = new List<Row>();
	bool isLoaded = false;

	public bool IsLoaded()
	{
		return isLoaded;
	}

	public List<Row> GetRowList()
	{
		return rowList;
	}

	public void Load(TextAsset csv)
	{
		rowList.Clear();
		string[][] grid = CsvParser2.Parse(csv.text);
		for(int i = 1 ; i < grid.Length ; i++)
		{
			Row row = new Row();
			row.id = grid[i][0];
			row.explain = grid[i][1];
			row.equipskills = grid[i][2];
			row.minlv = grid[i][3];
			row.maxlv = grid[i][4];
			row.percent = grid[i][5];
			row.A = grid[i][6];
			row.B = grid[i][7];
			row.C = grid[i][8];

			rowList.Add(row);
		}
		isLoaded = true;
	}

	public int NumRows()
	{
		return rowList.Count;
	}

	public Row GetAt(int i)
	{
		if(rowList.Count <= i)
			return null;
		return rowList[i];
	}

	public Row Find_id(string find)
	{
		return rowList.Find(x => x.id == find);
	}
	public List<Row> FindAll_id(string find)
	{
		return rowList.FindAll(x => x.id == find);
	}
	public Row Find_explain(string find)
	{
		return rowList.Find(x => x.explain == find);
	}
	public List<Row> FindAll_explain(string find)
	{
		return rowList.FindAll(x => x.explain == find);
	}
	public Row Find_equipskills(string find)
	{
		return rowList.Find(x => x.equipskills == find);
	}
	public List<Row> FindAll_equipskills(string find)
	{
		return rowList.FindAll(x => x.equipskills == find);
	}
	public Row Find_minlv(string find)
	{
		return rowList.Find(x => x.minlv == find);
	}
	public List<Row> FindAll_minlv(string find)
	{
		return rowList.FindAll(x => x.minlv == find);
	}
	public Row Find_maxlv(string find)
	{
		return rowList.Find(x => x.maxlv == find);
	}
	public List<Row> FindAll_maxlv(string find)
	{
		return rowList.FindAll(x => x.maxlv == find);
	}
	public Row Find_percent(string find)
	{
		return rowList.Find(x => x.percent == find);
	}
	public List<Row> FindAll_percent(string find)
	{
		return rowList.FindAll(x => x.percent == find);
	}
	public Row Find_A(string find)
	{
		return rowList.Find(x => x.A == find);
	}
	public List<Row> FindAll_A(string find)
	{
		return rowList.FindAll(x => x.A == find);
	}
	public Row Find_B(string find)
	{
		return rowList.Find(x => x.B == find);
	}
	public List<Row> FindAll_B(string find)
	{
		return rowList.FindAll(x => x.B == find);
	}
	public Row Find_C(string find)
	{
		return rowList.Find(x => x.C == find);
	}
	public List<Row> FindAll_C(string find)
	{
		return rowList.FindAll(x => x.C == find);
	}

}