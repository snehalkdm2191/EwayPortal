import React, { useEffect, useState } from "react";
import PortalApi from "../Api/PortalApi";
import EmployeData from "./EmployeData";

export default function HomePage() {
  const [data, setData] = useState([]);
  useEffect(() => {
    const fetchPosts = async () => {
      const response = await PortalApi.getAllEmploye();
      setData(response.data);
    };
    fetchPosts();
  }, []);


  const dataList = data.map((employeData) => (
    <EmployeData key={employeData.id} data={employeData} />
  ));

  return data.length === 0 ? (
    <div className='center-data'>
      <p>No data to show</p>
    </div>
  ) : (
    <div className="parcel-list-body">
      <div className='text-center'>
        <h2 className="title-color">Eway Portal</h2>
      </div>
      <div className="parcel-item-div">
        <span className="pl-item">
          <div className="pl-head">Employee ID :</div>
        </span>
        <span className="pl-item">
          <div className="pl-head">Name :</div>
        </span>
      </div>
      {dataList}
    </div>
  );
}
