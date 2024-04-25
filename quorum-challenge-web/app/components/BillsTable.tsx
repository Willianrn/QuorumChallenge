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
          <th className="px-4 py-1">ID</th>
          <th className="px-4 py-1">Bill</th>
          <th className="px-4 py-1">Supporters</th>
          <th className="px-4 py-1">Opposers</th>
          <th className="px-4 py-1">Primary Sponsor</th>
        </tr>
      </thead>
      <tbody>
        {data.map((bill: any) => (
          <tr>
            <td className="px-4 py-1">{bill.id}</td>
            <td className="px-4 py-1">{bill.title}</td>
            <td className="px-4 py-1">{bill.supporters}</td>
            <td className="px-4 py-1">{bill.opposers}</td>
            <td className="px-4 py-1">{bill.primarySponsorLegislator}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}