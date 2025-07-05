package com.alvin.d2_modul2.ui.components

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.alvin.d2_modul2.R
import com.alvin.d2_modul2.model.Job

class JobAdapter(private val jobs: List<Job>, private val onClick: (Job) -> Unit) :
    RecyclerView.Adapter<JobAdapter.JobViewHolder>() {

    class JobViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val name = view.findViewById<TextView>(R.id.tvVhJobName)
        val company = view.findViewById<TextView>(R.id.tvVHJobCompany)
        val location = view.findViewById<TextView>(R.id.tvVhLocationType)
        val experience = view.findViewById<TextView>(R.id.tvVhExperience)
    }

    override fun onCreateViewHolder(
        parent: ViewGroup,
        viewType: Int
    ): JobViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.vh_job, parent, false)
        return JobViewHolder(view)
    }

    override fun onBindViewHolder(
        holder: JobViewHolder,
        position: Int
    ) {
        val job = jobs[position]
        holder.name.text = job.name
        holder.company.text = job.companyName
        holder.location.text = "${job.locationType} (${job.locationRegion})"
        holder.experience.text = job.yearOfExperience

        holder.itemView.setOnClickListener {
            onClick(job)
        }
    }

    override fun getItemCount(): Int = jobs.size
}