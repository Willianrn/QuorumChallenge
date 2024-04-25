"use client";
import useSWR from "swr";
import React from "react";

const fetcher = (url: string | URL | Request) =>
  fetch(url).then((res) => res.json());

export default function BillsTable() {
  const { data, error, isLoading } = useSWR(
    "https://localhost:7291/bills",
    fetcher
  );

  if (error) return <div>Load failed: {error.message}</div>;
  if (isLoading) return <div>Loading...</div>;
  return (
    <table>
      <thead>
        <tr>
          <th>ID</th>
          <th>Bill</th>
          <th>Supporters</th>
          <th>Opposers</th>
          <th>Primary Sponsor</th>
        </tr>
      </thead>
      <tbody>
        {data.map((bill: any) => (
          <tr>
            <td>{bill.id}</td>
            <td>{bill.title}</td>
            <td>{bill.supporters}</td>
            <td>{bill.opposers}</td>
            <td>{bill.primarySponsorLegislator}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}