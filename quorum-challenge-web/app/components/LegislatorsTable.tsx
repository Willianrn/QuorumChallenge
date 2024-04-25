"use client";
import useSWR from "swr";
import React from "react";

const fetcher = (url: string | URL | Request) =>
  fetch(url).then((res) => res.json());

export default function LegislatorsTable() {
  const { data, error, isLoading } = useSWR(
    "https://localhost:7291/legislators",
    fetcher
  );

  if (error) return <div>Load failed: {error.message}</div>;
  if (isLoading) return <div>Loading...</div>;
  return (
    <table>
      <thead>
        <tr>
          <th className="px-4 py-1">ID</th>
          <th className="px-4 py-1">Legislator</th>
          <th className="px-4 py-1">Supported bills</th>
          <th className="px-4 py-1">Opposed bills</th>
        </tr>
      </thead>
      <tbody>
        {data.map((legislator: any) => (
          <tr>
            <td className="px-4 py-1">{legislator.id}</td>
            <td className="px-4 py-1">{legislator.name}</td>
            <td className="px-4 py-1">{legislator.supportedBills}</td>
            <td className="px-4 py-1">{legislator.opposedBills}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}
