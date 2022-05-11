import React from 'react';
import { Link } from 'react-router-dom';

export default function EmployeData(data) {
  console.log(data);
  return (
    <Link to={{ pathname: `/details/${data.data.employeeId}`, state: { data } }}>
      <div className="parcel-item-div">
        <span className="pl-item">
          <div>{data.data.employeeId}</div>
        </span>
        <span className="pl-item">
          <div>{data.data.firstName} {data.data.lastName}</div>
        </span>
      </div>
    </Link>
  );
}
